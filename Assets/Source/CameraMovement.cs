using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _upperBound;
    [SerializeField] private float _lowerBound;

    private Vector3 _startMousePosition;
    private bool _canMove = true;

    private void Update()
    {
        if (_canMove == true)
        {
            if (Input.GetMouseButtonDown(0))
                _startMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                Vector3 deltaPosition = GetMouseWorldPosition() - _startMousePosition;
                Vector3 targetPosition = _camera.transform.position - deltaPosition;
                targetPosition.x = 0;

                if (targetPosition.y > _upperBound)
                    targetPosition.y = _upperBound;
                else if (targetPosition.y < _lowerBound)
                    targetPosition.y = _lowerBound;

                _camera.transform.position = targetPosition;
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Freeze() => _canMove = false;
    public void Unfreeze() => _canMove = true;
}
