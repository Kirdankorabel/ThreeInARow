using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUIPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private Image[] _images = new Image[3];
    [SerializeField] private Text _winText;
    [SerializeField] private Button _acceptButton;
    [SerializeField] private WinMenuPanel _winMenuPanel;

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
