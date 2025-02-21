using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour, ICollisionHandler, IHitable
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject fireBallPrefab;

    [SerializeField]
    private Transform mouth;

    [SerializeField]
    private GameObject head;

    private Transform target;

    [SerializeField]
    private float attackCooldown;

    [SerializeField]
    private Rigidbody2D rigidBody;

    private bool alive = true;

    private bool canAttack = true;

    private float timeSinceAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            LookAtTarget();
            Attack();
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

    private void Attack()
    {
        if (!canAttack)
        {
            timeSinceAttack += Time.deltaTime;
        }
        if (timeSinceAttack >= attackCooldown)
        {
            canAttack = true;
        }
        if (canAttack && target != null && Mathf.Abs(target.transform.position.y - transform.position.y) <= 1f)
        {
            canAttack = false;
            timeSinceAttack = 0;
            animator.SetBool("Attack", true);
        }
    }

    private void LookAtTarget()
    {
        if (target != null)
        {
            Vector3 scale = transform.localScale;
            scale.x = target.transform.position.x < transform.position.x ? -1 : 1;

            transform.localScale = scale;
        }
    }

    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "DamageArea" && other.tag == "Player")
        {
            other.GetComponent<Player>().Actions.TakeHit();
        }

        if (colliderName == "Sight" && other.tag == "Player")
        {
            if (target == null)
            {
                this.target = other.transform;
            }

        }
    }

    public void CollisionExit(string colliderName, GameObject other)
    {
        if (colliderName == "Sight" && other.tag == "Player")
        {
            target = null;
        }
    }

    private void Die()
    {
        alive = false;
        rigidBody.gravityScale = 1;
        animator.SetTrigger("Die");
        head.SetActive(false);
        GetComponent<PIngPong>().enabled = false;

    }

    public void TakeHit()
    {
        Die();
    }
}
