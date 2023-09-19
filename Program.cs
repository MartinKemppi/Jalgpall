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
            Random rnd = new Random();
            int num = rnd.Next(1, 10);

            Console.Title = "Jalgpall";

            Team t1 = new Team("Esimene");
            Player p1 = new Player("Mängija01");
            Player p2 = new Player("Mängija02");
            Player p3 = new Player("Mängija03");
            Player p4 = new Player("Mängija04");
            t1.AddPlayer(p1);
            t1.AddPlayer(p2);
            t1.AddPlayer(p3);
            t1.AddPlayer(p4);

            Team t2 = new Team("Teine");
            Player p6 = new Player("Mängija06");
            Player p7 = new Player("Mängija07");
            Player p8 = new Player("Mängija08");
            Player p9 = new Player("Mängija09");
            t2.AddPlayer(p6);
            t2.AddPlayer(p7);
            t2.AddPlayer(p8);
            t2.AddPlayer(p9);


            // Ei tööta kuna peab olema suurus rohkem kui 0 või töötab, aga ei nii nagu peab
            //Console.BufferWidth = 800; 
            //Console.BufferHeight = 600;

            //Walls
            int mapWidth = 100;
            int mapHeight = 80;
            
            // t1 players on their side
            p1.SetPosition(mapWidth / 4, mapHeight / 2);
            p2.SetPosition(mapWidth / 4, mapHeight / 3);
            p3.SetPosition(mapWidth / 4, mapHeight / 4);
            p4.SetPosition(mapWidth / 4, mapHeight / 5);

            // t2 players on their side
            p6.SetPosition((3 * mapWidth) / 4, mapHeight / 2);
            p7.SetPosition((3 * mapWidth) / 4, mapHeight / 3);
            p8.SetPosition((3 * mapWidth) / 4, mapHeight / 4);
            p9.SetPosition((3 * mapWidth) / 4, mapHeight / 5);


            Walls walls = new Walls(mapWidth, mapHeight);
            Stadium s = new Stadium(mapWidth - 2, mapHeight - 2);

            walls.Draw();
            s.Draw();
            //Walls wall = new Walls(98, 78);
            //wall.Draw();

            //Point p = new Point(num, num, '*');

            //Game g = new Game(t1, t2, s);
            //g.Start();
            //while (true)
            //{
            //    Console.Clear();

            //    // Draw the walls
            //    walls.Draw();

            //    // Draw the stadium
            //    s.Draw();

            //    if (!g.IsRunning)
            //    {
            //        Console.WriteLine("Game Over!");
            //        break;
            //    }

            //    g.Move();

            //    Thread.Sleep(1000);
            //}
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