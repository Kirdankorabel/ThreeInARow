using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, IEnabled
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _selectLevelButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _quitButton;

    private void Start()
    {
        _playButton.onClick.AddListener(() => SceneManager.LoadScene("SampleScene"));
        _selectLevelButton.onClick.AddListener(() => UIController.GetUIObject("LevelsPanel").Enable());
        _settingsButton.onClick.AddListener(() => UIController.GetUIObject("SettingsPanel").Enable());
        _quitButton.onClick.AddListener(() => Application.Quit());
        UIController.AddUIObject(this.gameObject.name, this);
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
