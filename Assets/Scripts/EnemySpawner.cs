using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject defaultEnemyPrefab;
    public float width = 5f, height = 5f,moveSpeed=5f,delayInSpawn=1f;
    bool movingLeft = false;
    Vector2 cubeSize;
    PlayerController playerController;
    private void OnDrawGizmos()
    {
        cubeSize = new Vector2(width, height);
        Gizmos.DrawWireCube(transform.position, cubeSize);
    }

    void Start()
    {
        RespawnAllEnemies();
        playerController = FindObjectOfType<PlayerController>();
    }

    void RespawnAllEnemies()
    {
        for (var i = 0; i <= transform.childCount - 1; i++)
        {
            SpawnEnemy(transform.GetChild(i));
        }
    }

    void Update()
    {
        if (movingLeft)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (transform.position.x + width / 2 >= playerController.xMax)
        {
            movingLeft = true;
        }
        if (transform.position.x - width / 2 <= playerController.xMin)
        {
            movingLeft = false;
        }
        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
    }


    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            SpawnEnemy(freePosition);
            if (NextFreePosition())
                Invoke("SpawnUntilFull", delayInSpawn);
        }
    }
    void SpawnEnemy(Transform spawnPosition)
    {
        GameObject enemy = Instantiate(spawnPosition.GetComponent<SpawnPositionBehaviour>().enemyToSpawn, spawnPosition.position, Quaternion.identity);
        enemy.transform.parent = spawnPosition;
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(defaultEnemyPrefab, transform.position, Quaternion.identity);
        enemy.transform.parent = transform;
    }

    Transform NextFreePosition()
    {
        for (var i = 0; i <= transform.childCount - 1; i++)
        {
            if (transform.GetChild(i).childCount == 0)
            {
                return transform.GetChild(i);
            }
        }
        return null;
    }

    bool AllMembersDead()
    {
        for (var i = 0; i <= transform.childCount - 1; i++)
        {
            if (transform.GetChild(i).childCount>0)
            {
                return false;
            }
        }
        return true;
    }
}
