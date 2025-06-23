using UnityEngine;
using Photon.Pun;
using TMPro;  // if using TextMeshPro for gold display

public class PlayerGold : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI goldText;  // Reference to your gold UI text
    private int goldAmount = 0;

    void Start()
    {
        if (!photonView.IsMine)
        {
            // Disable or hide gold UI on other players' instances
            goldText.gameObject.SetActive(false);
        }
        else
        {
            // Initialize gold display for local player
            UpdateGoldUI();
        }
    }

    public void AddGold(int amount)
    {
        if (!photonView.IsMine) return;  // Only local player updates their gold

        goldAmount += amount;
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        goldText.text = "Gold: " + goldAmount;
    }
}
