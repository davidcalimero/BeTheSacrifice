using UnityEngine;
using UnityEngine.SceneManagement;

class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
            SceneManager.LoadScene(1);
    }
}
