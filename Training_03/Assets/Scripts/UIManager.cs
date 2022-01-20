using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager uIm;
    public EventSystem eventSystem;
    public GameObject mainCanvas;
    public Button playButton;
    public GameObject pauseMenu;

    private void Awake()
    {
        uIm = this;
    }
    void Start()
    {
        eventSystem.firstSelectedGameObject = null;
        eventSystem.firstSelectedGameObject = playButton.gameObject;
        Time.timeScale = 0;
    }

    public void Play()
    {
        mainCanvas.GetComponent<CanvasGroup>().alpha = 0;
        mainCanvas.GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        mainCanvas.GetComponent<CanvasGroup>().alpha = 0;
        mainCanvas.GetComponent<CanvasGroup>().interactable = false;
        GameManager.gm.player.isPause = false;
        Time.timeScale = 1;
    }
    
}
