using UnityEngine;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance { get; private set; }
    [SerializeField] private AudioMixer MainMixer;
    public bool Music, Sfx;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ToggleMusic()
    {
        Music = !Music;
        MainMixer.SetFloat("Music", Music ? 0 : -80);
    }

    public void ToggleSFX()
    {
        Sfx = !Sfx;
        MainMixer.SetFloat("SFX", Sfx ? 0 : -80);
    }
}
