using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public Text wave;
    public int waveCounter = 0;
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
        waveThreshold.Add(50);
        waveThreshold.Add(100);

    }

    // Update is called once per frame
    void Update()
    {
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
}
