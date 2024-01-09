using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableobject : ScriptableObject
{
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; set { startingWeapon = value;} }

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; set {  maxHealth = value;} }

    [SerializeField]
    float recovery;
    public float Recovery { get => recovery; set { recovery = value;} }

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set { moveSpeed = value; } }
}
