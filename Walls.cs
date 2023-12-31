﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int x, int y)
        {
            wallList = new List<Figure>();

            //Frame
            HorizontalLine upLine = new HorizontalLine(0, x - 1, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, x - 1, y - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, y - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, y - 1, x - 1, '+');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
