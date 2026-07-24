using UnityEngine;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance { get; private set; }
    [SerializeField] private AudioMixer MainMixer;
    public bool Music, Sfx;
    public int _maxKills, _maxCombo;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        EventBus.Instance.OnEnemyDeath += () => AddToKills(1);
    }

    void OnDestroy()
    {
        EventBus.Instance.OnEnemyDeath -= () => AddToKills(1);
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

    public void AddToKills(int val)
    {
        _maxKills += val;
    }

    public void SetMaxCombo(int val)
    {
        _maxCombo = Mathf.Max(val, _maxCombo);
    }
}
