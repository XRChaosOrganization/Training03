using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreDisplay;
    Animator anim;
    AudioSource source;

    int score;
    //public int score {
    //    get { return _score; }
    //    set
    //    {
            
    //        anim.SetTrigger("Play");
    //        source.Play();
    //        _score = value;
    //        scoreDisplay.text = _score.ToString();
    //    }
    //}

    private void Awake()
    {
        scoreDisplay = gameObject.GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        scoreDisplay.text = "0";

    }


    private void Update()
    {
        if (score < GameManager.gm.score)
        {
            anim.SetTrigger("Play");
            source.Play();
            scoreDisplay.text = GameManager.gm.score.ToString();
            score = GameManager.gm.score;
        }
            
    }
}
