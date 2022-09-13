using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeReference] private CellInfo _cellInfo;
    public CellInfo CellInfo => _cellInfo;

    public void SetCellInfo(CellInfo cellInfo)
    {
        if(_cellInfo == null)
            _cellInfo = cellInfo;
    }
}