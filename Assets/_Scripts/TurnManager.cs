using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public static bool isMyTurn = false;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Connect to Photon Cloud
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
    {
        // Spawn Player 1's fort on left
        //PhotonNetwork.Instantiate("FortPlayer1", new Vector2(-7, -3), Quaternion.identity);
        // Spawn Player 1's player prefab as before
        PhotonNetwork.Instantiate("Player1", new Vector2(-2, 0), Quaternion.identity);
    }
    else
    {
        // Spawn Player 2's fort on right
        //PhotonNetwork.Instantiate("FortPlayer2", new Vector2(7, -3), Quaternion.identity);
        // Spawn Player 2's player prefab as before
        PhotonNetwork.Instantiate("Player2", new Vector2(2, 0), Quaternion.identity);
    }
        string prefabToSpawn = PhotonNetwork.IsMasterClient ? "Player1" : "Player2";
        Vector2 spawnPos = PhotonNetwork.IsMasterClient ? new Vector2(-2, 0) : new Vector2(2, 0);

        PhotonNetwork.Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

        TurnManager.isMyTurn = PhotonNetwork.IsMasterClient;
    }
}
