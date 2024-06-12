using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _effectsAudioSource;
    private AudioSource _musicAudioSource;

    [SerializeField] private AudioClip _backgroundTune;
    [SerializeField] private AudioClip _blast;
    [SerializeField] private AudioClip _pickup;

    [SerializeField, Range(0, 1)] private float _musicVolume;
    [SerializeField, Range(0, 1)] private float _soundVolume;

    [SerializeField] private Player _player;

    private void Start()
    {
        _musicAudioSource = gameObject.AddComponent<AudioSource>();
        _effectsAudioSource = gameObject.AddComponent<AudioSource>();

        _musicAudioSource.clip = _backgroundTune;
        _musicAudioSource.loop = true;
        _musicAudioSource.Play();

        _player.Attacker.OnAttack += () => PlaySound(_blast);
    }

    private void PlaySound(AudioClip clip)
    {
        _effectsAudioSource.PlayOneShot(clip, _soundVolume);
    }

    private void Update()
    {
        _musicAudioSource.volume = _musicVolume;
    }

    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        _soundVolume = volume;
    }
}
