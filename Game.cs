using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football;

public class Game
{
    //väljud
    public Team HomeTeam { get; } 
    public Team AwayTeam { get; }
    public Stadium Stadium { get; }
    public Ball Ball { get; private set; }
    public bool IsRunning { get; private set; } = true;
    public int ScoreH { get; private set; }
    public int ScoreG { get; private set; }

    //konstruktor
    public Game(Team homeTeam, Team awayTeam, Stadium stadium)
    {
        HomeTeam = homeTeam;
        homeTeam.Game = this;
        AwayTeam = awayTeam;
        awayTeam.Game = this;
        Stadium = stadium;
    }

    //Teeme stoppi juhul kui mäng ei mängi
    public void Stop()
    {
        IsRunning = false;
    }

    public void Start() // alustame mängu, paneme palli keskele, meeskonnad oma poolele
    {
        Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this);
        HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height);
        AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height);
    }
    private (double, double) GetPositionForAwayTeam(double x, double y) // Pos meeskonnale teistele
    {
        return (Stadium.Width - x, Stadium.Height - y);
    }

    public (double, double) GetPositionForTeam(Team team, double x, double y) // Pos meeskonnale esimesele
    {
        return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
    }

    public (double, double) GetBallPositionForTeam(Team team) // Pos. palli meeskonna jaoks
    {
        return GetPositionForTeam(team, Ball.X, Ball.Y);
    }

    public void SetBallSpeedForTeam(Team team, double vx, double vy)  // määrame palli kiirust meeskonnale
    {
        if (team == HomeTeam)
        {
            Ball.SetSpeed(vx, vy);
        }
        else
        {
            Ball.SetSpeed(-vx, -vy);
        }
    }

    public void Move() //liikumine, mõlema meeskonnale ja pallile
    {
        HomeTeam.Move();
        AwayTeam.Move();
        Ball.Move();

        if (Ball.Y <= 3) // juhul kui pall pos Y on vähem v võrdleb 3-ga siis +1 Guest meeskond saab +1 tulemust, kustutame konsooli ja näitame tulemust ja vastupidi ka teisele meeskonnale
        {
            ScoreG++; // Guest team score
            Console.Clear();
            Console.WriteLine($"Guest Team: {ScoreG}");
            Console.WriteLine($"Home Team: {ScoreH}");
            Thread.Sleep(1000);
            Console.Clear();
        }
        else if (Ball.Y >= Stadium.Height - 3) 
        {
            ScoreH++; // Home team score
            Console.Clear();
            Console.WriteLine($"Guest Team: {ScoreG}");
            Console.WriteLine($"Home Team: {ScoreH}");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
