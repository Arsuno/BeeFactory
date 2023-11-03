using UnityEngine;

public class FieldFactory : MonoBehaviour
{
    [SerializeField] private Field _fieldPrefab;
    [SerializeField] private FarmConfiguration _configuration;
    [SerializeField] private ResourceSeller _resourceSeller;
    [SerializeField] private OverlayWindow _confirmPurchaseWindow;
    [SerializeField] private OverlayWindow _confirmUpgradeWindow;
    [SerializeField] private Vector3 _spawnOffset;

    private Vector3 _lastSpawnedFieldPosition;

    public FarmConfiguration Configuration => _configuration;

    private void Awake()
    {
        _lastSpawnedFieldPosition = _fieldPrefab.transform.position;
    }

    public Field Create(int index)
    {
        Storage beeHouseStorage = new Storage(_configuration.Fields[index].BeeHouseStorageCapacity);
        Storage flowerbedStorage = new Storage(_configuration.Fields[index].FlowerbedStorageCapacity);

        Field field = Instantiate(_fieldPrefab, _lastSpawnedFieldPosition + _spawnOffset, Quaternion.identity);

        _lastSpawnedFieldPosition = field.transform.position;
        field.Initialize(
            _configuration.Fields[index].MaxLevel,
            beeHouseStorage,
            flowerbedStorage,
            new BeeResourceDistributor(),
            _resourceSeller,
            new ResourceTransporter(beeHouseStorage, _resourceSeller.Storage),
            _configuration.Fields[index].BeeHouseSprite,
            _configuration.Fields[index].FlowerBedSprite);

        Canvas canvas = field.gameObject.GetComponentInChildren<Canvas>();
        FieldInfoBar fieldInfoBar = canvas.gameObject.GetComponentInChildren<FieldInfoBar>();
        fieldInfoBar.Initialize(field, _confirmPurchaseWindow, _confirmUpgradeWindow);
        return field;
    }
}