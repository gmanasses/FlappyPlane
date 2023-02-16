using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private Slider _masterSlider, _musicSlider, _effectsSlider;
    [SerializeField] private Text _masterText, _musicText, _effectsText;


    // --- Core Functions ---
    void Start() {
        SetSlidersValueOnStart();

        SetVolumesOnStart();

        SetPercentageTextOnStart();

        AddListenersToSliders();
    }


    // --- Functions ---
    private void SetSlidersValueOnStart() {
        _masterSlider.value = SoundManager.Instance.MasterVolume;
        _musicSlider.value = SoundManager.Instance.MusicVolume;
        _effectsSlider.value = SoundManager.Instance.EffectsVolume;
    }

    private void SetVolumesOnStart() {
        SoundManager.Instance.ChangeMasterVolume(SoundManager.Instance.MasterVolume);
        SoundManager.Instance.ChangeMusicVolume(SoundManager.Instance.MusicVolume);
        SoundManager.Instance.ChangeEffectsVolume(SoundManager.Instance.EffectsVolume);
    }

    private void SetPercentageTextOnStart() {
        ChangeMasterVolumePercentageText(_masterSlider.value);
        ChangeMusicVolumePercentageText(_musicSlider.value);
        ChangeEffectsVolumePercentageText(_effectsSlider.value);
    }

    private void AddListenersToSliders() {
        _masterSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
        _musicSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
        _effectsSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeEffectsVolume(val));

        _masterSlider.onValueChanged.AddListener(val => ChangeMasterVolumePercentageText(val));
        _musicSlider.onValueChanged.AddListener(val => ChangeMusicVolumePercentageText(val));
        _effectsSlider.onValueChanged.AddListener(val => ChangeEffectsVolumePercentageText(val));
    }

    private void ChangeMasterVolumePercentageText(float sliderVal) {
        _masterText.text = Math.Round(sliderVal * 100, 1).ToString() + "%";
    }

    private void ChangeMusicVolumePercentageText(float sliderVal) {
        _musicText.text = Math.Round(sliderVal*100, 1).ToString() + "%";
    }

    private void ChangeEffectsVolumePercentageText(float sliderVal) {
        _effectsText.text = Math.Round(sliderVal * 100, 1).ToString() + "%";
    }

}
