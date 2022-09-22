using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private GameObject content;

    private void Awake()
    {
        State.gameState = DataSaver.loadData<GameState>("save");
        var levels = State.gameState.levels;
        if (levels == null || StaticInfo.levels.levels == null)
        {
            State.gameState.levels = StaticInfo.levels.CreateLevels();
        }
        var counter = 0;
        foreach (var level in StaticInfo.levels.levels)
        {
            level.LevelComplited += (id) =>
            {
                if(id < StaticInfo.levels.levels.Count)
                    StaticInfo.levels.levels[id + 1].SetStatus(0);
            };
            level.id = counter;
            var button = Instantiate(_levelButtonPrefab, content.transform);
            button.SetLevel(level);
            button.SetText($"Level {++counter}");
            button.GetComponent<Button>().interactable = level.status > -1;
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
