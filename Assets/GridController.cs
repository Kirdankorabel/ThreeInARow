using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private Vector2Int size;
    private GridInfo _gridInfo;

    private void Start()
    {
        _gridInfo = new GridInfo(size);
    }
}
