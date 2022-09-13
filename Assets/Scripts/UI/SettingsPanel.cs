using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour, IEnabled
{
    void Start()
    {
        UIController.AddUIObject(this.gameObject.name, this);
        Disable();
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
