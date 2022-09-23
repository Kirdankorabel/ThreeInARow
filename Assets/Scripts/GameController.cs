using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GridController _gridController;
    private IItemsSelector _itemsSelector;
    private IItemsMover _itemsMover;
    private List<ILineChecker> _lineCheckers = new List<ILineChecker>();
    private CellInfo _cell1;
    private int _movesCount;
    private int _pointsCount;

    private List<CellInfo> _releasedCells;

    public event Action<int> Win;
    public event Action<int> PointsAdded;
    public event Action<int> Moved;

    private void Awake()
    {
        _itemsSelector = new CrossItemSelector();
        _itemsMover = new ItemsMover();

        _lineCheckers.Add(new VertLineChecker());
        _lineCheckers.Add(new HorisontalLineChecker());
        StaticInfo.GameController = this;
    }

    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        _movesCount = 0;
        _pointsCount = 0;
        _gridController.LoadLevel();
        Moved?.Invoke(_movesCount);
        PointsAdded?.Invoke(_pointsCount);
    }

    public void SelectItem(CellInfo cellInfo)
    {
        if (CheckMovingItems()) return;
        if (cellInfo.GetPosition2.y < 10) return;

        StaticInfo.GridController.ResetCheckList();
        _releasedCells = new List<CellInfo>();
        if (_cell1 == null)
        {
            _cell1 = cellInfo;
            _cell1.GetItem.Active = true;
        }
        else if(_cell1.GetItem.ItemType == cellInfo.GetItem.ItemType)
        {
            _cell1.GetItem.Active = false;
            _cell1 = null;
        }
        else if (_itemsSelector.SelectItem(_cell1, cellInfo) && _cell1 != cellInfo)
        {
            _cell1.GetItem.Active = false;
            _itemsMover.Move(_cell1, cellInfo);
            CheckLines(_cell1);
            CheckLines(cellInfo);
            _cell1 = null;
            StartCoroutine(Waiter.WaitCorutine(0.5f, () => RelesedCells(_releasedCells)));
            Moved?.Invoke(++_movesCount);
            
        }
        else
        {
            _cell1.GetItem.Active = false;
            _cell1 = cellInfo;
            _cell1.GetItem.Active = true;
        }
    }

    private void CheckLines(CellInfo cellInfo)
    {
        foreach (var lineChecker in _lineCheckers)
        {            
            var items = lineChecker.CheckLine(cellInfo.GetPosition2, cellInfo.GetItem.ItemType);
            if (items != null)
            {
                items = items.Distinct().ToList();
                _releasedCells.AddRange(items);
                AddPoints(items.Count);
            }
            _releasedCells = _releasedCells.Distinct().ToList();
        }
    }

    private void RelesedCells(List<CellInfo> releasedCells)
    {
        releasedCells = releasedCells.OrderBy(item => item.GetPosition2.y).ToList();
        foreach (var item in releasedCells)
            item.ReleasedCell();
        releasedCells = releasedCells.OrderByDescending(item => item.GetPosition2.y).ToList();
        foreach (var item in releasedCells)
            item.SetNextItem();

        if (StaticInfo.GridController.GetCheckList.Count > 0)
            StartCoroutine(Waiter.WaitCorutine(() => CheckMovingItems(), () => Check(StaticInfo.GridController.GetCheckList)));
    }

    public void Check(List<CellInfo> checkList)
    {
        _releasedCells.Clear();
        foreach (var cell in checkList)
            if(cell.GetPosition2.y > 10)
                CheckLines(cell);
        if(_releasedCells.Count > 0)
            RelesedCells(_releasedCells);
    }

    private bool CheckMovingItems()
    {
        foreach (var cell in StaticInfo.GridController.GetCheckList)
            if (cell.GetItem.IsMove)
                return true;
        return false;
    }

    private void AddPoints(int count)
    {
        _pointsCount += (int)(count / 3f * 10);
        PointsAdded?.Invoke(_pointsCount);

        if (_pointsCount > StaticInfo.Level.pointsToWin)
        {
            var res = 0;
            for (var i = 0; i < StaticInfo.Level.moves.Length; i++)
                if (_movesCount < StaticInfo.Level.moves[i])
                {
                    res = 2 - i;
                    break;
                }
            StaticInfo.Level.SetStatus(res + 1);
            Win?.Invoke(res);
        }
    }

    public int GetMoveCount() => _movesCount;
    public int GetPointsCount() => _pointsCount;

    public void SetCount(int movesCount, int pointsCount)
    {
        _movesCount = movesCount;
        _pointsCount = pointsCount;
    }
}
