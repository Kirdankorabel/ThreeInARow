using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    private Vector3 _position;
    private ItemType _itemType;
    public event Action<Vector3> PositionChanged;
    public event Action Destroyed;

    public ItemType ItemType => _itemType;
    public Vector3 Position => _position;

    public ItemInfo(ItemType itemType)
    {
        _itemType = itemType;
    }

    public void SetCell(CellInfo cellInfo)
    {
        Destroyed = null;
        _position = cellInfo.GetPosition3;
        PositionChanged?.Invoke(_position);
    }

    public void Destroy()
    {
        Destroyed?.Invoke();
    }
}
