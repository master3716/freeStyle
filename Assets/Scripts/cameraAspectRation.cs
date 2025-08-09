using UnityEngine;
using UnityEngine.UI;


public class cameraAspectRation : MonoBehaviour
{
   public float targetAspectWidth = 2560f;
    public float targetAspectHeight = 1440f;

    void Start()
    {
        Camera cam = GetComponent<Camera>();

        float targetAspect = targetAspectWidth / targetAspectHeight;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // Letterbox (black bars top/bottom)
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            cam.rect = rect;
        }
        else
        {
            // Pillarbox (black bars left/right)
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            cam.rect = rect;
        }
    }

}
