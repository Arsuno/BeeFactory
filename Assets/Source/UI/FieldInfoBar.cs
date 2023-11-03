using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldInfoBar : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text _labelBeesAmount;
    [SerializeField] private TMP_Text _labelFarmProductive;
    [SerializeField] private Button _purchaseButton;
    [SerializeField] private Button _upgradeButton;

    private OverlayWindow _confirmPurchaseWindow;
    private OverlayWindow _confirmUpgradeWindow;
    private Field _field;

    public void Initialize(Field field, OverlayWindow confirmPurchaseWindow, OverlayWindow confirmUpgradeWindow)
    {
        _field = field;
        _confirmPurchaseWindow = confirmPurchaseWindow;
        _confirmUpgradeWindow = confirmUpgradeWindow;
    }

    private void Start()
    {
        _purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
    }


    private void OnDisable()
    {
        _purchaseButton.onClick.RemoveListener(OnPurchaseButtonClicked);
        _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);
    }

    private void OnPurchaseButtonClicked()
    {
        _confirmPurchaseWindow.Open(OnPurchaseConfirmed);
    }

    private void OnPurchaseConfirmed()
    {
        _field.SpawnBee();
        UpdateInfo();
        _purchaseButton.gameObject.SetActive(false);
        _upgradeButton.gameObject.SetActive(true);
    }

    private void OnUpgradeButtonClicked()
    {
        _confirmUpgradeWindow.Open(OnUpgradeConfirmed); 
    }

    private void OnUpgradeConfirmed()
    {
        _field.Upgrade();
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        UpdateBeesAmountLabel();
        UpdateProductivityLabel();
    }

    private void UpdateBeesAmountLabel()
    {
        _labelBeesAmount.text = "Bees: " + _field.BeesAmount + "/" + _field.MaxBeesAmount;
    }

    private void UpdateProductivityLabel()
    {
        _labelFarmProductive.text = _field.GetFieldProductivity().ToString() + " /s";
    }
}