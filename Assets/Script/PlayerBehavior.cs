using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour, IDamageable
{
    public float maxHP;
    public float currentHP;

    [SerializeField]
    private Transform hpBar;
    private Vector2 hpScale;

    public float maxSP;
    public float currentSP;

    [SerializeField]
    private Transform spBar;
    private Vector2 spScale;

    Animator animator;

    private PlayerController player_controller;
    float health;

    private Rigidbody2D rb;

    [SerializeField] private AudioSource playerDeath;


    public float Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        hpScale = hpBar.localScale;
        currentHP = maxHP;

        spScale = spBar.localScale;
        currentSP = maxSP;

        animator = GetComponent<Animator>();

        player_controller = GetComponent<PlayerController>();

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(float damage, Vector2 knockback)
    {
        currentHP = currentHP - damage;

        if (currentHP <= 0)
        {
            rb.simulated = false;
            animator.SetTrigger("isDead");
            playerDeath.Play();
            hpBar.localScale = new Vector2(0, hpScale.y);
            return;
        }

        float newScale = hpScale.x * (currentHP / maxHP);
        hpBar.localScale = new Vector2(newScale, hpScale.y);
        rb.AddForce(knockback);
    }

    public void ReceiveDamage(float damage)
    {
        currentHP = currentHP - damage;

        if (currentHP <= 0)
        {
            animator.SetTrigger("isDead");
            hpBar.localScale = new Vector2(0, hpScale.y);
            return;
        }

        float newScale = hpScale.x * (currentHP / maxHP);
        hpBar.localScale = new Vector2(newScale, hpScale.y);


    }

    public void HealingHealth(float healing)
    {
        while (true)
        {
            float estimateHP = currentHP + healing;
            if (estimateHP > maxHP || estimateHP <= 0)
            {
                return;
            }
            currentHP = estimateHP;
            float newScale = hpScale.x * (currentHP / maxHP);
            hpBar.localScale = new Vector2(newScale, hpScale.y);
        }

    }
    public void StaminaChange(float change)
    {
        float estimateSP = currentSP + change;
        if (estimateSP > maxSP ||  estimateSP <= 0)
        {
            animator.SetBool("isMoving", false);
            player_controller.LockMovement();
            return;
        }

        currentSP = estimateSP;

        float newScale = spScale.x * (currentSP / maxSP);
        spBar.localScale = new Vector2(newScale, spScale.y);
        player_controller.UnLockMovement();

    }

}
