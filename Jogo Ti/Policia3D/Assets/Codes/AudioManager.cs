using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    public static AudioManager instance;
    //public AudioSource sfxSource;
    //public AudioSource musicSource;
    public AudioClip jump;
    public AudioClip mainMusic;
    public AudioClip grunt;
    public AudioClip coin;
    public AudioClip invincible;
    public AudioClip multiplier;
    public AudioClip[] audios;
    public AudioMixer mixer;
    public Slider masterSlider, musicSlider, sfxSlider;

    private void Start()
    {
        musicSource.clip = mainMusic;
        musicSource.Play();
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            LoadMasterVolume();
        }
        else
        {
            SetMasterVolume();
        }

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayAudio(int index)
    {
        sfxSource.clip = audios[index];
        sfxSource.Play();
    }
    public void SetMasterVolume()
    {
        mixer.SetFloat("master", Mathf.Log10(masterSlider.value) * 20);
        PlayerPrefs.SetFloat("masterVolume", masterSlider.value);
        PlayerPrefs.Save();
    }
    public void SetMusicVolume()
    {
        mixer.SetFloat("music", Mathf.Log10(musicSlider.value) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume()
    {
        mixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();
    }

    private void LoadMasterVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume", 0.7f);
        SetMasterVolume();
    }
    private void LoadMusicVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.7f);
        SetMusicVolume();
    }
    private void LoadSFXVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.7f);
        SetSFXVolume();
    }

}