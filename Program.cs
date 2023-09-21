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
            Player p1 = new Player('H');
            Player p2 = new Player('H');
            Player p3 = new Player('H');
            Player p4 = new Player('H');
            t1.AddPlayer(p1);
            t1.AddPlayer(p2);
            t1.AddPlayer(p3);
            t1.AddPlayer(p4);

            Team t2 = new Team("Teine");
            Player p6 = new Player('G');
            Player p7 = new Player('G');
            Player p8 = new Player('G');
            Player p9 = new Player('G');
            t2.AddPlayer(p6);
            t2.AddPlayer(p7);
            t2.AddPlayer(p8);
            t2.AddPlayer(p9);

            // Ensure the buffer size is at least as large as the map dimensions
            //Walls 
            // Set a reasonable buffer size
            int bufferWidth = 120;
            int bufferHeight = 100;
            Console.BufferWidth = bufferWidth;
            Console.BufferHeight = bufferHeight;

            int mapWidth = 100;
            int mapHeight = 80;

            // Ei tööta kuna peab olema suurus rohkem kui 0 või töötab, aga ei nii nagu peab
            //Console.BufferWidth = 800; 
            //Console.BufferHeight = 600;           

            // Walls
            Walls walls = new Walls(mapWidth, mapHeight);

            // Stadium
            Stadium s = new Stadium(mapWidth - 2, mapHeight - 2);



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

            // Adjust player positions for the teams
            PlacePlayersOnField(t1.Players, 1, mapHeight / 2, mapWidth / 4, mapHeight / 2);
            PlacePlayersOnField(t2.Players, 3 * mapWidth / 4, mapHeight / 2, mapWidth / 4, mapHeight / 2);            

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

                // Clear the console screen
                Console.Clear();

                // Redraw walls and stadium
                walls.Draw();
                s.Draw();

                // Draw players
                foreach (var player in t1.Players)
                {
                    player.Draw();
                }

                foreach (var player in t2.Players)
                {
                    player.Draw();
                }

                // Draw the ball
                ball.Draw();


                if (!g.IsRunning)
                {
                    Console.WriteLine("Game Over!");
                    break;
                }

                Thread.Sleep(200);
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

        // Function to place players on the field
        private static void PlacePlayersOnField(List<Player> players, int startX, int startY, int width, int height)
        {
            int spacingX = width / 2;
            int spacingY = height / (players.Count + 1); // +1 to add some spacing at the top

            for (int i = 0; i < players.Count; i++)
            {
                int playerX = startX + spacingX;
                int playerY = startY + (i + 1) * spacingY; // +1 to move them below the top wall
                players[i].SetPosition(playerX, playerY);
            }
        }


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
}