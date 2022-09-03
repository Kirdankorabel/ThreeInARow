using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertLineChecker : ILineChecker
{
    private List<CellInfo> deletedItems;

    public List<CellInfo> CheckLine(Vector2Int position, ItemType itemType)
    {
        deletedItems = new List<CellInfo>();
        deletedItems.Add(State.GridController.GetCell(position).CellInfo);
        CheckTop(position.x, position.y, itemType);
        CheckDown(position.x, position.y, itemType);
        if (deletedItems.Count > 2)
            return deletedItems;
        return null;
    }

    private void CheckTop(int posX, int posY, ItemType itemType)
    {
        while (State.GridController.GetCell(posX, posY + 1).CellInfo.GetItem.ItemType == itemType)
        {
            deletedItems.Add(State.GridController.GetCell(posX, ++posY).CellInfo);
        }
    }

    private void CheckDown(int posX, int posY, ItemType itemType)
    {
        while (State.GridController.GetCell(posX, posY - 1).CellInfo.GetItem.ItemType == itemType)
        {
            deletedItems.Add(State.GridController.GetCell(posX, --posY).CellInfo);
        }
    }
}