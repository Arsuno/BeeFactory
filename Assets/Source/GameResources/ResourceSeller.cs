using System;
using UnityEngine;

public class ResourceSeller : MonoBehaviour
{
    public event Action SellReady;
    public float Price => _price;
    public Storage Storage => _storage;
    public float AmountToWithdraw => _amountToWithdraw;

    [SerializeField] private float _amountToWithdraw;

    private float _price = 1f;
    private Storage _storage;
    private Wallet _wallet;
    private bool _canSell = true;

    public void Initialize(Storage storage, Wallet wallet)
    {
        _storage = storage;
        _wallet = wallet;
    }

    private void Update()
    {
        if (_storage.CanRemoveResources(_amountToWithdraw) == true && _canSell == true)
        {
            _canSell = false;
            SellReady?.Invoke();
        }
    }

    public void UploadResources()
    {
        _storage.WithdrawResources(_amountToWithdraw);
    }

    public void SellResources()
    {
        _wallet.Add(_amountToWithdraw * _price);
        _canSell = true;
    }
}
