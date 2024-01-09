using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public SwordController swordController;
    private SwordStats swordStats;
    public List<SwordScriptableObject> collectedSwords = new List<SwordScriptableObject>();

    private void Awake()
    {
        swordStats = GetComponent<SwordStats>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Weapon"))
        {
            Debug.Log("Weapon tag detected.");

            Sword swordComponent = col.GetComponent<Sword>();
            if (swordComponent != null)
            {

                SwordScriptableObject newWeaponData = swordComponent.swordData;


                if (!collectedSwords.Contains(newWeaponData))
                {

                    collectedSwords.Add(newWeaponData);

                    
                    if (swordController != null)
                    {
                        swordController.ActiveWeapon(newWeaponData);
                    }
                }
            }
            else
            {
                Debug.Log("No Weapon component found on this GameObject.");
            }
        }
    }

    private void CollectWeapon(SwordScriptableObject newWeapon)
    {
        if (!collectedSwords.Contains(newWeapon))
        {
            collectedSwords.Add(newWeapon);

            if (swordController != null)
            {
                swordController.ActiveWeapon(newWeapon);
            }
        }
    }
}
