using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyType
{
    test1,
    test2,
    test3,
    test4,
    test5
}

/// <summary>
/// Spawns various enemies
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    #region
    [SerializeField]
    private float spawnRate = 1f;
    [SerializeField]
    private bool canSpawn = true;

    //List of enemies to spawn
    [SerializeField]
    private GameObject[] enemyPrefabs;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Start Spawning

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn == true)
        {
            yield return wait;
            //Get random number to spawn enemy
            int rand = Random.Range(0, enemyPrefabs.Length);

            //Make prefab an Object
            GameObject enemyToSpawn = enemyPrefabs[rand];

            

        }
    }
}
