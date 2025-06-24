using UnityEngine;
using Photon.Pun;

public class UnitStats : MonoBehaviourPun
{
    // Unique stats set per prefab in the inspector
    public int health;
    public float speed;
    public int damage;

    void Start()
    {
        // You could log stats or initialize if needed
        Debug.Log($"{gameObject.name} spawned with {health} health, {speed} speed, {damage} damage");
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
}
