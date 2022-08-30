using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInfo
{
    private Vector2Int _position;
    private Vector3 _position3;
    private ItemInfo _item;
    public event Action<Vector2Int> cellReleased;

    public Vector2Int GetPosition2 => _position;
    public Vector3 GetPosition3 => _position3;

    public CellInfo (Vector2Int position)
    {
        _position = position;
        _position3 = new Vector3(position.x + position.x * StaticInfo.offset, position.y + position.y * StaticInfo.offset);
    }

    public void SetItem(ItemInfo item)
    {
        _item = item;
        _item.Destroyed += () => cellReleased?.Invoke(_position);
    }
}
