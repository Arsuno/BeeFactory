using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private ResourceSeller _resourceSeller;
    [SerializeField] private WalletView _walletView;
    [SerializeField] private LevelProgressBar _levelProgressBar;
    [SerializeField] private Warehouse _warehouse;

    private void Awake()
    {
        Wallet wallet = new Wallet(0);
        Storage warehouseStorage = new Storage(5000);
        _warehouse.Initialize(warehouseStorage);
        _resourceSeller.Initialize(warehouseStorage, wallet);
        _walletView.Initialize(wallet);
        _levelProgressBar.Initialize(wallet);
    }
}
