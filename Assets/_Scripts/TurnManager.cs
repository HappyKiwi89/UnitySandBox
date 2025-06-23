using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public static bool isMyTurn { get; private set; }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Connect to Photon Cloud
    }

    public override void OnConnectedToMaster()
    {
        // Join or create a 2-player room
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        SetupCamera();

        if (PhotonNetwork.IsMasterClient)
        {
            isMyTurn = true;
        }
        else
        {
            isMyTurn = false;
        }

        AudioController.Instance.PlaySound("Soundtrack1");
    }

    private void SetupCamera()
    {
        Camera cam = Camera.main;

        if (PhotonNetwork.IsMasterClient)
        {
            cam.transform.position = new Vector3(-5f, 0f, -10f);  // Example position for player 1 view
        }
        else
        {
            cam.transform.position = new Vector3(5f, 0f, -10f);   // Example position for player 2 view
        }

        cam.orthographic = true;
        cam.orthographicSize = 5f;  // Adjust as needed for your battlefield size
    }
}

