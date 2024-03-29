/*
    Given a 2d array, a point in it and a colour,
        set the point to the color
        recurse with up/down/left/right while in-bounds
        
    Edge case:
        - point already has same colour       

*/

public class Painter
{
    private int[][] _canvas;
    private int _newColour;
    private int _originalColour;
    
    public void Fill(int[][] canvas, int newColour, Pixel from)
    {
        if (canvas == null || canvas.Length == 0 || canvas[0].Length == 0) throw new ArgumentNullException(nameof(canvas));        
        _canvas = canvas;
        
        _originalColour = GetColourAt(from) ?? throw new ArgumentOutOfRangeException();
        if (newColour == _originalColour)
            return; //No fill if same colour
        _newColour = newColour;
        
        FillAround(from);
    }
    
    private void FillAround(Pixel pixel)
    {
        var currentColour = GetColourAt(pixel);
        if (currentColour == null || currentColour != _originalColour)
            return;
        
        SetColourAt(pixel);
        FillAround(pixel.Left());
        FillAround(pixel.Right());
        FillAround(pixel.Below());
        FillAround(pixel.Above());
    }
    
    private int? GetColourAt(Pixel p)
        => p.Row >= 0 && p.Row < _canvas.Length &&
                p.Column >= 0 && p.Column <= _canvas[0].Length
           ? _canvas[p.Row][p.Column]
           : null;
        
    private void SetColourAt(Pixel p)
        => _canvas[p.Row][p.Column] = _newColour;
    
    public record Pixel(int Row, int Column)
    {
        public Pixel Left() => new(Row, Column - 1);
        public Pixel Right() => new(Row, Column + 1);
        public Pixel Below() => new(Row + 1, Column);
        public Pixel Above() => new(Row - 1, Column);
    }
}