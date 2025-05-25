using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleItem : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    private static readonly string OPEN_PARAM = "open";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetOpen(bool open)
    {
        isOpen = open;
        animator.SetBool(OPEN_PARAM, open);
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
