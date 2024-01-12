using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour, IDamageable
{
    private Transform target;

    [SerializeField]
    private float speed = 1f;
    private float rotationSpeed = 0.025f;

    Animator animator;

    private Rigidbody2D rb;

    private float distance;

    public float knockbackForce = 300f;

    [SerializeField]
    private Transform hpBar;
    private Vector2 hpScale;

    [SerializeField]
    private AudioSource EnemyDead;


    public float Health
    {
        set
        {
            if (value < health)
            {
                animator.SetTrigger("Hit");
            }

            health = value;

            if (health <= 0)
            {
                EnemyDead.Play();
                Defeated();
            }
        }
        get
        { 
            return health; 
        }
    }

    float health;

    public float maxHP;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        getTarget();

        hpScale = hpBar.localScale;
        Health = maxHP;
    }

    void Update()
    {
        if (!target)
        {
            getTarget();
        }
        else
        {
            //RotationEnemyFace();
        }
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, target.position);
        Vector2 direction = (target.position - transform.position);

        transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);

    }

    private void RotationEnemyFace()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90F;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }

    private void getTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collision.gameObject.tag == "Player")
        {

            Vector2 direction = (Vector2)(collider.gameObject.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;

            PlayerBehavior playerBehavior = collision.gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceiveDamage(20, knockback);

        }
    }

    //public void ReceiveDamage(float damage)
    //{
    //    Health = Health - damage;

    //    if (Health <= 0)
    //    {
    //        hpBar.localScale = new Vector2(0, hpScale.y);
    //        return;
    //    }

    //    float newScale = hpScale.x * (Health / maxtHP);
    //    hpBar.localScale = new Vector2(newScale, hpScale.y);


    //}

    public void ReceiveDamage(float damage, Vector2 knockback)
    {
        Health = Health - damage;

        if (Health <= 0)
        {
            hpBar.localScale = new Vector2(0, hpScale.y);
            return;
        }

        float newScale = hpScale.x * (Health / maxHP);
        hpBar.localScale = new Vector2(newScale, hpScale.y);
        rb.AddForce(knockback);

    }

    public void ReceiveDamage(float damage)
    {
        Health = Health - damage;

        if (Health <= 0)
        {
            hpBar.localScale = new Vector2(0, hpScale.y);
            return;
        }

        float newScale = hpScale.x * (Health / maxHP);
        hpBar.localScale = new Vector2(newScale, hpScale.y);
    }
}
