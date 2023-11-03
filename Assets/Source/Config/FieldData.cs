using System;
using UnityEngine;

[Serializable]
public class FieldData
{
    [SerializeField] private Sprite _beeSprite;
    [SerializeField] private Sprite _beeHouseSprite;
    [SerializeField] private Sprite _flowerbedSprite;
    [SerializeField] private int _maxLevel;
    [SerializeField] private int _beeHouseStorageCapacity;
    [SerializeField] private int _beeStorageCapacity;
    [SerializeField] private int _flowerbedStorageCapacity;

    public Sprite BeeSprite => _beeSprite;
    public Sprite BeeHouseSprite => _beeHouseSprite;
    public Sprite FlowerBedSprite => _flowerbedSprite;
    public int MaxLevel => _maxLevel;
    public int BeeHouseStorageCapacity => _beeHouseStorageCapacity;
    public int BeeStorageCapacity => _beeStorageCapacity;
    public int FlowerbedStorageCapacity => _flowerbedStorageCapacity;
}
