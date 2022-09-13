using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private Outline _outline;
    private ItemInfo _itemInfo;
    private Vector3 _targetPosition;
    private bool _isMove;

    public bool Active 
    { 
        set
        {
            _outline.enabled = value;
        }
    }

    public ItemInfo ItemInfo
    {
        get => _itemInfo;
        set
        {
            if (_itemInfo == null)
            {
                _itemInfo = value;
                Binder binderPosition = new Binder(this, "Active", _itemInfo, "Active");
                _itemInfo.PositionChanged += (position) =>
                {
                    _targetPosition = position;
                    if (!_isMove)
                        StartCoroutine(MoveCorutine());
                };
                _itemInfo.Destroyed += () => Destroy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        _itemInfo.Position = transform.localPosition;
    }

    private void OnMouseDown()
    {
        if (_isMove)
            return;
        _itemInfo.Activate();
    }

    public void SetColor(Color color)
        => gameObject.GetComponent<SpriteRenderer>().color = color;

    private IEnumerator MoveCorutine()
    {
        _isMove = true;
        _itemInfo.IsMove = _isMove;
        while (Vector3.Distance(transform.localPosition, _targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
        _isMove = false;
        _itemInfo.IsMove = _isMove;
        yield return null;
    }
}
