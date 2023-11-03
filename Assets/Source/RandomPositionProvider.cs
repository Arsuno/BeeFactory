using System.Collections.Generic;
using UnityEngine;

public class RandomPositionProvider : MonoBehaviour, IPositionProvider
{
    [SerializeField] private List<Vector2> _targetPoints = new List<Vector2>();

    public Vector2 Position => GetWorldTargetPointPosition(Random.Range(0, _targetPoints.Count));

    private void OnValidate()
    {
        if (_targetPoints.Count <= 0)
            _targetPoints.Add(Vector2.zero);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < _targetPoints.Count; i++)
            Gizmos.DrawWireSphere(GetWorldTargetPointPosition(i), 0.1f);
    }

    private Vector2 GetWorldTargetPointPosition(int index)
    {
        return (Vector2)transform.position + _targetPoints[index];
    }
}