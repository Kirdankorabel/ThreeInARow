using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private ItemInfo _itemInfo;
    private Vector3 _targetPosition;
    private bool _isMove;

    public ItemInfo ItemInfo
    {
        get => _itemInfo;
        set
        {
            if (_itemInfo == null)
                _itemInfo = value;
        }
    }
    
    private void Start()
    {
        _itemInfo.PositionChanged += (position) =>
        {
            _targetPosition = position;
            StartCoroutine(MoveCorutine());
        };
    }

    private void OnMouseDown()
    {
        if (_isMove)
            return;
        _itemInfo.Destroy();
        Destroy(gameObject);
    }

    public void SetColor(Color color)
        => gameObject.GetComponent<MeshRenderer>().material.color = color;

    private IEnumerator MoveCorutine()
    {
        _isMove = true;
        while (Vector3.Distance(transform.localPosition, _targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, _speed);
            yield return null;
        }
        _isMove = false;
        yield return null;
    }
}
