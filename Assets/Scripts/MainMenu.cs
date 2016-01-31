using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
