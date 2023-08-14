using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour
{
    public GameObject nibPrefab;
    public Vector2 nibPos;

    public bool isDrawing;

    public Transform parentFullShape;

    private GameObject instNib;
    public List<GameObject> nibsList;
 

    // Update is called once per frame
    void Update()
    {
        TakeInputDrawNipObj();
    
    }


    public void TakeInputDrawNipObj()
    {
        if (Input.GetMouseButton(0))
        {
           

           
                isDrawing = true;
                Vector2 mosuePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                nibPos = Camera.main.ScreenToWorldPoint(mosuePos);

                 instNib = Instantiate(nibPrefab, nibPos, Quaternion.identity,parentFullShape);
            nibsList.Add(instNib);

        }//.........





    }


}//Class........
