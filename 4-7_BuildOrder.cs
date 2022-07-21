/*
    Input: List<Project>, List<Dependency>, where Dependency is <To * From>
    Output: List<Project>?
        Fail if there is a two-way dependency
        Fail if there is a cycle
        Fail if there is no project without any dependencies
        Fail if there is no project that is not a dependency
        Succeed if there are multiple projects that are not a dependency
        Succeed if there are isolated projects        
        
    Assumptions:
        There are no isolated projects ?
    
    Risks:
        Cycles & isolated projects
        
    Ideas:
        Start from the 0-dependency and move up
        Build a directional graph and do DFS
        Build a directional graph and remove each node that has no outgoing edges.
        
    Solution:
        Build a graph
        Find the entry points (no incoming references). Fail if none.
        Do DFS on each entry point. Mark as building when visiting and Built when completed
        If trying to revisit a building node then fail (cycle/double dependency/no-end)
*/
public class ProjectBuilder
{
    public List<Project>? Build(List<Project> projects, List<Dependency> dependencies)
    {
        //todo: validate input
        var dependencyGraph = BuildDependencyGraph(projects, depenedencies);
        return CreateBuildOrder(projects, dependencyGraph);
    }
    
    private HashMap<Project, List<Project>> BuildDependencyGraph(List<Project> projects, List<Dependency> dependencies)
    {
        //todo: validate input
        var result = new HashMap<Project, List<Project>>();
        foreach (var project in projects)
            result.Add(project, new List<Project>());
            
        foreach (var dependency in dependencies)
            result[dependency.From].Add(Dependency.To);
            
        return result;
    }
    
    private List<Project>? CreateBuildOrder(List<Project> projects, HashMap<Project, List<Project>> dependencyGraph)
    {
        //todo: validate input
        IEnumerable<Project> result = Enumerable<Project>.Empty;
        foreach (var project in projects)
        {
            var buildOrder = BuildProject(project, dependencyGraph);
            if (buildOrder == null) return null;
            result = result.Concat(buildOrder);
        }
        
        return result.ToList();
    }
    
    private IEnumerable<Project>? BuildProject(Project project, HashMap<Project, List<Project>> dependencyGraph)
    {
        //todo: validate input
        if (project.BuildStatus == BuildStatus.Building)
            return null; //Cycle detected
        
        if (project.BuildStatus == BuildStatus.Built)
            return Enumerable<Project>.Empty;
        
        project.BuildStatus = Building;
        
        var dependencies = dependencyGraph[project];
        IEnumerable<Project> result = new[] { project };
        foreach (var dependency in dependencies)
        {            
            var dependencyBuildOrder = BuildProject(dependency, dependencyGraph);
            result = result.Concat(dependencyBuildOrder);
        }
        
        project.BuildStatus = BuildStatus.Built;        
        return result;
    }
}

public record Project(int Id, BuildStatus = NotBuilt);
public record Dependency(Project To, Project From);
public enum BuildStatus = { NotBuilt, Building, Built };