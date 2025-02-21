using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICollisionHandler
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject fireBallPrefab;

    [SerializeField]
    private Transform mouth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "DamageArea" && other.tag == "Player")
        {
            other.GetComponent<Player>().Actions.TakeHit();
        }
    }

    public void StopAttack()
    {
        animator.SetBool("Attack", false);
    }


    public void Shoot()
    {
        GameObject go = Instantiate(fireBallPrefab, mouth.position, Quaternion.identity);

        Vector3 direction = new Vector3(transform.localScale.x, 0);

        go.GetComponent<Projectile>().Setup(direction);
    }
}
