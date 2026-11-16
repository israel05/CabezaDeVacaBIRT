using UnityEngine;
using UnityEngine.UI;

public sealed class MenuMusicSettings : MonoBehaviour
{
    private const string VolumeKey = "Audio.MusicVolume";

    [SerializeField] private AudioSource music;
    [SerializeField] private Slider volumeSlider;

    private void Awake()
    {
        float volume = PlayerPrefs.GetFloat(VolumeKey, music.volume);
        volumeSlider.SetValueWithoutNotify(volume);
        music.volume = volume;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(VolumeKey, volumeSlider.value);
        PlayerPrefs.Save();
    }
}