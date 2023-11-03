using UnityEngine;

public class BeeFactory : MonoBehaviour
{
    [SerializeField] private Bee _beePrefab;
    [SerializeField] private FarmConfiguration _farmConfiguration;

    public Bee CreateBee(int farmIndex, 
        BeeResourceDistributor distributor, 
        IPositionProvider flowerbedPosition, 
        IPositionProvider beeHousePosition,
        Storage beeHouseStorage,
        Storage flowerbedStorage)
    {
        Sprite sprite = _farmConfiguration.Fields[farmIndex].BeeSprite;
        Bee bee = Instantiate(_beePrefab);
        Storage storage = new Storage(_farmConfiguration.Fields[farmIndex].BeeStorageCapacity);
        bee.Initialize(flowerbedPosition, beeHousePosition, flowerbedStorage, beeHouseStorage, distributor, storage);
        bee.GetComponent<SpriteRenderer>().sprite = sprite;
        return bee;
    }
}