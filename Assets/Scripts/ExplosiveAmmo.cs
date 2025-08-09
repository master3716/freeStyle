using System.Collections;
using UnityEngine;

public class ExplosiveAmmo : MonoBehaviour
{
    public GameObject sprite;
    public float speed = 10f;
    public float radius = 4f;
    float start = 0;
    bool right = false;
    Vector2 direction;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(gameObject.name != "ExplosiveAmmo")
            AmmoManager.ammo -= 10;
        setDirection();

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
        if (start > 5 && gameObject.name != "ExplosiveAmmo")
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            speed = 0;
            gameObject.GetComponent<CircleCollider2D>().radius = radius;
            StartCoroutine(DestroyAfterDelay());
        }
    }
    
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
