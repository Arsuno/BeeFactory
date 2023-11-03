using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountLevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Button _button;
    [SerializeField] private AccountLevel _accountLevel;

    private void OnEnable()
    {
        _button.onClick.AddListener(_accountLevel.Upgrade);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_accountLevel.Upgrade);
    }

    public void UpdateLabel()
    {
        _label.text = "Level" + _accountLevel.CurrentLevel.ToString();
    }
    
    public void DisableUpgradeButton()
    {
        _button.interactable = false;
    }

    public void EnableUpgradeButton()
    {
        _button.interactable = true;
    }
}