using UnityEngine;
using UnityEngine.UI;

public class MutateEnemy : MonoBehaviour
{
    private MutatedDemon demon;
    private int health;
    private float speed;
    public GameObject player;
    public Image healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        demon = SpawnEnemy.mutatedDemon;
        speed = demon.GetSpeed();
        health = demon.GetHealth();
        healthBar.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name != "MutateEnemy")
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name != "MutateEnemy")
        {
            if (collision.gameObject.CompareTag("Wepon"))
                health -= BulletMove.damage;
            else if (collision.gameObject.CompareTag("Explosive"))
                health -= ExplosiveAmmo.damage;

            if (health <= 0)
                Destroy(gameObject);
            updateHealthBar();
        }

    }
    void updateHealthBar()
    {
        float percent = Mathf.Clamp01(health / ((float)demon.GetHealth()));
        healthBar.fillAmount = percent;
        if (percent <= 0f)
            healthBar.enabled = false;
    }
    
}
