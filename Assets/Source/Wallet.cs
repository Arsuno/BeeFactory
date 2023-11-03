using System;

public class Wallet
{
    public float Amount { get ; private set; }
    public event Action<float> AmountChanged;

    public Wallet(float amount)
    {
        Amount = amount;
    }

    public void Add(float amount)
    {
        Amount += amount;
        AmountChanged?.Invoke(Amount);
    }
}
