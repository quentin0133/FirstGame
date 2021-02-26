using UnityEngine;
using UnityEngine.UI;

public class ProgressionScript : MonoBehaviour
{
    private Transform playerTransform;
    public Text scoreText;
    public Transform endGameHitboxTransform;

    // Update is called once per frame
    void Update()
    {
        playerTransform = FindObjectOfType<MovementPlayer>().transform;
        float progression = (playerTransform.position.z / endGameHitboxTransform.position.z) * 100;
        if (progression < 100)
        {
            scoreText.text = (progression).ToString("0") + "%";
        }
        else
        {
            scoreText.text = "100%";
        }
    }
}
