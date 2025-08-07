using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 10f;
    public float minY = -10f;
    public float maxY = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            Vector3 newPos = transform.position + new Vector3(0, scroll * scrollSpeed, 0);
            newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
            transform.position = newPos;
        }
    }
}
