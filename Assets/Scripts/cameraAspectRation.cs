using UnityEngine;


public class cameraAspectRation : MonoBehaviour
{
   void Awake()
    {
        // Fullscreen = true, monitor refresh rate = preferred
        Screen.SetResolution(2560, 1440, true);
    }
}
