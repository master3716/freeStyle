using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject mutatedEnemy;
    public static MutatedDemon mutatedDemon = new MutatedDemon();
    public GameObject enemy;
    public GameObject player;
    public static int livingEnemies = 0;
    public float safeZone = 5;
    public static int maxEnemies = 3;
    public static float spawnCoolDown = 1;
    float lastSpawn = 0;
    float currentTime = 0;
    public Text score;
    public static float points = 0;
    bool isPlayer = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCoolDown = 1;
        maxEnemies = 3;
        livingEnemies = 0;
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
        if (!RollMutate())
        {
            int attempts = 0;
            Vector3 spawn = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
            Vector3 dis = player.transform.position - spawn;
            float distance = Vector3.Distance(player.transform.position, spawn);
            while (distance < safeZone && attempts < 10)
            {
                spawn = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
                distance = Vector3.Distance(player.transform.position, spawn);
                attempts++;
            }
            if (attempts == 10)
                spawn = new Vector3(0, 0, 0);
            GameObject spawnEnemy = Instantiate(enemy, spawn, Quaternion.identity);
        }
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
    public static void ProggressWave(int wave)
    {
        print("Wave: " + wave);
        maxEnemies = 3 + Mathf.RoundToInt(Mathf.Pow(wave, 1.2f));
        print("max enemies: " + maxEnemies);
        EnemyMovement.speed = 3 + wave * 0.25f;
        print("speed: " + EnemyMovement.speed);
        spawnCoolDown = Mathf.Max(0.5f, spawnCoolDown - 0.1f * wave);
        print("spawnCoolDown: " + spawnCoolDown);
        WaveManager.waveThreshold.Add(WaveManager.GetWaveThreshold(wave));
    }


    public bool RollMutate()
    {

       if (Random.Range(1, 101) <= Mathf.Min(50, WaveManager.currentWave))
        {
            int attempts = 0;
            Vector3 spawn = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
            Vector3 dis = player.transform.position - spawn;
            float distance = Vector3.Distance(player.transform.position, spawn);
            while (distance < safeZone && attempts < 10)
            {
                spawn = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
                distance = Vector3.Distance(player.transform.position, spawn);
                attempts++;
            }
            if (attempts == 10)
                spawn = new Vector3(0, 0, 0);
            GameObject spawnEnemy = Instantiate(mutatedEnemy, spawn, Quaternion.identity);

            mutatedDemon.SetDamage(Mathf.RoundToInt(10 + Mathf.Pow(WaveManager.currentWave, 1.3f)));
            mutatedDemon.SetHealth(Mathf.RoundToInt(10 + Mathf.Pow(WaveManager.currentWave, 1.5f)));
            mutatedDemon.SetSpeed(3 + WaveManager.currentWave * 0.2f);
            return true;
        }
        return false;
    }
}
