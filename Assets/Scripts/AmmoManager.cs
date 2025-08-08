using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public static int ammo = 50;
    public Text txtAmmo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammo = 50;
    }

    // Update is called once per frame
    void Update()
    {
        txtAmmo.text = "" + ammo;
    }
}
