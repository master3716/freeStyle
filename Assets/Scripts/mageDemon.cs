using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class mageDemon : MonoBehaviour
{
    public static float cooldown = 5f;
    private float timer = 0f;
    public List<Sprite> sprites;
    public GameObject lasar;
    public static float speed = 3f;


    public float arenaWidth = 16f;
    public float arenaHeight = 9f;
    public float gapSize = 5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name != "Mage")
        {
            timer += Time.deltaTime;
            print(LaserMove.aliveLasar + " " + timer);
            if (timer >= cooldown && LaserMove.aliveLasar < 2)
            {
                timer = 0f;
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                Attack();
            }
        }
    }
      void OnTriggerEnter2D(Collider2D collision)
    { 
        if ((collision.gameObject.CompareTag("Wepon") || collision.gameObject.CompareTag("Explosive")) && gameObject.name != "Mage")
            Destroy(gameObject);
        
    }
    void Attack()
    {
        float thickness = 0.75f;

        float gapCenterY = Random.Range(-arenaHeight / 2 + gapSize, arenaHeight / 2 - gapSize);

        GameObject topLaser = Instantiate(lasar);
        float topHeight = (arenaHeight / 2) - (gapCenterY + gapSize / 2);
        topLaser.transform.position = new Vector2(0, (arenaHeight / 2 + (gapCenterY + gapSize / 2)) / 2f);
        topLaser.transform.localScale = new Vector2(thickness, topHeight);

        GameObject bottomLaser = Instantiate(lasar);
        float bottomHeight = (gapCenterY - gapSize / 2) - (-arenaHeight / 2);
        bottomLaser.transform.position = new Vector2(0, (-arenaHeight / 2 + (gapCenterY - gapSize / 2)) / 2f);
        bottomLaser.transform.localScale = new Vector2(thickness, bottomHeight);

        
        StartCoroutine(ChangeSpriteAfterDelay(1f));
    }

    IEnumerator ChangeSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }
     void OnDestroy()
    {
        SpawnEnemy.livingEnemies--;
        WaveManager.enemyKills++;
    }
}








