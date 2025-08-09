using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneStartCountdown : MonoBehaviour
{
    public static SceneStartCountdown Instance;

    public Text countdownText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCountdown();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartCountdown()
    {
        StopAllCoroutines();
        Time.timeScale = 1f;
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        Time.timeScale = 0f;
        int countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdown--;
        }
        countdownText.text = "";
        Time.timeScale = 1f;
    }
}
