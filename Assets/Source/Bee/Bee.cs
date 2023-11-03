using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;

public class Bee : MonoBehaviour
{
    [SerializeField] private BeeMovement _beeMovement;
    [SerializeField] private int _amountOfResourcesToCollect;
    [SerializeField] private float _rorateDuration;

    private ResourceTransporter _beeToHouseTransporter;
    private ResourceTransporter _flowerbedToBeeTransporter;

    private Storage _storage;

    private IPositionProvider _hivePosition;
    private IPositionProvider _flowerbedPosition;

    private BeeResourceDistributor _distributor;
    
    public Storage Storage => _storage;
    public BeeMovement BeeMovement => _beeMovement;
    public event Action Delivered;

    public void Initialize(IPositionProvider hivePosition, 
        IPositionProvider flowerbedPosition, 
        Storage flowerbedStorage,
        Storage beeHouseStorage, 
        BeeResourceDistributor distributor, 
        Storage storage)
    {
        _hivePosition = hivePosition;
        _storage = storage;
        _flowerbedToBeeTransporter = new ResourceTransporter(flowerbedStorage, storage);
        _beeToHouseTransporter = new ResourceTransporter(storage, beeHouseStorage);
        _flowerbedPosition = flowerbedPosition;
        _distributor = distributor;
    }

    private void Start()
    {
        MoveToState(BeeState.MoveToFlowerbed);
    }

    private void MoveToState(BeeState state) 
    {
        switch (state)
        {
            case BeeState.MoveToHouse:
                {
                    _beeMovement.Move(_hivePosition.Position, () => MoveToState(BeeState.PutPollen));
                    break;
                }
            case BeeState.MoveToFlowerbed:
                {
                    _beeMovement.Move(_flowerbedPosition.Position, () =>
                    {
                        _distributor.AddBeeInQueue(gameObject);
                        MoveToState(BeeState.Wait);
                    });
                    break;
                }
            case BeeState.CollectPollen:
                {
                    _flowerbedToBeeTransporter.Transfer(_amountOfResourcesToCollect);
                    _distributor.RemoveBeeFromQueue();
                    transform.DORotate(new Vector3(0, 0, 180), _rorateDuration).OnComplete(() => MoveToState(BeeState.MoveToHouse));
                    break;
                }

            case BeeState.PutPollen:
                {
                    _beeToHouseTransporter.Transfer(_amountOfResourcesToCollect);
                    Delivered?.Invoke();
                    transform.DORotate(Vector3.zero, _rorateDuration).OnComplete(() => MoveToState(BeeState.MoveToFlowerbed));
                    break;
                }
            case BeeState.Wait:
                {
                    StartCoroutine(WaitForResources());
                    break;
                }
        }
    }

    private IEnumerator WaitForResources()
    {
        yield return new WaitUntil(() =>
            _flowerbedToBeeTransporter.CanTransfer(_amountOfResourcesToCollect) && _distributor.BeesQueue[0] == gameObject);

        MoveToState(BeeState.CollectPollen);
        StopCoroutine(WaitForResources());
    }
}