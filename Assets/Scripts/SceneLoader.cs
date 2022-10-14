using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        print("Reloading Scene");
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void QuitGame()
    {
        print("Quitting Game");
        Application.Quit();
    }
}