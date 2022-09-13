using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GridInfo
{
    [SerializeField] private CellInfo[,] _grid;
    [SerializeField] private Vector2Int _size;

    public event Action<ItemInfo> ItemDestroyed;

    public CellInfo[,] CreateGridInfo (Vector2Int size)
    {
        _size = size;
        _grid = GridCreator.CreateCells(_size);


        return _grid;
    }
}