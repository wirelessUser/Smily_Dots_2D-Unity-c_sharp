using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPenExperimental : MonoBehaviour
{
    public GameObject nibPrefab;
    public Vector2 nibPos, lastNibPos;

    public bool isDrawing;
    //public Transform parentFullShape;
    public List<GameObject> nibsList;

    public GameObject parent;

    public Transform MousePOinterShapeCollider;

    public bool mouseisupNewPos;

    //............ref..............
    public mousePointerCollider mousePointerRef;
    private void Update()
    {
        NewMousePos();
        TakeInputDrawNibObj();

    }

    public void NewMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseisupNewPos = true;
            //parent = Instantiate(parentPrefab, transform.position, Quaternion.identity);
            ////parent.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
    public void TakeInputDrawNibObj()
    {
        if (Input.GetMouseButton(0)&& SingletonGameController.instance.winBoolean== false)
        {

            //............

            //Collider2D[] dotCollider= MousePOinterShapeCollider.
            //....................

            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            nibPos = Camera.main.ScreenToWorldPoint(mousePos);

            //if (isDrawing && mousePointerCollider.collidePointerMouse[0] == null && mouseisupNewPos == true)
            //{
            //    float distance = Vector2.Distance(nibPos, lastNibPos);
            //    print($"distance{distance}");
            //    if (distance > 0.1f)
            //    {
            //        int segments = Mathf.FloorToInt(distance / 0.04f);
            //        print($"segments{segments}");

            //        for (int i = 0; i < segments; i++)
            //        {
            //            Vector2 intermediatePos = Vector2.Lerp(lastNibPos, nibPos, (1f / segments) * i);
            //            GameObject instNib = Instantiate(nibPrefab, intermediatePos, Quaternion.identity);
            //        }
            //    }
            //}
            //if (isDrawing  )
            //{
               GameObject currentNib = Instantiate(nibPrefab, nibPos, Quaternion.identity);
            nibsList.Add(currentNib);
            lastNibPos = nibPos;

            isDrawing = true;

        //}


        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseisupNewPos = false;

            //parent.GetComponent<Rigidbody2D>().isKinematic = false;
            //foreach (GameObject dot in nibsList)
            //{
            //    dot.GetComponent<Rigidbody2D>().isKinematic = false;
            //}

        }

    }



    
}
