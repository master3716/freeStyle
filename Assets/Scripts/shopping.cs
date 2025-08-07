using UnityEngine;
using UnityEngine.SceneManagement;

public class shopping : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
        Time.timeScale = 0f;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Shop"));

    }
    public void CloseShop()
    {
        SceneManager.UnloadSceneAsync("Shop");
        Time.timeScale = 1f;
    }
}
