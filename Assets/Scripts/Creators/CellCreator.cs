using UnityEngine;

public class CellCreator : MonoBehaviour
{
    [SerializeField] private Cell _prefab;
    [SerializeField] private ItemCreator _itemCreator;

    private void Awake()
    {
        GridCreator.cellCreator = this;
    }

    public Cell CreateCell(CellInfo cellInfo)
    {
        var cell =  Instantiate(_prefab, transform.position + cellInfo.GetPosition3, Quaternion.identity, transform);
        cell.SetCellInfo(cellInfo);
        GridCreator.itemCreator.CreateItem(cell);
        return cell;
    }

    public Cell LoadCell(CellInfo cellInfo)
    {
        var cell = Instantiate(_prefab, transform.position + cellInfo.GetPosition3, Quaternion.identity, transform);
        
        cell.SetCellInfo(cellInfo);
        GridCreator.itemCreator.CreateItem(cell, cellInfo.GetItem);
        return cell;
    }
}
