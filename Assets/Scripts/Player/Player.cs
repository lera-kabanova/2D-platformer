using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    [SerializeField]
    private PlayerComponents components;
     
    private PlayerReferences references;

    [SerializeField]
    private PlayerUtilities utilities;

    private PlayerAction actions;

    public PlayerComponents Components
    {
        get 
        { 
            return components; 
        }
    }
    public PlayerStats Stats
    {
        get
        {
            return stats;
        }
    }   

    public PlayerAction Actions
    {
        get
        {
            return actions;
        }
    }

    public PlayerUtilities Utilities
    {
        get
        {
            return utilities;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        actions = new PlayerAction(this);
        utilities = new PlayerUtilities(this);
        stats.Speed = stats.WalkSpeed;
        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
            new AnyStateAnimation(RIG.BODY, "Body_Idle"),
            new AnyStateAnimation(RIG.BODY, "Body_Walk"),

            new AnyStateAnimation(RIG.LEGS, "Legs_Idle"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Walk"),

         };

        components.Animator.AddAnimations(animations);
    }

    // Update is called once per frame
    private void Update()
    {
        utilities.HandleInput();
    }

    private void FixedUpdate()
    {
        actions.Move(transform);
    }
}
