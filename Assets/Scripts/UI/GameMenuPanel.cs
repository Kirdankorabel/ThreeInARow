using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private Button _continueGameButton;
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] private Button _openSettingsButton;
    [SerializeField] private Button _exitButton;

    void Start()
    {
        UIController.AddUIObject(this.gameObject.name, this);
        _continueGameButton.onClick.AddListener(() => Disable());
        _restartLevelButton.onClick.AddListener(() =>
        {
            State.GameController.LoadLevel();
            this.gameObject.SetActive(false);
        });
        _openSettingsButton.onClick.AddListener(() => UIController.GetUIObject("SettingsPanel").Enable());
        _exitButton.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
            DataSaver.saveData<GridInfo>(State.GridController.GetGridInfo, "save");
            Debug.Log(33);
        });

        Disable();
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
