using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(12, 38);
            zPos = Random.Range(3, 22);
            GameObject enemy = Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            enemy.AddComponent<Enemy>(); 
            yield return new WaitForSeconds(0.2f);
            enemyCount += 1;
        }
    }
}

