using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private Button _quitButton;
    [SerializeField] private GameObject content;

    private void Awake()
    {
        StaticInfo.gameState = DataSaver.loadData<GameState>("save");
        if (StaticInfo.gameState.levels.Count == 0)
        {
            StaticInfo.gameState.levels = StaticInfo.levels.CreateLevels();
        }
        var counter = 0;
        foreach (var level in StaticInfo.gameState.levels)
        {
            level.LevelComplited += (id) =>
            {
                if(id < StaticInfo.gameState.levels.Count)
                    StaticInfo.gameState.levels[id + 1].SetStatus(0);
            };
            level.id = counter;
            var button = Instantiate(_levelButtonPrefab, content.transform);
            button.SetLevel(level);
            button.SetText($"Level {++counter}");
            button.GetComponent<Button>().interactable = level.status > -1;
        }

        var rect = content.GetComponent<RectTransform>();
        var sizeY = (_quitButton.GetComponent<RectTransform>().sizeDelta.y + 20) * StaticInfo.gameState.levels.Count;
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(rect.sizeDelta.x, sizeY);
    }

    void Start()
    {
        _quitButton.onClick.AddListener(() => gameObject.SetActive(false));
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
