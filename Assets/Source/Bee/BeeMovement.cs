using DG.Tweening;
using System;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    public float Speed => _movementSpeed;
    [SerializeField] private float _movementSpeed = 3f;

    public void Move(Vector2 target, Action onCompleted)
    {
        transform.DOMove(target, _movementSpeed).OnComplete(() => onCompleted?.Invoke());
    }
}
