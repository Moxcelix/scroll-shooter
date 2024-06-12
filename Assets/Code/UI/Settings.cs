using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundVolumeSlider;

    [SerializeField] private SoundManager _soundManager;

    private void Start()
    {
        if (PlayerPrefs.HasKey("sound"))
        {
            var volume = PlayerPrefs.GetFloat("sound");
            _soundManager.SetSoundVolume(volume);
            _soundVolumeSlider.value = volume;

        }
        if (PlayerPrefs.HasKey("music"))
        {
            var volume = PlayerPrefs.GetFloat("music");
            _soundManager.SetMusicVolume(volume);
            _musicVolumeSlider.value = volume;
        }
    }

    private void Update()
    {
        _soundManager.SetSoundVolume(_soundVolumeSlider.value);
        PlayerPrefs.SetFloat("sound", _soundVolumeSlider.value);
        _soundManager.SetMusicVolume(_musicVolumeSlider.value);
        PlayerPrefs.SetFloat("music", _musicVolumeSlider.value);
    }
}
