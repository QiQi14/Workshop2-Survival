using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStats : MonoBehaviour
{
    private PlayerCollector playerCollector;
    //Current Stats
    float currentDamage;

    [Header("Sword Count/Sword Level")]
    public int swordExperience = 0;
    public int swordLevel = 0;
    public int swordExperienceCap = 1;

    public float baseDamage = 10;
    public float damageIncreasePerLevel = 2;

    private void Awake()
    {
        playerCollector = FindObjectOfType<PlayerCollector>();
    }

    private void Update()
    {
        SwordIncreaseChecker();
    }

    public void UpdateSwordStats()
    {
        foreach (var swordData in playerCollector.collectedSwords)
        {
            swordData.Damage = CalculateDamageBasedOnLevel();
        }
    }

    private float CalculateDamageBasedOnLevel()
    {
        return baseDamage + swordLevel * damageIncreasePerLevel;
    }

    public void IncreaseSword(int amount)
    {
        swordExperience += amount;
        SwordIncreaseChecker();
    }

    void SwordIncreaseChecker()
    {
        while (swordExperience >= swordExperienceCap)
        {
            if (swordLevel < 5)
            {
                swordLevel++;
                swordExperience -= swordExperienceCap;
            }
            else
            {
                IncreaseDamage();
                swordExperience -= swordExperienceCap;
            }
        }
        
    }

    void IncreaseDamage()
    {
        float newDamage = baseDamage + swordLevel * damageIncreasePerLevel;
        Debug.Log($"currentDamage: {currentDamage}");
    }
}
