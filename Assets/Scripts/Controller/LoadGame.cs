using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        System.GC.Collect();
        SceneManager.UnloadSceneAsync(0);
        Invoke(nameof(LoadScene), 2.0f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
