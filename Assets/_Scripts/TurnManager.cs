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


    void SetupCamera()
    {
        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();

        if (PhotonNetwork.IsMasterClient)
        {
            camFollow.target = GameObject.Find("Player1View").transform;
        }
        else
        {
            camFollow.target = GameObject.Find("Player2View").transform;
        }

        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 5f; // Adjust as needed
    }

}

