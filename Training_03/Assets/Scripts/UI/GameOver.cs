using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    int score;
    int isBestScore;
    public List<Image> stars;
    public TextMeshProUGUI message;
    public CanvasGroup canvasGroup;

    public TextMeshProUGUI best1;
    public int best1Default;
    public TextMeshProUGUI best2;
    public int best2Default;
    public TextMeshProUGUI best3;
    public int best3Default;

    public GameObject firstSelected;

    public List<Color> colors;


    public void Init()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);

        foreach (Image item in stars)
            item.gameObject.SetActive(false);

        score = GameManager.gm.score;
        scoreDisplay.text = score.ToString();
        CheckBestScore();

        best1.text = PlayerPrefs.GetInt("best1", best1Default).ToString();
        best2.text = PlayerPrefs.GetInt("best2", best3Default).ToString();
        best3.text = PlayerPrefs.GetInt("best3", best3Default).ToString();

        best1.gameObject.GetComponent<Animator>().SetBool("_isSelected", false);
        best2.gameObject.GetComponent<Animator>().SetBool("_isSelected", false);
        best2.gameObject.GetComponent<Animator>().SetBool("_isSelected", false);

        if (isBestScore > 0)
        {
            foreach (Image item in stars)
                item.gameObject.SetActive(true);
            //Call Score Bounce Anim
            //Call Message Bounce Anim

        }

        switch (isBestScore)
        {
            case 1:
                foreach (Image item in stars)
                    item.color = colors[0];
                message.color = colors[0];
                best1.gameObject.GetComponent<Animator>().SetBool("_isSelected", true);
                break;

            case 2 :
                foreach (Image item in stars)
                    item.color = colors[1];
                message.color = colors[1];
                best2.gameObject.GetComponent<Animator>().SetBool("_isSelected", true);
                break;

            case 3:
                foreach (Image item in stars)
                    item.color = colors[2];
                message.color = colors[2];
                best3.gameObject.GetComponent<Animator>().SetBool("_isSelected", true);
                break;

            default:
                break;
        }




        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    public void CheckBestScore()
    {
        if(score >= PlayerPrefs.GetInt("best1", best1Default))
        {
            PlayerPrefs.SetInt("best3", PlayerPrefs.GetInt("best2",best2Default));
            PlayerPrefs.SetInt("best2", PlayerPrefs.GetInt("best1",best2Default));
            PlayerPrefs.SetInt("best1", score);
            message.text = "New Best Score";
            isBestScore = 1;
        }
        else if (score >= PlayerPrefs.GetInt("best2", best2Default))
        {
            PlayerPrefs.SetInt("best3", PlayerPrefs.GetInt("best2",best2Default));
            PlayerPrefs.SetInt("best2", score);
            message.text = "New High Score";
            isBestScore = 2;
        }
        else if (score >= PlayerPrefs.GetInt("best3",best3Default))
        {
            PlayerPrefs.SetInt("best3", score);
            message.text = "New High Score";
            isBestScore = 3;
        }
        else
        {
            message.text = "";
            isBestScore = 0;
        }
    }


    

}
