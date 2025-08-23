using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public float speed = 3f;
    private float timer = 0f;
    public static int aliveLasar = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.name != "laser")
            aliveLasar++;
        int rand = Random.Range(1, 100);
        if (rand > 50)
            speed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (timer >= 4f && gameObject.name != "laser")
        {
            Destroy(gameObject);
        }

    }
    void OnDestroy()
    {
        aliveLasar--;
    }
}
