using System;
using UnityEngine;
using UnityEngine.UI;

public class OverlayWindow : MonoBehaviour
{
    [SerializeField] private Button _confirmButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private GameObject _fade;
    [SerializeField] private CameraMovement _cameraMovement;

    private Action _confirmed;

    private void OnEnable()
    {
        _confirmButton.onClick.AddListener(OnConfirmButtonClicked);
        _cancelButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _confirmButton.onClick.RemoveListener(OnConfirmButtonClicked);
        _cancelButton.onClick.RemoveListener(Close);
    }

    public void Open(Action onConfirmed)
    {
        _cameraMovement.Freeze();
        _confirmed = onConfirmed;
        gameObject.SetActive(true);
        _fade.SetActive(true);
    }

    public void Close()
    {
        _cameraMovement.Unfreeze();
        gameObject.SetActive(false);
        _fade.SetActive(false);
        _confirmed = null;
    }

    private void OnConfirmButtonClicked()
    {
        _confirmed?.Invoke();
        Close();
    }
}