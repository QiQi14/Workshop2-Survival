using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{

    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;
    public List<GameObject> weaponPrefabs;

    void Start()
    {
        SpawnProps();
    }

    //void SpawnProps()
    //{
    //    foreach (GameObject sp in propSpawnPoints)
    //    {
    //        int rand = Random.Range(0, propPrefabs.Count);
    //        GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
    //        prop.transform.parent = sp.transform;
    //    }
    //}

    void SpawnProps()
    {
        foreach (GameObject sp in propSpawnPoints)
        {
            float rand = Random.Range(0f, 100f);

            if(rand <= 50f)
            {
                SpawnWeaponAtPoint(sp);
            }

            else
            {
                SpawnPropAtPoint(sp);
            }
        }
    }

    void SpawnPropAtPoint(GameObject sp)
    {
        int rand = Random.Range(0, propPrefabs.Count);
        GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
    }

    void SpawnWeaponAtPoint(GameObject sp)
    {
        float rand = Random.Range(0f, 100f);
        GameObject weaponToSpawn;

        if (rand <= 50f)
        {
            weaponToSpawn = weaponPrefabs[0];
        }

        else if (rand <= 80f)
        {
            weaponToSpawn = weaponPrefabs[1];
        }

        else if (rand <= 90f)
        {
            weaponToSpawn = weaponPrefabs[2];
        }
        else
        {
            weaponToSpawn= weaponPrefabs[3];
        }

        Instantiate(weaponToSpawn, sp.transform.position, Quaternion.identity);
    }
}
