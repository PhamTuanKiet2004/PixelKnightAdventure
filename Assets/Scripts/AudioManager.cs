using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioClip backgroundClip;
    [SerializeField] private AudioClip JumpClick;
    [SerializeField] private AudioClip CoinClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayVolumeAudio();
    }

    // Update is called once per frame
    public void PlayVolumeAudio()
    {
        backgroundAudioSource.clip = backgroundClip;
        backgroundAudioSource.Play();
    }
    public void playCoinSound()
    {
                effectAudioSource.PlayOneShot(CoinClick);

    }
    public void playJumpSound()
    {
        effectAudioSource.PlayOneShot(JumpClick);
    }
}
