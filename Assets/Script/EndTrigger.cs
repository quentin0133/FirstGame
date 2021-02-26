using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject levelCompleteUI;

    void OnTriggerEnter(Collider other)
    {
        levelCompleteUI.SetActive(!levelCompleteUI.activeSelf);
    }

}
