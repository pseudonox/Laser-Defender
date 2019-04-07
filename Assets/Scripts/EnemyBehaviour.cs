using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip enemyShoot;
    GameManager gameManager;
    public int health = 20;
    public bool shoots = false;
    public GameObject enemyProjectilePrefab;
    public float shootInterval = 10f,shootForce=5f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (shoots)
            InvokeRepeating("ShootProjectile", Random.Range(shootInterval / 2, shootInterval / 2 + 2f), Random.Range(shootInterval - 1, shootInterval));
    }
    
    void ShootProjectile()
    {
        AudioSource.PlayClipAtPoint(enemyShoot, transform.position);
        GameObject projectile = Instantiate(enemyProjectilePrefab, transform.position+Vector3.down, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.down * shootForce);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameManager.IncreaseScore(20);
            Destroy(gameObject);
        }
    }
}
