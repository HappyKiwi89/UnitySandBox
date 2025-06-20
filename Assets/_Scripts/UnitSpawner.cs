using UnityEngine;
using Photon.Pun;

public class UnitSpawner : MonoBehaviourPun
{
    public GameObject soldierPrefab;
    public Transform spawnPoint; // Where to spawn the soldier

    public void SpawnSoldier()
    {
        if (!PhotonNetwork.IsConnected || !PhotonNetwork.InRoom)
            return;

        if (soldierPrefab != null && spawnPoint != null)
        {
            PhotonNetwork.Instantiate(soldierPrefab.name, spawnPoint.position, Quaternion.identity);
        }
    }
}
