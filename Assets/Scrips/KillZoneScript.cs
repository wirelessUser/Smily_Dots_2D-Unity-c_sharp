using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.instance.DecareseLives();
            SingletonGameController.instance.BallDead();
            print("Collided with player");
        }
    }
}
