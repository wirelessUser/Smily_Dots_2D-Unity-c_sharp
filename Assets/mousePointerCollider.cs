using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePointerCollider : MonoBehaviour
{
    public Collision2D[] collidePointerMouse = new Collision2D[5];


    private   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dots")
        {
            collidePointerMouse[0] = collision;
        }
    }


    private void Update()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        Vector3 temp = transform.position;
        temp.z = 6;
        transform.position = temp;

        //Debug.Log($"transform.position == {transform.position},Camera.main.ScreenToWorldPoint( Input.mousePosition) == {Camera.main.ScreenToWorldPoint(Input.mousePosition)} ");
    }
}
