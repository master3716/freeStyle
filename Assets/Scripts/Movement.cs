

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Movement : MonoBehaviour
{
    public static int speed = 5;
    public GameObject projectile;
    float currentTime = 0;
    public Rigidbody2D rb;
    public static float health = 100;
    public static float healtDebt = 0;
    public Text hp;
    public GameObject p;
    public static GameObject player;
    public GameObject Explosive;
    public static int equipedAmmo = 0;
    List<GameObject> ammo = new List<GameObject>();
    public List<Sprite> playerSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp.text = "" + Mathf.Floor(health);
        player = p;
        ammo.Add(projectile);
        ammo.Add(Explosive);
    }

    // Update is called once per frame
    void Update()
    {
        checkEquipedAmmo();
        currentTime += Time.deltaTime;
        Move();
        if (AmmoManager.ammo > 0)
            Attack();
        else
            print("out of ammo");

        ChangeDirection();
    }
    void ChangeDirection()
    {
        if (transform.position.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healtDebt += 10;
            Destroy(collision.gameObject);
            
        }
        if (health - healtDebt <= 0)
        {
            SpawnEnemy.points += Mathf.Floor(0.5f * currentTime);
            SceneManager.LoadScene("Lose");
        }
    }
    void Move()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector2.up;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector2.down;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector2.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector2.right;

        rb.linearVelocity = moveDirection.normalized * speed;
        if (healtDebt != 0)
            DeductHealth();
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(ammo[equipedAmmo], transform.position, Quaternion.Euler(0, 0, 90));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            equipedAmmo++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            equipedAmmo--;
        }
        if(equipedAmmo == 1 && AmmoManager.ammo < 10)
        {
            equipedAmmo--;
        }
        player.GetComponent<SpriteRenderer>().sprite = playerSprites[equipedAmmo];
        AmmoManager.ammoIndecator.texture = AmmoManager.slectAmmoIndecator[equipedAmmo];
    }
    void checkEquipedAmmo()
    {
        if (equipedAmmo > ammo.Count - 1)
            equipedAmmo = ammo.Count - 1;
        else
            if (equipedAmmo < 0)
            equipedAmmo = 0;
    }
    void DeductHealth()
    {
        if (healtDebt > 0)
        {
            health -= 10 * Time.deltaTime;
            healtDebt -= 10 * Time.deltaTime;
            hp.text = "" + Mathf.Floor(health);
        }
        else
        {
            health += 10 * Time.deltaTime;
            healtDebt += 10 * Time.deltaTime;
            hp.text = "" + Mathf.Floor(health);
        }
        if (healtDebt < 1 && healtDebt > 0)
        {
            healtDebt = 0;        
            hp.text = "" + Mathf.Floor(health);
        }
    }
}
