using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{
    public static Dictionary<string, IEnabled> UIObjects = new Dictionary<string, IEnabled>();

    private void Awake()
    {
    }

    public static void AddUIObject(string name, IEnabled UIobject)
    {
        if(!UIObjects.ContainsKey(name))
            UIObjects.Add(name, UIobject);
    }

    public static IEnabled GetUIObject(string name)
        => UIObjects[name];
}
