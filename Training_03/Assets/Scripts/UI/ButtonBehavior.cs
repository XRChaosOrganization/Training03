using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour
{

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    //private void Update()
    //{
    //    if(gameObject == EventSystem.current.currentSelectedGameObject)
    //        anim.SetBool("_isSelected", true);
    //    else
    //        anim.SetBool("_isSelected", false);
    //}

    public void OnSelect()
    {
        anim.SetBool("_isSelected", true);
    }

    public void OnDeselect()
    {
        anim.SetBool("_isSelected", false);
    }
}
