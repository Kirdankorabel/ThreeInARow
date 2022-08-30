using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;

    public void CreateItem(Cell cell)
    {
        var item = Instantiate(_itemPrefab, cell.transform.position, Quaternion.identity, cell.transform);
        item.ItemInfo.SetCell(cell.CellInfo);
    }
}
