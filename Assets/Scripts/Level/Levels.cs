using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Levels
{
    public static List<Level> levels = new List<Level>()
    {
        new Level(3,1000,new int[]{5,10,20}),
        new Level(5,1000,new int[]{5,10,20}),
        new Level(5,2000,new int[]{5,10,20})
    };
}
