using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip playerShoot;
    public GameObject laserPrefab;
    public int health = 100;
    public float xMin, xMax, moveDistance, padding = 1f, shootForce = 5f, shootFrequency = 0.5f;
    public Slider healthSlider;
    public bool isMovingLeft = false, isMovingRight = false, isShooting = false;
    void Start()
    {
        xMin = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f)).x + padding;
        xMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f)).x - padding;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            InvokeRepeating("ShootLaser", 0f, shootFrequency);
        if (Input.GetKeyUp(KeyCode.Space))
            CancelInvoke("ShootLaser");
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || isMovingLeft)
            MovePlayerLeft();
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || isMovingRight)
            MovePlayerRight();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthSlider.value = health;
        if (health<=0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    void ShootLaser()
    {
        AudioSource.PlayClipAtPoint(playerShoot, transform.position);
        GameObject laser = Instantiate(laserPrefab, transform.position+Vector3.up, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().AddForce(Vector2.up * shootForce);
    }

    public void Right(bool move)
    {
        isMovingRight = move;
    }
    public void Left(bool move)
    {
        isMovingLeft = move;
    }

    public void StartShooting()
    {
        Debug.Log("StartShooting");
        InvokeRepeating("ShootLaser", 0f, shootFrequency);
    }

    public void StopShooting()
    {
        Debug.Log("StartShooting");
        CancelInvoke("ShootLaser");
    }

    public void MovePlayerLeft()
    {
        if (transform.position.x >= xMin)
            transform.Translate(Vector2.left * moveDistance * Time.deltaTime);
    }

    public void MovePlayerRight()
    {
        if (transform.position.x <= xMax)
            transform.Translate(Vector2.right * moveDistance * Time.deltaTime);
    }
}
