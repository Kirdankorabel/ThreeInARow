using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCreator : MonoBehaviour
{
    [SerializeField] private Cell _prefab;
    [SerializeField] private ItemCreator itemCreator;

    private void Awake()
    {
        GridCreator.cellCreator = this;
    }

    public Cell CreateCell(CellInfo cellInfo)
    {
        var x = cellInfo.GetPosition3.x;
        var y = cellInfo.GetPosition3.y;

        var cell =  Instantiate(_prefab, new Vector3(x, y), Quaternion.identity, transform);
        cell.SetCellInfo(cellInfo);
        var item = GridCreator.itemCreator.CreateItem(cell);
        return cell;
    }
}
