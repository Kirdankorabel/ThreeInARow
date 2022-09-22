using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    void Start()
    {
        UIController.AddUIObject(this.gameObject.name, this);

        _menuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene");
            DataSaver.SaveData<GameState>(State.gameState, "save");
        });
        Disable();
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
