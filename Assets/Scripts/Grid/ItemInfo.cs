using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[Serializable]
public class ItemInfo
{
    private Vector3 _position;
    [SerializeField] private ItemType _itemType;
    private bool _active;
    public event Action<Vector3> PositionChanged;
    public event Action Activated;
    public event Action Destroyed;

    public event PropertyChangedEventHandler PropertyChanged;

    public Vector3 Position { get; set; }

    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Active"));
        }
    }

    public bool IsMove { get; set; }

    public ItemType ItemType => _itemType;

    public ItemInfo(ItemType itemType)
    {
        _itemType = itemType;
    }

    public void SetCell(CellInfo cellInfo)
    {
        Activated = null;
        _position = cellInfo.GetPosition3;
        PositionChanged?.Invoke(_position);
    }

    public void Activate()
    {
        Activated?.Invoke();
    }

    public void Destroy()
    {
        Destroyed?.Invoke();
    }
}
