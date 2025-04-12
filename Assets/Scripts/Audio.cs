using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip background;
    private const string MUSIC_KEY = "MusicOn";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = background;

            bool isMusicOn = PlayerPrefs.GetInt(MUSIC_KEY, 1) == 1;
            audioSource.mute = !isMusicOn;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
        PlayerPrefs.SetInt(MUSIC_KEY, audioSource.mute ? 0 : 1);
    }

    public bool IsMusicOn()
    {
        return !audioSource.mute;
    }
}
