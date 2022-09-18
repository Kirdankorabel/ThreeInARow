using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private Text _countText;
    [SerializeField] private Text _moveText;
    [SerializeField] private Button _openMenuButton;
    private int _count;

    void Awake()
    {
        State.GameController.PointsAdded += (points) => AddPoints(points);
        State.GameController.Moved += (move) => _moveText.text = move.ToString();
        _countText.text = _count.ToString();
        _openMenuButton.onClick.AddListener(() => UIController.GetUIObject("GameMenuPanel").Enable());


        UIController.AddUIObject(this.gameObject.name, this);
    }

    public void AddPoints(int points)
    {
        _countText.text = points.ToString();
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
