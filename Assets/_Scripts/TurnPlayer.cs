using UnityEngine;
using Photon.Pun;

public class TurnPlayer : MonoBehaviourPun
{
    public float moveSpeed = 3f;

    void Update()
    {
        // Only allow control if this is *your* player object AND it's your turn
        if (!photonView.IsMine || !TurnManager.isMyTurn) return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime);

        // Press space to end your turn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            photonView.RPC("EndTurn", RpcTarget.All);
        }
    }

    [PunRPC]
    void EndTurn()
    {
        TurnManager.isMyTurn = !TurnManager.isMyTurn;
    }
}
