using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BaseAnimationController : MonoBehaviour
{
    protected Animator animator;

    virtual protected void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {

    }
}