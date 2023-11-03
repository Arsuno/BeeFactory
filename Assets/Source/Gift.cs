using System.Collections;
using UnityEngine;

public class Gift : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private RectTransform _canvasRectTransform;
    [SerializeField] private float _speed;

    private Vector2 _direction = new Vector2(1,1);

    public IEnumerator Throw()
    {
        gameObject.SetActive(true);
        float currentLifeTime = 0;

        while (currentLifeTime < _lifetime)
        {
            _rectTransform.anchoredPosition += _direction * _speed;

            if (CheckWallsCollide(_rectTransform.anchoredPosition) == true)
            {
                _direction = Vector2.Reflect(_direction, Vector2.left);
                Debug.Log(_direction);
            }

            if (CheckFloorCollide(_rectTransform.anchoredPosition) == true)
                _direction = Vector2.Reflect(_direction, Vector2.down);

            currentLifeTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }

    private bool CheckWallsCollide(Vector2 position)
    {
        return (position.x <= 0 || position.x >= _canvasRectTransform.sizeDelta.x);
    }

    private bool CheckFloorCollide(Vector2 position)
    {
        return (position.y <= 0 || position.y >= _canvasRectTransform.sizeDelta.y);
    }
}
