using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosingScreen : MonoBehaviour
{
    public Text txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txt.text = "You Lost\n Score: " + SpawnEnemy.points;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAgain()
    {
        SpawnEnemy.points = 0;
        SceneManager.LoadScene("Main");
        
    }
}
