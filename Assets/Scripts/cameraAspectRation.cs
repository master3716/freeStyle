using UnityEngine;



public class cameraAspectRation : MonoBehaviour
{
    public int width = 2560;
    public int height = 1440;

    void Awake()
    {
        // Fullscreen = true, monitor refresh rate = preferred
        Screen.SetResolution(width, height, true);
    }

}