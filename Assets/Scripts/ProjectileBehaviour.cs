using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public AudioClip enemyHit;
    GameManager gameManager;
    public int damage = 10;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            AudioSource.PlayClipAtPoint(enemyHit, collision.transform.position);
            gameManager.IncreaseScore(10);
            Destroy(gameObject);
            collision.GetComponent<EnemyBehaviour>().TakeDamage(damage);
        }
    }
}
