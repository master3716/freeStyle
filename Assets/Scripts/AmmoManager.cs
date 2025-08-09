using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public static int ammo = 50;
    public Text txtAmmo;
    public static RawImage ammoIndecator;
    public RawImage selectedAmmoIndecator;
    public static List<Texture2D> slectAmmoIndecator;
    public List<Texture2D> slectAmmoIndecator2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammo = 50;
        slectAmmoIndecator = slectAmmoIndecator2;
        ammoIndecator = selectedAmmoIndecator;
    }

    // Update is called once per frame
    void Update()
    {
        txtAmmo.text = ammo.ToString();
        selectedAmmoIndecator.texture = ammoIndecator.texture;
    }
}
