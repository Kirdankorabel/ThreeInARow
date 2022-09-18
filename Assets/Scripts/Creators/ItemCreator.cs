using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private List<Color> _colors;
    private static int _counter;
    private static List<Item> _items;

    private void Awake()
    {
        GridCreator.itemCreator = this;
    }

    public static void ResetItems()
    {
        if (_items != null)
            foreach (var item in _items)
                if(item != null)
                    Destroy(item.gameObject);

        _items = new List<Item>();
        _counter = 0;
    }

    public Item CreateItem(Cell cell)
    {
        var item = Instantiate(_itemPrefab, cell.transform.position, Quaternion.identity, transform);
        var types = Enum.GetValues(typeof(ItemType));
        item.ItemInfo = new ItemInfo((ItemType)types.GetValue(UnityEngine.Random.Range(0, GridController.ItemTypesCount)));
        item.SetColor(_colors[(int)item.ItemInfo.ItemType]);
        item.gameObject.name = $"item {_counter++}";
        item.ItemInfo.Destroyed += () => _items.Remove(item);

        cell.CellInfo.SetItem(item.ItemInfo);
        _items.Add(item);
        return item;
    }

    public Item CreateItem(Cell cell, ItemInfo itemInfo)
    {
        var item = Instantiate(_itemPrefab, cell.transform.position, Quaternion.identity, transform);
        item.ItemInfo = itemInfo;
        item.SetColor(_colors[(int)item.ItemInfo.ItemType]);
        item.gameObject.name = $"item {_counter++}";
        item.ItemInfo.Destroyed += () => _items.Remove(item);

        cell.CellInfo.SetItem(item.ItemInfo);
        _items.Add(item);
        return item;
    }
}
