public class ItemsMover : IItemsMover
{
    public void Move(CellInfo cell1, CellInfo cell2)
    {
        var itemInfo1 = cell1.GetItem;
        var itemInfo2 = cell2.GetItem;

        cell2.SetItem(itemInfo1);
        cell1.SetItem(itemInfo2);
    }
}