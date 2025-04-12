using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite musicOnIcon;
    public Sprite musicOffIcon;
    public Sprite buttonImage;

    void Start()
    {
        UpdateIcon();
    }

    public void OnMusicButtonClick()
    {
        MusicManager.Instance.ToggleMusic();
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (MusicManager.Instance.IsMusicOn())
        {
            buttonImage = musicOnIcon;
        }
        else
        {
            buttonImage = musicOffIcon;
        }
    }
}
