using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector2 teleportCoordinates = new Vector2(0f, 0f);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    void TeleportPlayer(GameObject player)
    {
        player.transform.position = new Vector3(teleportCoordinates.x, teleportCoordinates.y, player.transform.position.z);
    }
}
