using UnityEngine;

public class XiaohanLi_AudioManager : MonoBehaviour
{
    public static XiaohanLi_AudioManager Instance { get; private set; }

    public AudioClip pickupSound;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; 
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Audio clip or AudioSource is missing!");
        }
    }

    public void PlayPickupSound()
    {
        PlaySound(pickupSound);
    }
}
