using System;
using UnityEngine;

[Serializable]
public class Level
{
    public int id;
    public int colorsCount;
    public int pointsToWin;
    public int[] moves;
    public int status = -1;

    public event Action<int> LevelComplited;

    public Level() { }

    public Level(int _colorsCount, int _points, int[] _moves)
    {
        colorsCount = _colorsCount;
        pointsToWin = _points;
        moves = _moves;
    }

    public Level(int _colorsCount, int _points, int[] _moves, int _status)
    {
        colorsCount = _colorsCount;
        pointsToWin = _points;
        moves = _moves;
        status = _status;
    }

    public void SetStatus(int value)
    {
        if (status > value)
            return;
        if (value >= -1 && value <= 3)
            status = value;
        if (value > 0)
            LevelComplited?.Invoke(id);
    }
}
