using UnityEngine;
using Photon.Pun;

public class UnitSpawner : MonoBehaviourPun
{
    [SerializeField] private UiController uiController;
    [SerializeField] private string rechidPrefabName = "RechidPrefab";  // Name of the prefab in Resources
    [SerializeField] private Transform Player1UnitSpawn;  // For MasterClient
    [SerializeField] private Transform Player2UnitSpawn;  // For second player

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
            return Player1UnitSpawn.position;
        }
        else
        {
            return Player2UnitSpawn.position;
        }
    }
}
