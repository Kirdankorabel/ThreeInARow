using System;
using UnityEngine;

[Serializable]
public class SettingsInfo
{
    [SerializeField] public float musicVolume = 1f;
    [SerializeField] public float soundVolume = 1f;

    public SettingsInfo() { }
}