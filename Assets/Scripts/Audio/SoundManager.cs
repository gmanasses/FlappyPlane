using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // --- Public Declarations ---
    public static SoundManager Instance;
    public float MasterVolume { get; set; }
    public float MusicVolume { get; set; }
    public float EffectsVolume { get; set; }

    // --- Private Declarations ---
    [SerializeField] private Sound[] _musicSounds, _effectsSounds;
    [SerializeField] private AudioSource _musicSource, _effectsSource;


    //--- Core Functions ---
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        } else {
            Destroy(gameObject);
        }

        SetInitialVolume();
    }

    private void Start() {
        PlayMusic("Background");
    }

    //--- Functions ---
    public void PlayMusic(string musicName) {
        Sound sound = Array.Find(_musicSounds, x => x.Name == musicName);

        if (sound == null) {
            Debug.Log("Sound not Found");

        } else {
            _musicSource.clip = sound.Clip;
            _musicSource.Play();
        }
    }

    public void PlayEffect(string effectName) {
        Sound effect = Array.Find(_effectsSounds, x => x.Name == effectName);

        if (effect == null) {
            Debug.Log("Sound not Found");

        } else {
            _effectsSource.PlayOneShot(effect.Clip);
        }
    }

    public void ChangeMasterVolume(float value) {
        AudioListener.volume = value;
        MasterVolume = value;
        Debug.Log(MasterVolume);
    }

    public void ChangeMusicVolume(float value) {
        _musicSource.volume = value;
        MusicVolume = value;
    }

    public void ChangeEffectsVolume(float value) {
        _effectsSource.volume = value;
        EffectsVolume = value;
    }

    private void SetInitialVolume() {
        MasterVolume = 0.6f;
        ChangeMasterVolume(MasterVolume);

        MusicVolume = 0.8f;
        ChangeMusicVolume(MusicVolume); 
        
        EffectsVolume = 0.8f;
        ChangeEffectsVolume(EffectsVolume);
    }

}


[System.Serializable]
public class Sound {

    // --- Public Declarations ---
    public string Name;
    public AudioClip Clip;

}
