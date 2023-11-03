using DG.Tweening;
using UnityEngine;

public class ResourceSellerView : MonoBehaviour
{
    [SerializeField] private RectTransform _carRectTransform;
    [SerializeField] private RectTransform _warehouseRectTransform;
    [SerializeField] private Vector3 _targetPoint;
    [SerializeField] private float _carSpeed;
    [SerializeField] private ResourceSeller _resourceSeller;

    private void OnEnable()
    {
        _resourceSeller.SellReady += PlayCarAnimation;
    }

    private void OnDisable()
    {
        _resourceSeller.SellReady -= PlayCarAnimation;
    }

    private void PlayCarAnimation()
    {
        ResetCarPosition();
        _resourceSeller.UploadResources();
        _carRectTransform.gameObject.SetActive(true);
        _carRectTransform.DOAnchorPos(_targetPoint, _carSpeed).OnComplete(PlaySellAnimation);
    }

    private void PlaySellAnimation()
    {
        _resourceSeller.SellResources();
        _carRectTransform.gameObject.SetActive(false);
        ResetCarPosition();
    }

    private void ResetCarPosition()
    {
        _carRectTransform.anchoredPosition = _warehouseRectTransform.anchoredPosition;
    }
}
