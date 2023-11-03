using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void Start()
    {
        _wallet.AmountChanged += OnAmountChanged;
    }

    private void OnDestroy()
    {
        _wallet.AmountChanged -= OnAmountChanged;        
    }

    private void OnAmountChanged(float amount)
    {
        _label.text = amount.ToString();
    }
}
