/*
    Risks:
        Numbers of different lengths
        
    Ideas:
        shift and compare
        XOR, and shift-count
*/ 
public class BitConverter
{
    public int Convert(int from, int to)
    {
        var diff = from ^ to;
        var bitCount = 0;
        while (diff > 0)
        {
            if ((diff & 1) == 1)
                bitCount++;
            
            diff >>= 1;
        }
        
        return bitCount;
    }
    
}