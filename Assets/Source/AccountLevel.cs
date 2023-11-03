using System;
using UnityEngine;

public class AccountLevel : MonoBehaviour, IUpgradable
{
    public int CurrentLevel { get; private set; }
    public float LevelUpCost { get; private set; } = 3500;

    private float _levelUpCostMultiplier = 1.4f;

    public event Action Upgraded;

    public void Upgrade()
    {
        CurrentLevel++;
        Upgraded?.Invoke();
    }

    public float GetNewLevelUpCost() => LevelUpCost *= _levelUpCostMultiplier;
    
}
