using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassZone : MonoBehaviour
{
    public bool isPassed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPassed==false)
        {
            UIManager.instance.AddScore();
            //print("Collided with player");
            isPassed = true;
        }
    }
}
