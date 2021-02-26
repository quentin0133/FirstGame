using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 0.5f;

    public float finishDelay = 0.5f;

    public float numberSoundTaunt;

    private bool didYouFail = false;

    private bool isPaused = false;

    public GameObject pauseUI;

    public GameObject musicIcon;

    public GameObject musicIconMuted;

    public GameObject voiceIcon;

    public GameObject voiceIconMuted;

    void Start()
    {
        bool isMusicMute = Singleton.Instance.IsMusicMute;
        bool isVoiceMute = Singleton.Instance.IsVoiceMute;

        musicIcon.SetActive(!isMusicMute);
        musicIconMuted.SetActive(isMusicMute);

        voiceIcon.SetActive(!isVoiceMute);
        voiceIconMuted.SetActive(isVoiceMute);
    }

    void Update()
    {
        PauseChecker();
    }

    public void PauseChecker()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
            isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseUI.SetActive(false);
        }
    }

    public void levelFail()
    {
        if (didYouFail == false)
        {
            didYouFail = true;
            if (Random.Range(1f, 100f) >= 80)
            {
                FindObjectOfType<AudioManager>().Play("Taunt death " + Random.Range(1f, numberSoundTaunt).ToString("0"));
            }
            Invoke("restart", restartDelay);
        }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
