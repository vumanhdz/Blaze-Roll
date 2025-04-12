using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private PlayerCtl playerCtl;
    void Start()
    {
        playerCtl = FindObjectOfType<PlayerCtl>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        animator.SetBool("isMoving", playerCtl.ismove);
    }
}
