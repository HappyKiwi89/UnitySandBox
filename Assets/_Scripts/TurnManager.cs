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
        // Spawn player at different positions depending on if you're Player 1 or 2
        Vector2 spawnPos = PhotonNetwork.IsMasterClient ? new Vector2(-2, 0) : new Vector2(2, 0);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);

        // Set turn based on who is Master Client (Player 1)
        isMyTurn = PhotonNetwork.IsMasterClient;
    }
}
