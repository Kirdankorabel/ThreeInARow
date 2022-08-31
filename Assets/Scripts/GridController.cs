using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;
    private GridInfo _gridInfo;
    private Cell[,] _cells;

    private void Awake()
    {
        State.GridController = this;
    }
    private void Start()
    {
        _cells = new Cell[_size.x, _size.y];
        _gridInfo = new GridInfo();
        CellInfo[,] cells = _gridInfo.CreateGridInfo(_size);
        foreach(var item in cells)
            _cells[item.GetPosition2.x, item.GetPosition2.y] = GridCreator.cellCreator.CreateCell(item);
    }

    public Cell GetCell(int x, int y)
        => _cells[x, y];
}
