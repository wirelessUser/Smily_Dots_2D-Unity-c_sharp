using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameController : MonoBehaviour
{
    public static SingletonGameController instance;
    //.....................................
    public Vector2 ballStartPos;
    public float distanceFromCamera, lastYPosOfBall;
    public GameObject ballPlayer;

    public float ballTravelledDistance;
    //.........................
    public float timeToSpawnNewHudles = 5;
    public List<GameObject> HurdulesList = new List<GameObject>();

    public Transform spawnPoint;

     
    public List<GameObject> collectablesList = new List<GameObject>();
    //...............
    
    public List<GameObject> storeHurdulsList;
    //..............

    public GameObject winPanel;
    public int i = -1;
    public bool winBoolean = false;

    //.........

   
    Vector3 hurdleSpawnPos;
    private void Awake()
    {
        ballTravelledDistance = 0;
        CreateInstance();
      
        storeHurdulsList = new List<GameObject>();
    }
    void Start()
    {
        ballStartPos = ballPlayer.transform.position;
        distanceFromCamera = ballStartPos.y - Camera.main.transform.position.y ;
        lastYPosOfBall = ballStartPos.y;

        StartCoroutine(Collectables());
    }
    private void Update()
    {
        if (winBoolean == false)
            SpawnNewHurldes();
    }
    private void LateUpdate()
    {
        if(winBoolean== false)
        CameraMoveMentFucn();
    }
    void CreateInstance()
    {
        if (instance==null)
        {
            instance = this;
        }
    }



  public void BallDead()
    {
        DestroyHurldes();
       // ballStartPos.y = Camera.main.transform.position.y + distanceFromCamera;
      ballPlayer.transform.position = ballStartPos;
        ballPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (UIManager.instance.lives<0)
        {
            ballPlayer.GetComponent<Rigidbody2D>().isKinematic = true;

        }
    }


    public void CameraMoveMentFucn()
    {
        if (ballPlayer.transform.position.y<=Camera.main.transform.position.y)
        {
            Vector2 lerpFrom = Camera.main.transform.position;
            Vector2 lerpTo = new Vector3 (0, ballPlayer.transform.position.y-1,-10f);

            Vector2 moveCam = Vector3.Lerp(lerpFrom, lerpTo, 2 * Time.deltaTime);

            Camera.main.transform.position = new Vector3( 0,moveCam.y,-10f);
        }
    }

    public int RandomHurdleFromList()
    {
        int randomHurdle = Random.Range(0, HurdulesList.Count);
        return randomHurdle;

    }
    public void SpawnNewHurldes()
    {
        // differnce of the starting posion of ball and last psotion will get us the how much ball have tarveleld 
         ballTravelledDistance = lastYPosOfBall - ballPlayer.transform.position.y;
     //   Debug.Log($"ballTravelledDistance..{ballTravelledDistance}");
        if (ballTravelledDistance>=timeToSpawnNewHudles)
        {
          //  Debug.Log("Inside the if block..");
            lastYPosOfBall = ballPlayer.transform.position.y;
            ballTravelledDistance = 0;
             hurdleSpawnPos = spawnPoint.transform.position;
            GameObject instHurdule = Instantiate(HurdulesList[RandomHurdleFromList()] , spawnPoint.transform.position, Quaternion.identity);

            storeHurdulsList.Add(instHurdule);
        }
    }




    public void DestroyHurldes()
    {
        for (int i = storeHurdulsList.Count-1; i >= 0 ; i--)
        {
            Debug.Log("Deleting");
            Destroy(storeHurdulsList[i].gameObject);
            storeHurdulsList.RemoveAt(i);

        }
    }


    //..................


    IEnumerator Collectables()
    {
        yield return new WaitForSeconds(4);
     
        SpawnCollectables();
        
    }
    public void SpawnCollectables()
    {
        float pos = 0 ;

        pos = Random.Range(-2.4f, 2.4f);

        int randomNum = Random.Range(0, 100);
        int i = 0;
        if (randomNum <= 65)
        {
            i = Random.Range(0, 3);
        }
        else
        {
            i = Random.Range(4, 6);
        }
        Debug.Log($"value of i after random=={i}");
        GameObject collectables = Instantiate(collectablesList[i]);
        // How to instantiate a specifc gameObejct more frequently then others from a list.
        while (pos == hurdleSpawnPos.x || pos == hurdleSpawnPos.y)
        {
            print("...While loop  Executed...");
            pos = Random.Range(-2.4f, 2.4f);
        }
        Debug.Log("pos from while ==" + pos);
        collectables.transform.position = new Vector3(pos, spawnPoint.position.y, 0);
        storeHurdulsList.Add(collectables);
       
        StartCoroutine(Collectables());
    }

    public void WinPanelActivation()
    {
        winBoolean = true;
        winPanel.SetActive(true);
    }
}
