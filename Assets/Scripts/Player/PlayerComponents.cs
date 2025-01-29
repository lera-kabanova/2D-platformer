using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    private AnyStateAnimator animator;

    public Rigidbody2D RigidBody
    {
        get { return rigidBody; }
    }

    public AnyStateAnimator Animator
    {
        get { return animator; }
    }
}
