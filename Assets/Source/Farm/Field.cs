using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour, IUpgradable
{
    private readonly List<Bee> _bees = new List<Bee>();

    [SerializeField] private StorageRegenerator _regenerator;

    [SerializeField] private RandomPositionProvider _beeHousePosition;
    [SerializeField] private RandomPositionProvider _flowerbedPosition;
    [SerializeField] private BeeFactory _beeFactory;
    [SerializeField] private SpriteRenderer _beeHouseRenderer;
    [SerializeField] private SpriteRenderer _flowerbedRenderer;

    private float _amountToTransfer = 1000;
    private int _currentLevel = 1;
    private Storage _beeHouseStorage;
    private Storage _flowerbedStorage;
    private BeeResourceDistributor _distributor;
    private ResourceSeller _resourceSeller;
    private ResourceTransporter _beeHouseToWarehouseTransporter;

    public int BeesAmount { get => _bees.Count; }
    public int MaxBeesAmount { get => _maxLevel; }

    private int _maxLevel;

    public void Initialize(int maxLevel,
        Storage beeHouseStorage,
        Storage flowerbedStorage,
        BeeResourceDistributor distributor, 
        ResourceSeller resourceSeller, 
        ResourceTransporter beeHouseToWarehouseTransporter,
        Sprite beeHouseSprite,
        Sprite flowerbedSprite)
    {
        _maxLevel = maxLevel;
        _beeHouseStorage = beeHouseStorage;
        _flowerbedStorage = flowerbedStorage;
        _regenerator.Initialize(_flowerbedStorage);
        _distributor = distributor;
        _resourceSeller = resourceSeller;
        _beeHouseToWarehouseTransporter = beeHouseToWarehouseTransporter;
        _beeHouseRenderer.sprite = beeHouseSprite;
        _flowerbedRenderer.sprite = flowerbedSprite;
    }

    private void Update()
    {
        if (_beeHouseStorage.ResourceAmount >= _amountToTransfer)
            _beeHouseToWarehouseTransporter.Transfer(_amountToTransfer);
    }

    public void SpawnBee()
    {
        Bee bee = _beeFactory.CreateBee(0, _distributor, _flowerbedPosition, _beeHousePosition, _beeHouseStorage, _flowerbedStorage);
        _bees.Add(bee);
    }

    public void Upgrade()
    {
        if (CanBeUpgraded())
        {
            SpawnBee();
            _beeHouseStorage.Upgrade();
            _flowerbedStorage.Upgrade();
        
            foreach (var bee in _bees)
                bee.Storage.Upgrade();

            _currentLevel++;
        }
    }

    public float GetFieldProductivity()
    {
        float pollenPerSecond = _bees[0].Storage.Capacity / _bees[0].BeeMovement.Speed;
        float moneyPerSecond = ((pollenPerSecond * _bees.Count) * _resourceSeller.Price);
        return moneyPerSecond;
    }

    private bool CanBeUpgraded() => _currentLevel < _maxLevel;
}