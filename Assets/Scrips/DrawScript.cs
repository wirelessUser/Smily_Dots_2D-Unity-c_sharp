using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour
{
    public GameObject nibPrefab;
    public Vector2 nibPos;

    public bool isDrawing;

    public Transform parentFullShape;
   // public Collider2D[] circleDetection;
    private GameObject instNib;
    public List<GameObject> nibsList;
    void Start()
    {
       // print($"nibPrefab.transform.GetComponent<CircleCollider2D>().radius{nibPrefab.transform.GetComponent<CircleCollider2D>().radius}");
       
    }

    // Update is called once per frame
    void Update()
    {
        TakeInputDrawNipObj();
       // print($"Input.mousePosition{Input.mousePosition}");
    }


    public void TakeInputDrawNipObj()
    {
        if (Input.GetMouseButton(0))
        {
            //circleDetection = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f);

           
                isDrawing = true;
                Vector2 mosuePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                nibPos = Camera.main.ScreenToWorldPoint(mosuePos);

                 instNib = Instantiate(nibPrefab, nibPos, Quaternion.identity,parentFullShape);
            nibsList.Add(instNib);

        }//.........


        //if (Input.GetMouseButtonUp(0))
        //{
        //    foreach (GameObject dot in nibsList)
        //    {
        //        dot.GetComponent<Rigidbody2D>().isKinematic = false;
        //    }

        //}



    }


}//Class........
