using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChargingDemon : MonoBehaviour
{
    public List<Sprite> sprites;
    public static float speed = 15f;
    public GameObject player;
    public Image chargeBar;
    private float timer = 0;
    public static float maxChargeTime = 5f;
    private Vector2 direction;
    private bool move = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chargeBar.enabled = true;
        timer = 0;
        direction = Vector2.zero;
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name != "ChargingEnemy")
        {
            timer += Time.deltaTime;
            direction = (player.transform.position - transform.position).normalized;
            UpdateChargeBar();
            if (move)
            {
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }
    void UpdateChargeBar()
    {
        float percent = Mathf.Clamp01(timer / maxChargeTime);
        chargeBar.fillAmount = percent;
        if (percent >= 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            chargeBar.enabled = false;
            move = true;

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if ((collision.gameObject.CompareTag("Wepon") || collision.gameObject.CompareTag("Explosive")) && gameObject.name != "ChargingEnemy")
            Destroy(gameObject);
        
    }
    void OnDestroy()
    {
        SpawnEnemy.livingEnemies--;
        WaveManager.enemyKills++;
    }
    
}
