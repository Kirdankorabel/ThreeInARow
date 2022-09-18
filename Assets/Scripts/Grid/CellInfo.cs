using System;
using UnityEngine;

[Serializable]
public class CellInfo
{
    [SerializeField] private Vector2Int _position2;
    [SerializeReference] private ItemInfo _item;
    private Vector3 _position3;
    public event Action<CellInfo> cellReleased;
    public event Action cellActivated;

    public Vector2Int GetPosition2 => _position2;
    public Vector3 GetPosition3 => _position3;
    public ItemInfo GetItem => _item;

    public CellInfo() { }

    public CellInfo (Vector2Int position)
    {
        _position2 = position;
        _position3 = new Vector3(position.x + position.x * StaticInfo.offset, position.y + position.y * StaticInfo.offset);
    }

    public void SetItem(ItemInfo item)
    {
        _item = item;
        item.SetCell(this);
        _item.Activated += () => cellActivated?.Invoke();
    }

    public void UpdatePosition()
        => _position3 = new Vector3(_position2.x + _position2.x * StaticInfo.offset, _position2.y + _position2.y * StaticInfo.offset);

    public void ResetItem()
    {
        _item = null;
        cellReleased?.Invoke(this);
    }

    public void ReleasedCell()
    {
        _item.Destroy();
        _item = null; 
    }

    public void SetNextItem()
        => cellReleased?.Invoke(this);
}
