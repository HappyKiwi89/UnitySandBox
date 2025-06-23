using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    private int gold = 100; // starting gold

    private void Start()
    {
        UpdateGoldText();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldText();
    }

    public bool TrySpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateGoldText();
            return true;
        }
        else
        {
            // optionally show error or disable button
            return false;
        }
    }

    private void UpdateGoldText()
    {
        goldText.text = $"Gold: {gold}";
    }
    public void BuySkelly()
    {
        gold -= 20;
        UpdateGoldText();
    }
}
