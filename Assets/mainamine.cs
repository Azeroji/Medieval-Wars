using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoaderAndUnloader : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to load
    public float delay;
    void Start()
    {
        StartCoroutine(LoadAndUnloadScene());
    }

    IEnumerator LoadAndUnloadScene()
    {
        // Load the scene
        ParamsSceneAnimation.name = "amine";
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        // Wait for 10 seconds
        yield return new WaitForSeconds(delay);

        // Unload the scene after waiting
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
