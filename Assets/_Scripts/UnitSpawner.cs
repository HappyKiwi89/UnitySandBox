using UnityEngine;
using Photon.Pun;

public class UnitSpawner : MonoBehaviourPun
{
    [SerializeField] private UiController uiController;
    [SerializeField] private string rechidPrefabName = "RechidPrefab";  // Name of the prefab in Resources
    [SerializeField] private Transform spawnPointPlayer1;  // For MasterClient
    [SerializeField] private Transform spawnPointPlayer2;  // For second player

    public void BuyUnit()
    {
        if (uiController.TrySpendGold(50))
        {
            Vector3 spawnPos = GetSpawnPosition();
            PhotonNetwork.Instantiate(rechidPrefabName, spawnPos, Quaternion.identity);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            return spawnPointPlayer1.position;
        }
        else
        {
            return spawnPointPlayer2.position;
        }
    }
}
