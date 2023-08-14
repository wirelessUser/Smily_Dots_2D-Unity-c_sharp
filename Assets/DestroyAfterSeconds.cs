using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public Animator starAnimator;
    void Start()
    {
        
        Destroy(gameObject, 2);
    }

    

  
}
