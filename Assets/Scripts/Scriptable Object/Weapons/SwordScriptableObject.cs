using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]

public class SwordScriptableObject : ScriptableObject
{
    [SerializeField] GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    [SerializeField]
    float damage;
    public float Damage { get => damage; set => damage = value; }

    [SerializeField]
    float rotationSpeed;
    public float RotationSpeed { get => rotationSpeed; private set => rotationSpeed = value; }

    [SerializeField]
    float distanceFromPlayer;
    public float DistanceFromPlayer { get => distanceFromPlayer; private set => distanceFromPlayer = value; }

    [SerializeField]
    int dropChance;
    public int DropChance { get => dropChance; private set => dropChance = value; }

    [SerializeField]
    WeaponType weaponType;
    public WeaponType Type { get => weaponType; private set => weaponType = value; }

    [SerializeField]
    Rarity rarity;
    public Rarity Rarity { get => rarity; private set => rarity = value; }

    [SerializeField]
    int count;
    public int Count { get => count; set => count = value; }
}
public enum WeaponType { N, R, SR, SRR }
public enum Rarity { Common, Rare, SuperRare, UltraRare }
