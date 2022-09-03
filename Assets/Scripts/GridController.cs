using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;
    [SerializeField] private GameController _gameController;
    private GridInfo _gridInfo;
    private Cell[,] _cells;

    public Cell[,] GetCells => _cells;

    private void Awake()
    {
        State.GridController = this;
    }
    private void Start()
    {
        _cells = new Cell[_size.x, _size.y];
        _gridInfo = new GridInfo();
        CellInfo[,] cells = _gridInfo.CreateGridInfo(_size);
        foreach (var cell in cells)
        {
            _cells[cell.GetPosition2.x, cell.GetPosition2.y] = GridCreator.cellCreator.CreateCell(cell);
            cell.cellActivated += () => _gameController.SelectItem(cell);
            
            cell.cellReleased += (cell) => cell.SetItem(GetNextItem(cell.GetPosition2));
        }
    }

    private ItemInfo GetNextItem(Vector2Int cellPosition)
    {
        ItemInfo itemInfo;
        for (var i = cellPosition.y; i >= 0; i--)
        {
            itemInfo = _cells[cellPosition.x, i].CellInfo.GetItem;
            if (itemInfo != null)
            {
                _cells[cellPosition.x, i].CellInfo.ResetItem();
                return itemInfo;
            }
        }
        return GridCreator.itemCreator.CreateItem(State.GridController.GetCell(cellPosition.x, 0)).ItemInfo;
    }

    public Cell GetCell(Vector2Int position)
        => _cells[position.x, position.y];
    public Cell GetCell(int x, int y)
        => _cells[x, y];
}
