using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarehouseView : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _upgradeButtonLabel;
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private TMP_Text _storageLabel;

    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
    }

    private void OnDisable()
    {
        _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);
    }

    private void Update()
    {
        _storageLabel.text = _warehouse.Storage.ResourceAmount.ToString();
    }

    private void OnUpgradeButtonClicked()
    {
        _warehouse.Upgrade();
        _upgradeButtonLabel.text = "Level " + _warehouse.CurrentLevel.ToString();
    }
}
