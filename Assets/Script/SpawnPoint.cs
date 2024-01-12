using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject spawnObject;

    public float spawnTime = 1f;
    public bool canSpawn = true;
    public bool infinite = false;
    public int spawnNumber = 5;

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    public IEnumerator spawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnTime);
        if (canSpawn == true && infinite == true)
        {
            while (true)
            {
                yield return wait;
                GameObject enemy = Instantiate(spawnObject, transform.position, Quaternion.identity) as GameObject;
                enemy.tag = "Enemy";
            }
        }
        else if (infinite == false && canSpawn == true)
        {
            for (int i = 0; i < spawnNumber; i++)
            {
                yield return wait;
                GameObject enemy = Instantiate(spawnObject, transform.position, Quaternion.identity) as GameObject;
                enemy.tag = "Enemy";
            }
        }

    } 

}
