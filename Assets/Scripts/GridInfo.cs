using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInfo
{
    private CellInfo[,] _grid;
    private Vector2Int _size;
    public Vector2Int GrtSizr => _size;

    public event Action<ItemInfo> ItemDestroyed;

    public CellInfo[,] CreateGridInfo (Vector2Int size)
    {
        _size = size;
        _grid = GridCreator.CreateCells(_size);


        return _grid;
    }
}