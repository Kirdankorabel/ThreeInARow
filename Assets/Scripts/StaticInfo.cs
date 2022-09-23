using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticInfo
{
    public static readonly float offset = 0.1f;
    public static LevelsCreator levels = new LevelsCreator();
    public static GameState gameState;
    public static Level Level { get; set; }
    public static GridController GridController { get; set; }
    public static GameController GameController { get; set; }
    public static Vector2Int Size { get; set; }
}
