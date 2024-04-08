using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Awake()
    {
        if (anim == null) return;
            
        anim.SetTrigger("PlayFlt");
        anim.SetTrigger("OptionsFlt");
        anim.SetTrigger("CreditsFlt");
        
    }
}
