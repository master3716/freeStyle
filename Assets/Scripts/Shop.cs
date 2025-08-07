using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BuyRage()
    {
        if (SpawnEnemy.points >= 20 && !AbilityManager.isRaged)
        {
            AbilityManager.isRaged = true;
            AbilityManager.startRageTimer = true;
            Movement.player.GetComponent<Renderer>().material.color = new Color32(199, 21, 133, 255);
            Movement.healtDebt -= 20;
            SpawnEnemy.points -= 20;
        }
    }
    public void AmmoRefill()
    {
        if (SpawnEnemy.points >= 50)
        {
            SpawnEnemy.points -= 50;
            AmmoManager.ammo += 50;
        }
    }
    public void Heal()
    {
        if (SpawnEnemy.points >= 100)
        {
            SpawnEnemy.points -= 100;
            Movement.healtDebt -= 20;
        }
    }
}
