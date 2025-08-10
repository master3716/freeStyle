
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;
    float start = 0;
    bool right = false;
    public GameObject player;
    Vector2 direction;
    public static int damage = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.name != "Bullet")
            AmmoManager.ammo--;
        direction = Movement.shotDirection;
        if (transform.position.x < 0)
        {
            right = true;
            transform.localScale = new Vector3(0.2205f, 0.2775f, 1);
        }
        else
        {
            transform.localScale = new Vector3(0.2205f, -0.2775f, 1);
        }


    }

    // Update is called once per frame
    void Update()
    {
        start += Time.deltaTime;
        Move();
        if (start > 5 && gameObject.name != "Bullet")
            Destroy(gameObject);

    }
    
    void Move()
    {
        if (direction == Vector2.zero)
        {
            if (right)
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            else
                transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
            transform.Translate(direction * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Mutate"))
        {
            Destroy(gameObject);
        }
    }
}
