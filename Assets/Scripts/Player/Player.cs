using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;

    [SerializeField]
    private PlayerComponents components;

    [SerializeField]
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

    public PlayerReferences References
    {
        get
        {
            return references;
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
            new AnyStateAnimation(RIG.BODY, "Body_Idle", "Body_Attack"),
            new AnyStateAnimation(RIG.BODY, "Body_Walk", "Body_Attack","Body_Jump"),
            new AnyStateAnimation(RIG.BODY, "Body_Jump"),
            new AnyStateAnimation(RIG.BODY, "Body_Fall"),
            new AnyStateAnimation(RIG.BODY, "Body_Attack"),

            new AnyStateAnimation(RIG.LEGS, "Legs_Idle","Legs_Attack"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Walk", "Legs_Jump"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Jump"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Fall"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Attack"),

         };

        Components.Animator.AnimationTriggerEvent += Actions.Shoot;

        stats.Weapons.Add(WEAPON.FISTS, true);
        stats.Weapons.Add(WEAPON.GUN, false);
        stats.Weapons.Add(WEAPON.SWORD, false);

        UIManager.Instance.AddLife(stats.Lives);

        components.Animator.AddAnimations(animations);
    }

    // Update is called once per frame
    private void Update()
    {
        utilities.HandleInput();
        utilities.HandleAir();
    }

    private void FixedUpdate()
    {
        actions.Move(transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        actions.Collide(collision);
    }
}
