using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionBehaviour : MonoBehaviour
{
    public float radius = 1f;
    public GameObject enemyToSpawn;
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
