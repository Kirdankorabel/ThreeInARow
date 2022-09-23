using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertLineChecker : ILineChecker
{
    private List<CellInfo> deletedItems;

    public List<CellInfo> CheckLine(Vector2Int position, ItemType itemType)
    {
        deletedItems = new List<CellInfo>();
        deletedItems.Add(StaticInfo.GridController.GetCell(position).CellInfo);
        CheckTop(position.x, position.y, itemType);
        CheckDown(position.x, position.y, itemType);
        if (deletedItems.Count > 2)
            return deletedItems;
        return null;
    }

    private void CheckTop(int posX, int posY, ItemType itemType)
    {
        if (posY == StaticInfo.Size.y - 1) return;
        while (StaticInfo.GridController.GetCell(posX, posY + 1).CellInfo.GetItem.ItemType == itemType)
        {
            deletedItems.Add(StaticInfo.GridController.GetCell(posX, ++posY).CellInfo);
            if (posY == StaticInfo.Size.y - 1) return;
        }
    }

    private void CheckDown(int posX, int posY, ItemType itemType)
    {
        if (posY < 10) return;
        while (StaticInfo.GridController.GetCell(posX, posY - 1).CellInfo.GetItem.ItemType == itemType)
        {
            deletedItems.Add(StaticInfo.GridController.GetCell(posX, --posY).CellInfo);
            if (posY == StaticInfo.Size.y - 10) return;
        }
    }
}