using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GridInfo
{
    private CellInfo[,] _grid;
    public List<CellInfo> cells = new List<CellInfo>();
    [SerializeField] private Vector2Int _size;

    public event Action<ItemInfo> ItemDestroyed;

    public GridInfo() { }

    public CellInfo[,] CreateGridInfo (Vector2Int size)
    {
        _size = size;
        _grid = GridCreator.CreateCells(_size);
        foreach (var cell in _grid)
            cells.Add(cell);
        return _grid;
    }

    public CellInfo[,] Load()
    {
        _grid = new CellInfo[_size.x, _size.y];
        foreach (var cell in cells)
        {
            cell.UpdatePosition();
            _grid[cell.GetPosition2.x, cell.GetPosition2.y] = cell;
        }
        return _grid;
    }
}