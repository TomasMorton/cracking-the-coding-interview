/*
    Single array of bytes stores a screen
    Each byte represents 8 pixels (one bit = one pixel)
    There is a width in pixels, that is divisible by 8 (so will not be split across a byte)
    
    Example:
    - screen = byte[9]
    - width = 24 pixels, so 3 bytes
    - height = screen.Length / (width/8) = 9 / 3 = 3 rows
    
    Point (x,y) can be found with width/8*y + x:
        Point (12, 2) will be at bit 2 * 24 + 12 = 60, which is screen[60/8] at bit 60%8, so screen[7] bit 4
        Point (18, 0) will be at bit (0*24+18) = 18, which is screen[18/8] at bit 18%8, so screen[2] bit 2
        Point (23, 2) will be at bit 2*24+23=71, which at screen[8] bit 7
        
    To draw a line, we will change all of the 0 bits to 1s, so effectively an OR with 1.
        We will need to mask the starting byte, completely overwrite any intermediate byte, and mask the final byte
        
    Edge cases:
        - line of 0 length
        - "backwards" line
        
    Guard cases
        - width is divisible by 8
        - screen is null or empty
        - an x or y value that is out of bounds
*/
public class Canvas
{
    private readonly byte[] _screen;
    private readonly int _widthPx;
    private readonly int _widthBytes;
    
    public void DrawLine(byte[] screen, int width, int x1, int x2, int y)
    {
        _screen = screen;
        _widthPx = width;
        _widthBytes = _widthPx / 8;       

        var from = GetPixelLocation(Math.Min(x1, x2), y);
        var to = GetPixelLocation(Math.Max(x1, x2), y);
        
        if (from.Index == to.Index) {
            DrawSmallLine(from, to);
        } else {
            DrawStart(from);
            DrawMiddle(from, to);
            DrawEnd(to);
        }            
    }
    
    private void DrawSmallLine(ScreenLocation from, ScreenLocation to)
    {
        //TODO: Guard same array index
        var fromMask = ~0 >> from.Bit;
        var toMask = ~0 << (7-to.Bit);
        var mask = fromMask & toMask;
        _screen[from.Index] |= mask;
    }
    
    private void DrawStart(ScreenLocation from)
    {
        var mask = ~0 >> from.Bit;
        _screen[from.Index] |= mask;        
    }
    
    private void DrawMiddle(ScreenLocation from, ScreenLocation to)
    {
        var start = from.Index + 1;
        var end = to.Index - 1;
        
        for (var i = start; i <= end; i++)
            _screen[i] = Byte.MaxValue;
    }
    
    private void DrawEnd(ScreenLocation to)
    {
        var mask = ~0 << (7-to.Bit);
        _screen[to.Index] |= mask;        
    }    
    
    private ScreenLocation GetPixelLocation(int x, int y)
    {
        var yOffset = y * _widthPx;
        var pixel = yOffset + x;
        return new(pixel/8, pixel%8);
    }
    
    private record ScreenLocation(int Index, int Bit);
}