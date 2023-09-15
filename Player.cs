using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football;

public class Player
{
    //väljud
    public string Name { get; } //mängija nimi
    public double X { get; private set; } //horizon. pos.
    public double Y { get; private set; } //vertical. pos.
    private double _vx, _vy; // mängija ja palli kaugus
    public Team? Team { get; set; } = null; // meeskond, kus mängija mängib

    private const double MaxSpeed = 5; // Max mängija kiirus
    private const double MaxKickSpeed = 25; //  Max löögi kiirus
    private const double BallKickDistance = 10; // löögikaugus

    private Random _random = new Random(); // juhuslik arv

    //konstruktorid
    public Player(string name)  // sõltub sõnest ja sõne võrdleb Namega
    {
        Name = name;
    }

    public Player(string name, double x, double y, Team team) //mängija põlul, oma nimega, pos x ja y ning meeskond, kus ta mängib
    {
        Name = name;
        X = x;
        Y = y;
        Team = team;
    }

    public void SetPosition(double x, double y) //Anname pos x ja y 
    {
        X = x;
        Y = y;
    }

    public (double, double) GetAbsolutePosition()  // Pos, kus mängija mängub sõltuvalt meeskonna poolest
    {
        return Team!.Game.GetPositionForTeam(Team, X, Y);
    }

    public double GetDistanceToBall() // kaugus pallini
    {
        var ballPosition = Team!.GetBallPosition();
        var dx = ballPosition.Item1 - X;
        var dy = ballPosition.Item2 - Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public void MoveTowardsBall() // liiguma otse palli suunas
    {
        var ballPosition = Team!.GetBallPosition();
        var dx = ballPosition.Item1 - X;
        var dy = ballPosition.Item2 - Y;
        var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
        _vx = dx / ratio;
        _vy = dy / ratio;
    }

    public void Move() // liiguma
    {
        if (Team.GetClosestPlayerToBall() != this)  //Meeskond kes on lähim pallini
        {
            _vx = 0;
            _vy = 0;
        }

        if (GetDistanceToBall() < BallKickDistance) //arvutame palli löögi kiirust
        {
            Team.SetBallSpeed(
                MaxKickSpeed * _random.NextDouble(),
                MaxKickSpeed * (_random.NextDouble() - 0.5)
                );
        }

        var newX = X + _vx;
        var newY = Y + _vy;
        var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY); //määrame uued pos. x ja y
        if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
        {
            X = newX;
            Y = newY;
        }
        else
        {
            _vx = _vy = 0;
        }
    }
}
