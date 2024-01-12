using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    
    public Collider2D swordCollider;
    public float damage = 3;
    Vector2 rightAttackOffset;
    public float knockbackForce = 5000f;

    private void Start()
    {
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageableObject = collider.GetComponent<IDamageable>();
        // && playerBehavior.currentHP > 0
        if (collider.tag == "Enemy" && damageableObject != null)
        {

            Enemy enemy = collider.GetComponent<Enemy>(); 
            if (enemy != null)
            {

                enemy.Health -= damage;
                //enemy.ReceiveDamage(damage);

                Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

                Vector2 direction = (Vector2)(collider.gameObject.transform.position - parentPosition).normalized;

                Vector2 knockback = direction * knockbackForce;
                enemy.ReceiveDamage(damage, knockback);
            }
        } else
        {
            Debug.LogWarning("Check tag Enemy and Collider not implement IDamageable");
        }
    }
}
