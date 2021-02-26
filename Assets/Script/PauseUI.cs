using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public void DisplayGameObject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }   
}
