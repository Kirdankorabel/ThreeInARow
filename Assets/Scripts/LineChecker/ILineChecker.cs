using System.Collections.Generic;
using UnityEngine;

public interface ILineChecker
{
    public List<CellInfo> CheckLine(Vector2Int position, ItemType itemType);
}