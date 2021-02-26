using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelCompleteUI : MonoBehaviour
{
    public void loadNextLevel()
    {
        FindObjectOfType<AudioManager>().nextMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
