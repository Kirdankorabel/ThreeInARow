using UnityEngine;

public static class State
{
    public static GameState gameState;
    public static GridController GridController { get; set; }
    public static GameController GameController { get; set; }
    public static Vector2Int Size { get; set; }
}
