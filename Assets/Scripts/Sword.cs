using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHitable hit = collision.GetComponentInParent<IHitable>();

        if (hit != null)
        {
            hit.TakeHit();
        }
    }
}
