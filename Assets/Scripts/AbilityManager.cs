using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public static Rage rage = new Rage(7, 60f, 10f);
    public static bool isRaged = false;
    public static bool startRageTimer = false;
    float rageTImer = 0;
    public Image rageBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       isRaged = false;
       startRageTimer = false;
       rageTImer = 0;
        rageBar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRage();
    }
    void CheckRage()
    {
        if (startRageTimer)
            rageTImer += Time.deltaTime;

        if (rageTImer >= rage.GetRageDuration())
        {
            isRaged = false;
            startRageTimer = false;
            rageTImer = 0;
            Movement.speed = 5;
            Movement.player.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
            Movement.healtDebt += 20;

        }
        if (isRaged)
        {
            Movement.speed = rage.GetRageSpeed();
            rageBar.enabled = true;
            updateRageBar(rage.GetRageDuration(), rageTImer);
        }

    }

    void updateRageBar(float dur, float pass)
    {
        float percent = Mathf.Clamp01(1 - (pass / dur));
        rageBar.fillAmount = percent;
        if (percent <= 0f)
            rageBar.enabled = false;    
        


   
    }
}
