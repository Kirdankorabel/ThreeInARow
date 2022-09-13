using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private List<Button> _levelButtons;
    [SerializeField] private GameObject content;
    [SerializeField] private List<Level> _levels;

    private void Awake()
    {
        _levels = Levels.levels;
        var counter = 0;
        foreach (var level in _levels)
        {
            var button = Instantiate(_levelButtonPrefab, content.transform);
            button.SetLevel(level);
            button.SetText($"Level {++counter}");
        }

        //content.GetComponent<RectTransform>().sizeDelta = new Vector2(_rectTransform.sizeDelta.x, size);
    }

    void Start()
    {
        UIController.AddUIObject(this.gameObject.name, this);
        Disable();
    }

    public void AddLevel()
    {

    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
