using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    private Vector3 _position;
    public event Action Destroyed;
    public void SetCell(CellInfo cellInfo)
    {
        _position = cellInfo.GetPosition3;
    }

    public void Destroy()
    {
        Destroyed?.Invoke();
    }
}
