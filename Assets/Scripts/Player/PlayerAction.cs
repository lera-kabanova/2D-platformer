using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction 
{
    private Player player;

    public PlayerAction(Player player)
    {
        this.player = player;
    }
    public void Move(Transform transform)
    {
        player.Components.RigidBody.velocity = new Vector2(player.Stats.Direction.x * player.Stats.Speed * Time.deltaTime, player.Stats.Direction.y);
    }

}
