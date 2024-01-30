using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSword : MonoBehaviour, ICollectible
{
    public int swordGrandted;

    public void Collect()
    {
        SwordStats swordStats = FindObjectOfType<SwordStats>();
        swordStats.IncreaseSword(swordGrandted);
        Destroy(gameObject);
    }
}
