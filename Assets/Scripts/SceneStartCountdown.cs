using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;  // For List

public class SceneStartCountdown : MonoBehaviour
{
    public static SceneStartCountdown Instance;
    
    public Text countdownText;
    public List<Button> buttonsToDisable;

    // Global flag for input blocking
    public static bool InputBlocked { get; private set; } = false;

    void Start()
    {
        StartCountdown();
        Instance = this;
    }

    public void StartCountdown()
    {
        StopAllCoroutines();
        Time.timeScale = 1f;
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        SetButtonsInteractable(false);
        InputBlocked = true;  // block input

        Time.timeScale = 0f;
        int countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdown--;
        }
        countdownText.text = "";

        SetButtonsInteractable(true);
        InputBlocked = false;  // allow input again 
        Time.timeScale = 1f;
    }

    private void SetButtonsInteractable(bool interactable)
    {
        foreach (var button in buttonsToDisable)
        {
            button.interactable = interactable;
        }
    }
}
