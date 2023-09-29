using Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kirjutame terminali nime
            Console.Title = "Jalgpall";

            //Loome 2 meeskonda
            Team t1 = new Team("Esimene");            
            Team t2 = new Team("Teine");           

            //suurus x ja y
            int mapWidth = 50;
            int mapHeight = 60;

            //määrame konsooli suurust
            Console.SetWindowSize(mapWidth, mapHeight);

            // Walls e seinad
            Walls walls = new Walls(mapWidth, mapHeight);

            // Stadium            
            Stadium s = new Stadium(mapWidth - 2, mapHeight - 2);
           
            //teeme tsükli ja lisame mängijad meeskonnale
            for (int i = 1; i <= 22; i++)
            {
                Player player = new Player($"Player {i}");
                
                if (i <= 11)
                {                    
                    t1.AddPlayer(player);                    
                }
                else
                {
                    t2.AddPlayer(player);
                }
            }

            // Loome uue mängu
            Game g = new Game(t1, t2, s);

            // Pall keskele
            Ball ball = new Ball(mapWidth / 2, mapHeight / 2, g);           

            // Start the game
            g.Start();

            while (true)
            {
                //teeme mängu liikumiseks
                g.Move();

                //joonistame mängijad ja pall
                DrawField(s.Width, s.Height, t1.Players, t2.Players, g.Ball);

                //Console.Clear();

                // Joonistame seinad e walls ja stadium
                walls.Draw();
                s.Draw();                                              

                //juhul kui mäng ei mängi siis mäng lõppeb ja kirjutab game over
                if (!g.IsRunning)
                {
                    Console.WriteLine("Game Over!");
                    break;
                }

                //tsükli uuendamiseks
                Thread.Sleep(100);
            }
        }
        
        private static void DrawField(int width, int height, List<Player> t1, List<Player> t2, Ball ball) //joonistame mängijad ja pall, värvime mängijad eristamiseks
        {
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(3, y + 1); 
                
                for (int x = 0; x < width; x++)
                {
                    if (IsPlayerAtPosition(x, y, t1))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("H");
                        Console.ResetColor();
                    }
                    else if (IsPlayerAtPosition(x, y, t2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;                        
                        Console.Write("G");
                        Console.ResetColor();
                    }
                    else if (IsBallAtPosition(x, y, ball))
                    {
                        ball.Draw();                        
                    }
                    else
                    {
                        Console.Write(" "); 
                    }
                }               
            }
        }

        private static bool IsPlayerAtPosition(int x, int y, List<Player> players) //juhul kui mängija pos x ja pos y on õige, siis tagastame true, aga kui mitte siis false
        {
            foreach (var player in players)
            {
                int playerX = (int)Math.Round(player.X);
                int playerY = (int)Math.Round(player.Y);

                if (playerX == x && playerY == y)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsBallAtPosition(int x, int y, Ball ball) //saame teada kas pall on kohal v ei, saame palli x ja y pos ja tagastaeme selle x ja y pos
        {
            int ballX = (int)Math.Round(ball.X);
            int ballY = (int)Math.Round(ball.Y);
            return ballX == x && ballY == y;
        }
    }
}