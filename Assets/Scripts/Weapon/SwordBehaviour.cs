using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public SwordScriptableObject swordData;

    protected float currentDamage;
    protected float currentRotationspeed;
    protected float currentDistanceFromPlayer;

    private void Awake()
    {
        currentDamage = swordData.Damage;
        currentRotationspeed = swordData.RotationSpeed;
        currentDistanceFromPlayer = swordData.DistanceFromPlayer;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            MonsterStats monster = col.GetComponent<MonsterStats>();
            monster.TakeDamage(currentDamage);
        }
    }

    public void DirectionChecker(Vector3 direction)
    {
        transform.up = direction;
    }
}
