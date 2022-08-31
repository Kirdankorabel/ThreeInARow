using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInfo
{
    private Vector2Int _position2;
    private Vector3 _position3;
    private ItemInfo _item;
    public event Action<Vector2Int> cellReleased;

    public Vector2Int GetPosition2 => _position2;
    public Vector3 GetPosition3 => _position3;
    public ItemInfo GetItem => _item;

    public CellInfo (Vector2Int position)
    {
        _position2 = position;
        _position3 = new Vector3(position.x + position.x * StaticInfo.offset, position.y + position.y * StaticInfo.offset);
    }

    public void SetItem(ItemInfo item)
    {
        _item = item;
        item.SetCell(this);
        _item.Destroyed += () => cellReleased?.Invoke(_position2);
    }
}
