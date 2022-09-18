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
        _exitButton.onClick.AddListener(() => Exit());

        Disable();
    }

    private void Exit()
    {
        GameState gameState = new GameState();
        gameState.gridInfo = State.GridController.GetGridInfo;
        gameState.level = StaticInfo.Level;
        gameState.moves = State.GameController.GetMoveCount();
        gameState.points = State.GameController.GetPointsCount();
        DataSaver.SaveData<GameState>(gameState, "save");
        StaticInfo.Level = null;

        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
