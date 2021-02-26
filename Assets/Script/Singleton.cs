using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton _instance;

    public static Singleton Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("Singleton");
                go.AddComponent<Singleton>();
            }

            return _instance;
        }
    }

    public bool IsMusicMute { get; set; }

    public bool IsVoiceMute { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _instance = this;
        IsMusicMute = false;
        IsVoiceMute = false;
    }
}
