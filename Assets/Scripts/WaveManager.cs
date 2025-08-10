using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public Text wave;
    public int waveCounter = 0;
    public static int currentWave = 0;
    public static int enemyKills = 0;
    public static List<int> waveThreshold = new List<int>();
    public Text proggress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveCounter = 0;
        enemyKills = 0;
        wave.text = "WAVE - " + waveCounter;
        StartCoroutine(DeleteAfterDelay());
        waveThreshold.Add(0);
        waveThreshold.Add(10);


    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waveCounter;
        proggress.text = "Proggress To Next Wave: " + enemyKills + " / " + waveThreshold[waveCounter + 1];
        if (enemyKills >= waveThreshold[waveCounter + 1])
        {
            waveCounter++;
            wave.text = "WAVE - " + waveCounter;
            StartCoroutine(DeleteAfterDelay());
            SpawnEnemy.ProggressWave(waveCounter);
        }
    }

    IEnumerator DeleteAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        wave.text = "";
    }
    public static int GetWaveThreshold(int wave)
    {
        float a = 10f;
        float c = 1.7f; // tweak for difficulty curve
        return Mathf.RoundToInt(a * Mathf.Pow(wave, c));
    }
}
