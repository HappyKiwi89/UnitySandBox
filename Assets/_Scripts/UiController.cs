using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    private int gold = 100;

    [SerializeField] private UnitSpawner unitSpawner;

    private void Start()
    {
        UpdateGoldUI();
    }

    public void BuyUnitButtonPressed()
    {
        if (TrySpendGold(50))
        {
            Debug.Log("Unit bought!");
            unitSpawner.BuyUnit();  // spawn unit via Photon here
        }
    }

    public bool TrySpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateGoldUI();
            return true;
        }
        else
        {
            Debug.Log("Not enough gold");
            return false;
        }
    }

    private void UpdateGoldUI()
    {
        goldText.text = "Gold: " + gold;
    }
}
