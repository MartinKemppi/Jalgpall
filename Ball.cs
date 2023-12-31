﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football;

public class Ball
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public string Symbol { get; }

    private double _vx, _vy; // palli lennu kaugus

    private Game _game; //  pall mängus

    private void ResetToCenter()
    {
        X = _game.Stadium.Width / 2;
        Y = _game.Stadium.Height / 2;
        _vx = _vy = 0;
    }

    public Ball(double x, double y, Game game, string symbol = "o") // Added a default symbol 'o'
    {
        _game = game;
        X = x;
        Y = y;
        Symbol = symbol; // Set the ball's symbol
    }

    public void SetSpeed(double vx, double vy)
    {
        _vx = vx;
        _vy = vy;
    }

    public void Move()
    {
        double newX = X + _vx; 
        double newY = Y + _vy; 
        if (_game.Stadium.IsIn(newX, newY)) 
        {
            X = newX; 
            Y = newY;
        }
        else
        {
            ResetToCenter();
        }
    }

    public void Draw()
    {
        Console.SetCursorPosition((int)Math.Round(X), (int)Math.Round(Y));
        Console.Write(Symbol); // Use the Symbol property to display the ball's symbol
    }
}
