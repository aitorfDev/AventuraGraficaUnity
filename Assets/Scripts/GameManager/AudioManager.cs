using UnityEngine;

public enum Audios
{
    Pickup,
    KillGranny,
    Hatch,
    Key,
    None
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip audioPickup;
    [SerializeField] private AudioClip audioGranny;
    [SerializeField] private AudioClip audioKey;
    [SerializeField] private AudioClip audioHatch;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();

                if (audioSource == null)
                {
                    audioSource = FindFirstObjectByType<AudioSource>();
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void emitAudio(Audios audioType)
    {
        
        switch (audioType)
        {
            case Audios.None:
                break;

            case Audios.Pickup:
                audioSource.PlayOneShot(audioPickup);
                break;
            case Audios.KillGranny:
                audioSource.PlayOneShot(audioGranny);
                break;
            case Audios.Hatch:
                audioSource.PlayOneShot(audioHatch);
                break;
            case Audios.Key:
                audioSource.PlayOneShot(audioKey);
                break;

        }
    }
}
