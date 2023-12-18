using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    AudioSource audio;
    public AudioClip deathSong;
    public AudioClip gameSong;


    [Range(0f, 1f)]
    public float volume;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        volume = 0.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameSong();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeathSong()
    {
        audio.clip = deathSong;
        audio.volume = volume;
        audio.Play();
    }

    public void GameSong()
    {
        audio.clip = gameSong;
        audio.volume = volume;
        audio.Play();
    }

}
