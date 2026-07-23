using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
