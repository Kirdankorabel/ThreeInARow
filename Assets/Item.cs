using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemInfo _itemInfo = new ItemInfo();

    public ItemInfo ItemInfo => _itemInfo;

    private void OnMouseDown()
    {
        _itemInfo.Destroy();
        Destroy(gameObject);
    }
}
