
using UnityEngine;

public interface IDamageable
{
    public float Health { get; set; }

    public void ReceiveDamage(float damage, Vector2 knockback);

    public void ReceiveDamage(float damage);
}