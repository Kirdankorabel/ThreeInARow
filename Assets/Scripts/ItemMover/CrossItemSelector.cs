using UnityEngine;

public class CrossItemSelector : IItemsSelector
{
    public bool SelectItem(CellInfo cell1, CellInfo cell2)
    {
        if (Vector2.Distance(cell1.GetPosition2, cell2.GetPosition2) > 1.01f)
            return false;
        return true;
    }
}
