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
            Console.Title = "Jalgpall";

            Team t1 = new Team("Esimene");            
            Team t2 = new Team("Teine");           

            int mapWidth = 50;
            int mapHeight = 60;          

            // Walls
            Walls walls = new Walls(mapWidth, mapHeight);

            // Stadium            
            Stadium s = new Stadium(mapWidth - 2, mapHeight - 2);
           
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

            // Create the game
            Game g = new Game(t1, t2, s);

            // Create the ball and place it in the middle
            Ball ball = new Ball(mapWidth / 2, mapHeight / 2, g);

            // Start the game
            g.Start();

            while (true)
            {
                // Update game state (players, ball, etc.) within the loop
                g.Move();

                DrawField(s.Width, s.Height, t1.Players, t2.Players, g.Ball);

                //Console.Clear();

                // Redraw walls and stadium
                walls.Draw();
                s.Draw();                                              

                if (!g.IsRunning)
                {
                    Console.WriteLine("Game Over!");
                    break;
                }

                Thread.Sleep(100);
            }
        }

        private static void DrawField(int width, int height, List<Player> team1, List<Player> team2, Ball ball)
        {
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y + 1); 
                
                for (int x = 0; x < width; x++)
                {
                    if (IsPlayerAtPosition(x, y, team1))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("H");
                        Console.ResetColor();
                    }
                    else if (IsPlayerAtPosition(x, y, team2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("G");
                        Console.ResetColor();
                    }
                    else if (IsBallAtPosition(x, y, ball))
                    {
                        
                        Console.Write("O"); // pall
                    }
                    else
                    {
                        Console.Write(" "); 
                    }
                }
                
            }
        }

        private static bool IsPlayerAtPosition(int x, int y, List<Player> players)
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

        private static bool IsBallAtPosition(int x, int y, Ball ball)
        {
            int ballX = (int)Math.Round(ball.X);
            int ballY = (int)Math.Round(ball.Y);
            return ballX == x && ballY == y;
        }        
    }
}