using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football;

public class Team
{
    //väljud
    public List<Player> Players { get; } = new List<Player>(); // nimekiri objekti mängija
    public string Name { get; private set; } // meeskonna nimi
    public Game Game { get; set; } // määrame mängu

    //konstruktor
    public Team(string name) // sõltub sõnest ja sõne võrdleb Namega
    {
        Name = name;
    }

    public void StartGame(int width, int height) // alustame mängu laius ja kõrgus
    {
        Random rnd = new Random();
        foreach (var player in Players)
        {
            player.SetPosition
                (
                rnd.NextDouble() * width,
                rnd.NextDouble() * height
                );
        }
    }

    public void AddPlayer(Player player) // lisame mängijat
    {
        if (player.Team != null) return;
        Players.Add(player);
        player.Team = this;
    }

    public (double, double) GetBallPosition() // saame palli pos.
    {
        return Game.GetBallPositionForTeam(this);
    }

    public void SetBallSpeed(double vx, double vy) // määrame palli kiirust
    {
        Game.SetBallSpeedForTeam(this, vx, vy);
    }

    public Player GetClosestPlayerToBall() // Saame lähim mängija pallini
    {
        Player closestPlayer = Players[0];
        double bestDistance = Double.MaxValue;
        foreach (var player in Players)
        {
            var distance = player.GetDistanceToBall();
            if (distance < bestDistance)
            {
                closestPlayer = player;
                bestDistance = distance;
            }
        }

        return closestPlayer;
    }

    public void Move() // liigume palli suunas
    {
        GetClosestPlayerToBall().MoveTowardsBall();
        Players.ForEach(player => player.Move());
    }
}
