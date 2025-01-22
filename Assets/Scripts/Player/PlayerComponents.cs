using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    public Rigidbody2D RigidBody
    {
        get { return rigidBody; }
    }
}
