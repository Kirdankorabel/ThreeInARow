using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUIPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private Image[] _images = new Image[3];
    [SerializeField] private Text _winText;
    [SerializeField] private Button _acceptButton;
    [SerializeField] private GameUIPanel _uIPanel;

    void Start()
    {
        UIController.AddUIObject(this.gameObject.name, this);
        _uIPanel.Win += (result) => Win(result);
        _acceptButton.onClick.AddListener(() =>
        {
            UIController.GetUIObject("WinMenuPanel").Enable();
            Disable();
        });

        Disable();
    }

    private void Win(int result)
    {
        for (var i = 0; i < result + 1; i++)
            _images[i].gameObject.SetActive(true);
        Enable();
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
