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
            StaticInfo.GameController.LoadLevel();
            Disable();
        });
        _openSettingsButton.onClick.AddListener(() => UIController.GetUIObject("AudioSettingsPanel").Enable());
        _exitButton.onClick.AddListener(() => Exit());

        Disable();
    }

    private void Exit()
    {
        GameState gameState = new GameState();
        gameState.gridInfo = StaticInfo.GridController.GetGridInfo;
        gameState.level = StaticInfo.Level;
        gameState.moves = StaticInfo.GameController.GetMoveCount();
        gameState.points = StaticInfo.GameController.GetPointsCount();
        gameState.levels = StaticInfo.gameState.levels;
        DataSaver.SaveData<GameState>(gameState, "save");
        StaticInfo.Level = null;

        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
