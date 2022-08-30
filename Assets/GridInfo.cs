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

    public GridInfo (Vector2Int size)
    {
        _size = size;
        _grid = GridCreator.CreateCells(_size);

        foreach (var item in _grid)
            item.cellReleased += (position) => ChangeGrid(position);
    }

    private void ChangeGrid(Vector2Int cellPosition)
    {

    }
}
