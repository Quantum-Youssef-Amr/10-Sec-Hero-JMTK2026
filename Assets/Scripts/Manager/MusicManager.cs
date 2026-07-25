using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioClip[] Music;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        if (MusicSource.isPlaying || Music.Length == 0) return;
        MusicSource.clip = Music[Random.Range(0, Music.Length)];
        MusicSource.Play();
    }
}
