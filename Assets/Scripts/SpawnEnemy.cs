using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public static int livingEnemies = 0;
    public float safeZone = 5;
    public int maxEnemies = 3;
    public float spawnCoolDown = 1;
    float lastSpawn = 0;
    float currentTime = 0;
    public Text score;
    public static float points = 0;
    bool isPlayer = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0;
        score.text = "Score: " + points;
        livingEnemies = 0;
        Movement.health = 100;
        Movement.healtDebt = 0;
        AmmoManager.ammo = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckPlayer())
        {
            currentTime += Time.deltaTime;
            print(livingEnemies);
            if (livingEnemies < maxEnemies && currentTime - lastSpawn >= spawnCoolDown)
            {
                Spawn();
                livingEnemies++;
                lastSpawn = currentTime;
            }
            points = Mathf.Round(points * 10f) / 10f;
            score.text = "Score: " + points;
        }
    }

    void Spawn()
    {
        int attempts = 0;
        Vector3 spawn = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        Vector3 dis = player.transform.position - spawn;
        float distance = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
        while (distance < safeZone && attempts < 10)
        {
            print(distance);
            spawn = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
            dis = player.transform.position - spawn;
            distance = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
            attempts++;
        }
        if (attempts == 10)
            spawn = new Vector3(0, 0, 0);
        GameObject spawnEnemy = Instantiate(enemy, spawn, Quaternion.identity);
    }
    bool CheckPlayer()
    {
        try
        {
            float x = player.transform.position.x;
            isPlayer = true;
        }
        catch
        {
            isPlayer = false;
        }
        return isPlayer;
    }
}
