using UnityEngine;

public class ResourceTransporter
{
    public Storage WithdrawStorage => _withdrawStorage;
    public Storage ReceiveStorage => _receiveStorage;
    //private float _transferSpeed;
    private readonly Storage _withdrawStorage;
    private readonly Storage _receiveStorage;

    public ResourceTransporter(Storage withdrawStorage, Storage receiveStorage)
    {
        //_transferSpeed = transferSpeed;
        _withdrawStorage = withdrawStorage;
        _receiveStorage = receiveStorage;
    }

    public void Transfer(float amount)
    {
        _withdrawStorage.WithdrawResources(amount);
        _receiveStorage.AddResources(amount);
    }

    public bool CanTransfer(float amount)
    {
        return _withdrawStorage.ResourceAmount >= amount;
    } 
}
