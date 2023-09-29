using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football;
public class Stadium
{
    public int Width { get; }
    public int Height { get; }

    public Stadium(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public bool IsIn(double x, double y)
    {
        // Adjust the boundaries to fit within the walls
        return x > 1 && x < Width - 1 && y > 1 && y < Height - 3;
    }

    public void Draw() //joonistame stadiooni
    {
        // Draw the stadium within the adjusted boundaries
        Console.SetCursorPosition(3, 3); // Adjust positions for the desired spacing
        Console.WriteLine(new string('-', Width - 4)); // Adjust width and subtract 4
        for (int i = 4; i < Height - 2; i++) // Adjust height and subtract 5
        {
            Console.SetCursorPosition(3, i); // Adjust positions for the desired spacing
            Console.Write('|');
            Console.SetCursorPosition(Width - 2, i); // Adjust positions for the desired spacing
            Console.Write('|');
        }
        Console.SetCursorPosition(3, Height - 2); // Adjust positions for the desired spacing
        Console.WriteLine(new string('-', Width - 4)); // Adjust width and subtract 4
    }
}