using UnityEngine;

/// <summary>
/// Responsible for handling the activation and deactivation for ObjectPooling
/// </summary>
public class GO_AudioSource : MonoBehaviour
{
    public AudioSource audioSource;

    private bool startPlaySound;

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();

        startPlaySound = true;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!startPlaySound)
            return;

        if (!audioSource.isPlaying)
        {
            DestroySelf();
        }
    }
}
