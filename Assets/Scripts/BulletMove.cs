
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;
    float start = 0;
    bool right = false;
    public GameObject player;
    Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.name != "Bullet")
            AmmoManager.ammo--;
        setDirection();

        if (transform.position.x < 0)
            right = true;

    }

    // Update is called once per frame
    void Update()
    {
        start += Time.deltaTime;
        Move();
        if (start > 5 && gameObject.name != "Bullet")
            Destroy(gameObject);

    }
    void setDirection()
    {

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.linearVelocity.normalized;
        if (velocity != Vector2.zero)
        {
            if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
            {
                if (velocity.x > 0)
                    direction = Vector2.down;
                else
                    direction = Vector2.up;
            }
            else
            {
                if (velocity.y > 0)
                    direction = Vector2.right;
                else
                    direction = Vector2.left;
            }
        }
        else
            direction = Vector2.zero;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
