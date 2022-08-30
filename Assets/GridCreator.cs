using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridCreator
{
    public static CellCreator cellCreator;
    public static CellInfo[,] CreateCells(Vector2Int size)
    {
        var grid = new CellInfo[size.x, size.y];
        for (var i = 0; i < size.x; i++)
            for (var j = 0; j < size.y; j++)
            {
                grid[i, j] = new CellInfo(new Vector2Int(i, j));
                cellCreator.CreateCell(grid[i, j]);
            }
        return grid;
    }
}
