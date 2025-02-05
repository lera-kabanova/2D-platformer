using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats 
{
   

    public Vector2 Direction { get; set; }

    public float Speed { get; set; }

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float runSpeed;

    private WEAPON weapon;
    public float WalkSpeed
    {
        get { return walkSpeed; } 
    }

    public float JumpForce
    {
        get { return jumpForce; }
    }

    public WEAPON Weapon { get => weapon; set => weapon = value; }
}
