using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenuPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;


    // Start is called before the first frame update
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
