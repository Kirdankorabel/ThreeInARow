using System;
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
    private int _moveCount;

    public event Action<int> Win;

    void Awake()
    {
        State.GameController.PointsAdded += (points) => AddPoints(points);
        State.GameController.Moved += ((move) =>
        {
            _moveCount = move;
            _moveText.text = move.ToString();
        });
        _countText.text = _count.ToString();
        _openMenuButton.onClick.AddListener(() => UIController.GetUIObject("GameMenuPanel").Enable());

        UIController.AddUIObject(this.gameObject.name, this);
    }

    public void AddPoints(int points)
    {
        _countText.text = points.ToString();
        if (points > StaticInfo.Level.pointsToWin)
        {
            Debug.Log(_moveCount);
            var res = 0;
            for (var i = 0; i < StaticInfo.Level.moves.Length; i++)
                if (_moveCount < StaticInfo.Level.moves[i])
                {
                    res = 2 - i;
                    break;
                }
            Debug.Log(res);
            StaticInfo.Level.SetStatus(res + 1);
            Win?.Invoke(res);
        }
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);
}
