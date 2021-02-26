using UnityEngine;
using UnityEngine.SceneManagement;

public class Bienvenue : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
