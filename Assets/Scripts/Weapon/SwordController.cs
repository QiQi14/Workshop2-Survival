using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public List<SwordScriptableObject> swordDataList = new List<SwordScriptableObject>();
    public SwordStats swordStats;
    public Transform player;

    private int numberOfWeapons = 0;
    private List<GameObject> spawnedWeapons = new List<GameObject>();

    public void AddWeaponToPlayer(SwordScriptableObject newSwordData)
    {
        if (numberOfWeapons < 5)
        {
            swordDataList.Add(newSwordData);
            numberOfWeapons++;
            GameObject weapon = Instantiate(newSwordData.Prefab, transform.position, Quaternion.identity);
            spawnedWeapons.Add(weapon);
            UpdateAllWeaponPosition();
        }
    }

    public void ActiveWeapon(SwordScriptableObject newSwordData)
    {
        int weaponIndex = swordDataList.IndexOf(newSwordData);
        if (weaponIndex == -1)
        {
            AddWeaponToPlayer(newSwordData);
            weaponIndex = swordDataList.Count - 1;
        }

        for (int i = 0; i < spawnedWeapons.Count; i++)
        {
            if (i == weaponIndex)
            {
                spawnedWeapons[i].SetActive(true);
            }
            else
            {
                spawnedWeapons[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        UpdateAllWeaponPosition();
    }

    // Update is called once per frame
    private void UpdateAllWeaponPosition()
    {
        for (int i = 0; i < spawnedWeapons.Count; i++)
        {
            SwordScriptableObject currentSwordData = swordDataList[i];
            UpdateWeaponPosition(spawnedWeapons[i], i, currentSwordData);
        }
    }

    private void UpdateWeaponPosition(GameObject weapon, int index, SwordScriptableObject swordData)
    {
        float angleStep = 360f / numberOfWeapons;
        float angle = index * angleStep + Time.time * swordData.RotationSpeed;
        float xPosition = player.position.x + Mathf.Sin(angle * Mathf.Deg2Rad) * swordData.DistanceFromPlayer;
        float yPosition = player.position.y + Mathf.Cos(angle * Mathf.Deg2Rad) * swordData.DistanceFromPlayer;
        Vector3 newPosition = new Vector3(xPosition, yPosition, 0);

        // update location of weapon
        weapon.transform.position = newPosition;

        Vector3 direction = (newPosition - player.position).normalized;
        weapon.transform.up = direction;
    }
}
