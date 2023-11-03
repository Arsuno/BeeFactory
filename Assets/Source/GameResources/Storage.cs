using System;

public class Storage : IResourceStorage, IUpgradable
{
    public float Capacity => _capacity;
    public float ResourceAmount => _resourceAmount;

    private float _capacity;
    private float _resourceAmount;
    private float _upgradeMultiplier = 1.01f;

    public Storage(float capacity)
    {
        _capacity = capacity;
    }

    public bool CanAddResources(float amount)
    {
        return _resourceAmount + amount <= _capacity;
    }

    public bool CanRemoveResources(float amount)
    {
        return _resourceAmount - amount >= 0;
    }

    public void AddResources(float amount)
    {
        if (CanAddResources(amount) == true)
            _resourceAmount += amount;
        else
            throw new InvalidOperationException();
    }

    public void WithdrawResources(float amount)
    {
        if (CanRemoveResources(amount) == true)
            _resourceAmount -= amount;
        else
            throw new InvalidOperationException();
    }

    public void Upgrade()
    {
        _capacity *= _upgradeMultiplier;
    }
}
