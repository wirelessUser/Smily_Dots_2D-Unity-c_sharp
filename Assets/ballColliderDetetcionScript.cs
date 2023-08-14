using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballColliderDetetcionScript : MonoBehaviour
{
    public int CompletionCount;
    public GameObject  eyeLeft_Angry, eyeLeft_Smile, eyeRight_Angry , eyeRight_Smile;
    public GameObject Mouth_Sad, Mouth_Happy, MouthSquiggly, MouthVommit;
    public bool value;
    public GameObject StarPrefab1, StarPrefab2;
    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(191f, 153f, 0f);//191,153,0
    }
    private void Update()
    {
        if (eyeLeft_Smile.GetComponent<SpriteRenderer>().enabled && eyeRight_Smile.GetComponent<SpriteRenderer>().enabled&&
            Mouth_Happy.GetComponent<SpriteRenderer>().enabled)
        {
            SingletonGameController.instance.WinPanelActivation();
        }
    }
    public void DeativateEyes(string right)
    {
        
        if (right=="right")
        {
            eyeRight_Angry.GetComponent<SpriteRenderer>().enabled = false;
            eyeRight_Smile.GetComponent<SpriteRenderer>().enabled = false;
            //eyeRight_Angry.SetActive(false);
            //eyeRight_Smile.SetActive(false);
        }
        if (right == "left")
        {
            eyeLeft_Angry.GetComponent<SpriteRenderer>().enabled = false;
            eyeLeft_Smile.GetComponent<SpriteRenderer>().enabled = false;
            //eyeLeft_Angry.SetActive(false);
            //eyeLeft_Smile.SetActive(false);
        }
       
       
    }
    public void DeativateMouths()
    {
        Mouth_Sad.GetComponent<SpriteRenderer>().enabled = false;
        Mouth_Happy.GetComponent<SpriteRenderer>().enabled = false;
        MouthSquiggly.GetComponent<SpriteRenderer>().enabled = false;
        MouthVommit.GetComponent<SpriteRenderer>().enabled = false;
        //Mouth_Sad.SetActive(false);
        //Mouth_Happy.SetActive(false);
        //MouthSquiggly.SetActive(false);
        //MouthVommit.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       
        if (collision.gameObject.tag== "eyeLeft_Angry")
        {
            DeativateEyes("left");
            collision.gameObject.SetActive(false); 
            transform.GetChild(0).GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(StarPrefab1, collision.gameObject.transform.position, Quaternion.identity);
            StartCoroutine(ColorChange());
          
        }

        if (collision.gameObject.tag == "eyeLeft_Smile")
        {
            DeativateEyes("left");
            collision.gameObject.SetActive(false);
            transform.GetChild(0).GetChild(1).transform.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(StarPrefab1, collision.gameObject.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "eyeRight_Angry")
        {
            DeativateEyes("right");
            collision.gameObject.SetActive(false);
            transform.GetChild(0).GetChild(2).transform.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(StarPrefab2, collision.gameObject.transform.position, Quaternion.identity);
            StartCoroutine(ColorChange());
        }

        if (collision.gameObject.tag == "eyeRight_Smile")
        {
            DeativateEyes("right");
            collision.gameObject.SetActive(false);
            transform.GetChild(0).GetChild(3).transform.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(StarPrefab1, collision.gameObject.transform.position, Quaternion.identity);
        }


        if (collision.gameObject.tag == "Mouth_Sad")
        {
            DeativateMouths();
            collision.gameObject.SetActive(false);
            transform.GetChild(1).GetChild(0).transform.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(StarPrefab2, collision.gameObject.transform.position, Quaternion.identity);
            StartCoroutine(ColorChange());
        }


        if (collision.gameObject.tag == "Mouth_Happy")
        {
            DeativateMouths();
            collision.gameObject.SetActive(false);
            transform.GetChild(1).GetChild(1).transform.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(StarPrefab1, collision.gameObject.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "MouthSquiggly")
        {
            DeativateMouths();
            collision.gameObject.SetActive(false);
            transform.GetChild(1).GetChild(2).transform.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(StarPrefab2, collision.gameObject.transform.position, Quaternion.identity);
            StartCoroutine(ColorChange());
        }
        if (collision.gameObject.tag == "MouthVommit")
        {
            DeativateMouths();
            collision.gameObject.SetActive(false);
            transform.GetChild(1).GetChild(3).transform.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(StarPrefab2, collision.gameObject.transform.position, Quaternion.identity);
            StartCoroutine(ColorChange());
        }



       
    }


  


    IEnumerator ColorChange()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<SpriteRenderer>().color = new Color (253f,202f,0f);//191,153,0

    }




}//class......
