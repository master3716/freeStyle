using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioClip spaceSound1;
    public AudioSource audioSource1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        GameObject tempSound = new GameObject("TempSound");
        AudioSource tempSource = tempSound.AddComponent<AudioSource>();
        tempSource.clip = spaceSound1;
        tempSource.Play();
        DontDestroyOnLoad(tempSound);

        Destroy(tempSound, spaceSound1.length); 

        SceneManager.LoadScene("Main");
        
    }
}
