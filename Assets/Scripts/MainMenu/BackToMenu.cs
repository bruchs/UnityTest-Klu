using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
