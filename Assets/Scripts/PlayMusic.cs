using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip spaceSound1;
    public AudioSource audioSource1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource1.clip = spaceSound1;
        audioSource1.loop = true;
        audioSource1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
