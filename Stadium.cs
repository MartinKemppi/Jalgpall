using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football;

public class Stadium
{
    public Stadium(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; }

    public int Height { get; }

    public bool IsIn(double x, double y) //True - pall on sees || false - pall on väljas
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}
