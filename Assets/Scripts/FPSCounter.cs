using UnityEngine;
using TMPro; 

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private float updateInterval = 0.5f;
    private float accum = 0;
    private int frames = 0;
    private float timeleft;

    void Start()
    {
        if (fpsText == null)
        {
            Debug.LogError("FPS TextMeshProUGUI not assigned!");
            enabled = false;
        }
        timeleft = updateInterval;
    }

    void Update()
    {
        timeleft -= Time.unscaledDeltaTime;
        accum += 1.0f / Time.unscaledDeltaTime;
        ++frames;

        
        if (timeleft <= 0.0f)
        {
            float fps = accum / frames;
            fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";

            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }
}