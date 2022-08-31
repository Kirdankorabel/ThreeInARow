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

        foreach (var gridInfo in _grid)
            gridInfo.cellReleased += (position) => ChangeGrid(position);

        return _grid;
    }

    private void ChangeGrid(Vector2Int cellPosition)
    {
        for (var i = cellPosition.y; i > 0; i--)
        {
            var item = _grid[cellPosition.x, i - 1].GetItem;
            _grid[cellPosition.x, i].SetItem(item);

        }
        GridCreator.itemCreator.CreateItem(State.GridController.GetCell(cellPosition.x, 0));
    }
}
