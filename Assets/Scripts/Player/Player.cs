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
    private void Awake()
    {
        actions = new PlayerAction(this);
        utilities= new PlayerUtilities(this);
        stats.Speed = stats.WalkSpeed;
    }
    // Start is called before the first frame update
    private void Start()
    {
        
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
