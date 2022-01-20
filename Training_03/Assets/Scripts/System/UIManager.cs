using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager uIm;
    public enum Menu { Title, Pause}
    public EventSystem eventSystem;
    public CanvasGroup titlePanel;
    public GameObject titleFirstSelected;
    public CanvasGroup pausePanel;
    public GameObject pauseFirstSelected;
    

    public AudioSource audioSource;

    private void Awake()
    {
        uIm = this;

    }
    void Start()
    {
        SetFirstSelected(Menu.Title);
        Time.timeScale = 0;
    }

    public void Play()
    {
        titlePanel.alpha = 0;
        titlePanel.interactable = false;
        Time.timeScale = 1;
    }

    public void OnQuit()
    {
        StartCoroutine(Quit());
    }


    public IEnumerator Quit()
    {
        yield return new WaitForSecondsRealtime(audioSource.clip.length);
        
        Application.Quit();
    }
    public void Resume()
    {
        pausePanel.alpha = 0;
        pausePanel.interactable = false;
        GameManager.gm.player.isPause = false;
        Time.timeScale = 1;
    }

    public void SetFirstSelected(Menu _menu)
    {
        GameObject go = new GameObject();

        switch (_menu)
        {
            case Menu.Title:
                go = titleFirstSelected;
                break;
            case Menu.Pause:
                go = pauseFirstSelected;
                break;
            default:
                break;
        }

        eventSystem.SetSelectedGameObject(go);
        
    }
    
}
