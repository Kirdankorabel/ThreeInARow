using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int colorsCount;
    public int pointsToWin;
    public int[] moves;
    public int status;

    public Level() { }

    public Level(int _colorsCount, int _points, int[] _moves)
    {
        colorsCount = _colorsCount;
        pointsToWin = _points;
        moves = _moves;
    }
}
