using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private List<Color> _colors;

    private void Awake()
    {
        GridCreator.itemCreator = this;
    }

    public Item CreateItem(Cell cell)
    {
        var item = Instantiate(_itemPrefab, cell.transform.position, Quaternion.identity, transform);
        var types = Enum.GetValues(typeof(ItemType));
        item.ItemInfo = new ItemInfo((ItemType)types.GetValue(UnityEngine.Random.Range(0, types.Length)));
        item.SetColor(_colors[(int)item.ItemInfo.ItemType]);

        cell.CellInfo.SetItem(item.ItemInfo);
        return item;
    }
}
