using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;
    [SerializeField] private GameController _gameController;
    [SerializeField] private float _coolDown;
    private GridInfo _gridInfo;
    private Cell[,] _cells;
    private static Level _level;

    private List<CellInfo> _checkList = new List<CellInfo>();

    public GridInfo GetGridInfo => _gridInfo;
    public List<CellInfo> GetCheckList => _checkList;

    public static int ItemTypesCount => _level.colorsCount;

    public void LoadLevel()
    {
        StaticInfo.GridController = this;
        StaticInfo.Size = _size;
        if (StaticInfo.Level != null)
        {
            _level = StaticInfo.Level;
            if (_cells != null)
                foreach (var cell in _cells)
                    Destroy(cell.gameObject);
            CreateGrid();
        }
        else
        {
            LoadGrid();
        }
    }

    private void CreateGrid()
    {
        ItemCreator.ResetItems();
        _cells = new Cell[_size.x, _size.y];
        _gridInfo = new GridInfo();
        CellInfo[,] cells = _gridInfo.CreateGridInfo(_size);
        foreach (var cell in _gridInfo.cells)
        {
            _cells[cell.GetPosition2.x, cell.GetPosition2.y] = GridCreator.cellCreator.CreateCell(cell);
            cell.cellActivated += () => _gameController.SelectItem(cell);

            cell.cellReleased += (cell) => GetNextItem(cell);
        }
    }

    public void LoadGrid()
    {
        _level = StaticInfo.gameState.level;
        _gridInfo = StaticInfo.gameState.gridInfo;
        _gameController.SetCount(StaticInfo.gameState.moves, StaticInfo.gameState.points);
        CellInfo[,] cells = _gridInfo.Load();

        ItemCreator.ResetItems();
        StaticInfo.Level = new Level(3, 1000, new int[] { 4, 4, 10 });
        _cells = new Cell[_size.x, _size.y];


        foreach (var cell in _gridInfo.cells)
        {
            _cells[cell.GetPosition2.x, cell.GetPosition2.y] = GridCreator.cellCreator.LoadCell(cell);

            cell.cellActivated += () => _gameController.SelectItem(cell);
            cell.cellReleased += (cell) => GetNextItem(cell);
        }
    }

    private void GetNextItem(CellInfo cellInfo)
    {
        if(!_checkList.Contains(cellInfo))
            _checkList.Add(cellInfo);
        ItemInfo itemInfo;
        for (var i = cellInfo.GetPosition2.y; i >= 0; i--)
        {
            itemInfo = _cells[cellInfo.GetPosition2.x, i].CellInfo.GetItem;
            if (itemInfo != null)
            {
                _cells[cellInfo.GetPosition2.x, i].CellInfo.ResetItem();
                cellInfo.SetItem(itemInfo);
                return;
            }
        }
        cellInfo.SetItem(GridCreator.itemCreator.CreateItem(StaticInfo.GridController.GetCell(cellInfo.GetPosition2.x, 0)).ItemInfo);
    }

    public void ResetCheckList() => _checkList.Clear();

    public Cell GetCell(Vector2Int position)
        => _cells[position.x, position.y];
    public Cell GetCell(int x, int y)
        => _cells[x, y];

}
