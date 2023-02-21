using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public GameObject[] levels;
    public Button[] buttons;
    public Image disableButton;
    public EventTrigger[] events;
    int levelbuttons=16;
    int levelcount=0;



    private void Start()
    {
        int currentIndex = Random.Range(0, levels.Length);
        foreach (var item in levels)
        {
            item.SetActive(false);
        }
        levels[currentIndex].SetActive(true);
    }


    public void OnLevelClick(int click)
    {
       
        buttons[click].image.sprite = disableButton.sprite;
        buttons[click].enabled = false;
        events[click].enabled = false;
        
        levelcount++;
        if (levelcount == levelbuttons)
        {
            StartCoroutine(NextLevel());
        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}


