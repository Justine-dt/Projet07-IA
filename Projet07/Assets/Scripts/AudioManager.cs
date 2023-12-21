using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _deathSong;
    [SerializeField] private AudioClip _gameSong;
    private AudioSource _audio;

    [Range(0f, 1f)]
    [SerializeField] private float _volume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _volume = 0.5f;
    }

    void Start()
    {
        GameSong();
    }

    public void DeathSong()
    {
        _audio.clip = _deathSong;
        _audio.volume = _volume;
        _audio.Play();
    }

    public void GameSong()
    {
        _audio.clip = _gameSong;
        _audio.volume = _volume;
        _audio.Play();
    }
}