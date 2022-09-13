using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Text _text;
    private Button _button;
    private Level _level;

    private void Awake()
    {
        _button = this.gameObject.GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            StaticInfo.Level = _level;
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        });
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string text) => _text.text = text;
    public void SetLevel(Level level) => _level = level;
}
