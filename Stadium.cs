using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football;

/*
public class Stadium
{
    public int Width { get; }

    public int Height { get; }

    private List<Figure> stadiumFigures;

    public Stadium(int width, int height)
    {
        Width = width;
        Height = height;

        stadiumFigures = new List<Figure>();

        // Create the stadium boundaries as a figure
        HorizontalLine topWall = new HorizontalLine(0, Width - 1, 0, '-');
        HorizontalLine bottomWall = new HorizontalLine(0, Width - 1, Height - 1, '-');
        VerticalLine leftWall = new VerticalLine(0, Height - 3, 0, '|');
        VerticalLine rightWall = new VerticalLine(0, Height - 1, Width - 1, '|');

        stadiumFigures.Add(topWall);
        stadiumFigures.Add(bottomWall);
        stadiumFigures.Add(leftWall);
        stadiumFigures.Add(rightWall);
    } 

    public bool IsIn(double x, double y) //True - pall on sees || false - pall on väljas
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    public void Draw()
    {
        foreach (var figure in stadiumFigures)
        {
            figure.Draw();
        }
    }
}
*/

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

    public void Draw()
    {
        //// Draw the stadium within the adjusted boundaries
        //Console.SetCursorPosition(1, 3); // Adjust positions for the desired spacing
        //Console.WriteLine(new string('-', Width - 2)); // Adjust width and subtract 2
        //for (int i = 4; i < Height - 4; i++) // Adjust height and subtract 4
        //{
        //    Console.SetCursorPosition(1, i); // Adjust positions for the desired spacing
        //    Console.Write('|');
        //    Console.SetCursorPosition(Width - 2, i); // Adjust positions for the desired spacing
        //    Console.Write('|');
        //}
        //Console.SetCursorPosition(1, Height - 4); // Adjust positions for the desired spacing
        //Console.WriteLine(new string('-', Width - 2)); // Adjust width and subtract 2

        
        // Draw the stadium within the adjusted boundaries
        Console.SetCursorPosition(2, 3); // Adjust positions for the desired spacing
        Console.WriteLine(new string('-', Width - 2)); // Adjust width and subtract 4
        for (int i = 4; i < Height - 5; i++) // Adjust height and subtract 5
        {
            Console.SetCursorPosition(2, i); // Adjust positions for the desired spacing
            Console.Write('|');
            Console.SetCursorPosition(Width - 5, i); // Adjust positions for the desired spacing
            Console.Write('|');
        }
        Console.SetCursorPosition(2, Height - 5); // Adjust positions for the desired spacing
        Console.WriteLine(new string('-', Width - 4)); // Adjust width and subtract 4
        
    }
}