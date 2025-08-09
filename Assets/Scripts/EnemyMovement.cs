using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static float speed = 3;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name != "Enemy")
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wepon") && gameObject.name != "Enemy")
        {
            Destroy(gameObject);
            SpawnEnemy.points += 10;
        }
    }
    void OnDestroy()
    {
        SpawnEnemy.livingEnemies--;
        WaveManager.enemyKills++;
    }
}
