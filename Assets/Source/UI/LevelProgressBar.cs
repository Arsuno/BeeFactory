using DG.Tweening;
using TMPro;
using UnityEngine;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject _fillingObject;
    [SerializeField] private TMP_Text _barInfoLabel;
    [SerializeField] private ResourceSeller _resourceSeller;
    [SerializeField] private AccountLevelView _accountLevelView;
    [SerializeField] private AccountLevel _accountLevel;

    private Wallet _wallet;
    private float _progress = 0;

    private void Start()
    {
        _wallet.AmountChanged += OnAmountChanged;
        _accountLevel.Upgraded += OnLevelUpgraded;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= OnAmountChanged;
        _accountLevel.Upgraded -= OnLevelUpgraded;
    }

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnAmountChanged(float newWalletAmount)
    {
        if (_progress + _resourceSeller.AmountToWithdraw <= _accountLevel.LevelUpCost)
        {
            _progress += _resourceSeller.AmountToWithdraw;
            UpdateBar(_progress);
        }
        else if (_progress + _resourceSeller.AmountToWithdraw > _accountLevel.LevelUpCost)
        {
            _progress = _accountLevel.LevelUpCost;
            UpdateBar(_progress);
            _accountLevelView.EnableUpgradeButton();
        }
    }

    private void OnLevelUpgraded()
    {
        _accountLevelView.DisableUpgradeButton();
        _accountLevel.GetNewLevelUpCost();
        ResetProgress();
    }

    public void UpdateBar(float newAmount)
    {
        float x = _progress / _accountLevel.LevelUpCost;
        _fillingObject.transform.DOScaleX(x, 0.1f);
        _barInfoLabel.text = _progress.ToString() + " / " + _accountLevel.LevelUpCost.ToString();
    }

    public void ResetProgress()
    {
        _progress = 0;
        UpdateBar(_progress);
    }
}