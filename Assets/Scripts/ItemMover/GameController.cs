using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private IItemsSelector _itemsSelector;
    private IItemsMover _itemsMover;
    private List<ILineChecker> _lineCheckers = new List<ILineChecker>();
    private CellInfo cell1;

    private List<CellInfo> _releasedCells;

    private void Awake()
    {
        _itemsSelector = new CrossItemSelector();
        _itemsMover = new ItemsMover();

        _lineCheckers.Add(new VertLineChecker());
    }
    public void SelectItem(CellInfo cellInfo)
    {
        _releasedCells = new List<CellInfo>();
        if (cell1 == null)
        {
            cell1 = cellInfo;
            cell1.GetItem.Active = true;
        }
        else if (_itemsSelector.SelectItem(cell1, cellInfo) && cell1 != cellInfo)
        {
            cell1.GetItem.Active = false;
            _itemsMover.Move(cell1, cellInfo);
            CheckLines(cell1);
            CheckLines(cellInfo);
            cell1 = null;
            RelesedCells();
        }
        else
        {
            cell1.GetItem.Active = false;
            cell1 = cellInfo;
            cell1.GetItem.Active = true;
        }
    }

    private void CheckLines(CellInfo cellInfo)
    {
        foreach (var lineChecker in _lineCheckers)
        {            
            var items = lineChecker.CheckLine(cellInfo.GetPosition2, cellInfo.GetItem.ItemType);
            if (items != null)
                _releasedCells.AddRange(items);
        }
    }

    private void RelesedCells()
    {
        _releasedCells = _releasedCells.OrderBy(item => item.GetPosition2.y).ToList();
        foreach (var item in _releasedCells)
            item.ReleasedCell();
        _releasedCells = _releasedCells.OrderByDescending(item => item.GetPosition2.y).ToList();
        foreach (var item in _releasedCells)
            item.SetNextItem();
    }
}
