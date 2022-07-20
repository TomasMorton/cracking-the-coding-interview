/*
    Ideas:
        - recursive add with lower number as depth of recursion
            O(min(x,y)) - each layer removes one from the lower input
            
        - shift multiplies by two
        
    5 * 3 = 15
    (5 * 2) + (5 * 1)
    (5 * 4) - (5 * 1)
    
    5 * 4 = 20
    (5 * 2) + (5 * 2)

*/

private int Multi(int value, int multiplier)
{
    if (multiplier == 0) return 0;
    if (multiplier == 1) return value;
    
    var half = Multi(value, multiplier >> 1);
    if (multiplier % 2 == 0)
        return half + half;
    else
        return half + half + value;
}