using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uIm;
    public enum Menu { Title, Pause}
    public EventSystem eventSystem;
    public CanvasGroup titlePanel;
    public GameObject titleFirstSelected;
    public CanvasGroup pausePanel;
    public GameObject pauseFirstSelected;
    public CanvasGroup scoreDisplay;
    public GameOver gameOver;
    public Animator blackout;
    

    public AudioSource audioSource;

    private void Awake()
    {
        uIm = this;

    }
    void Start()
    {
        SetFirstSelected(Menu.Title);
        
    }

    public void Play()
    {
        titlePanel.alpha = 0;
        titlePanel.interactable = false;
        scoreDisplay.alpha = 1;
        StartCoroutine(GameManager.gm.player.Init());
        GameManager.gm.StartGame();
        GameManager.gm.player.isGameRunning = true;
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
        GameObject go = null;

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

    public void LoadGame()
    {
        CanvasGroup gameoverPanel = gameOver.gameObject.GetComponent<CanvasGroup>();
        gameoverPanel.alpha = 0;
        gameoverPanel.interactable = false;
        StartCoroutine(LoadCoroutine());
    }

    IEnumerator LoadCoroutine()
    {
        blackout.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(1);
    }
    
}
