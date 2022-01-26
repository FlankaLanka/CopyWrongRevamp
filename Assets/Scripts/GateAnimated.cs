using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimated : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenGate()
    {
        animator.SetBool("Open", true);
        animator.Play("Gate_1_Open_Animation 1");
    }
    public void CloseGate()
    {
        animator.SetBool("Open", false);
        animator.Play("Gate_1_Close_Animation");
    }
    public bool GetOpen()
    {
        return animator.GetBool("Open");
    }
}
