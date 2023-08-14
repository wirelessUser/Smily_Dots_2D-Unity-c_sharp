using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LevelScript : MonoBehaviour
{

   // public Button button;
    public GameObject TaskPanel;
    private string LevelName;
    public Sprite[] taskEmojiImage= new Sprite[20];
    public Image mainTaskImage;


    
    public void TaskPanelButton( )
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);
        
    }
    public void LevelButton(string level)
    {
       

        mainTaskImage.sprite = taskEmojiImage[int.Parse(level.Substring(level.Length - 1, 1))-1];
        LevelName = level;
        TaskPanel.SetActive(true);

    }

    public void QuitTask()
    {
        if((int.Parse(LevelName.Substring(LevelName.Length - 1, 1)) - 1) == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            TaskPanel.SetActive(false);
        }
       
    }
}
