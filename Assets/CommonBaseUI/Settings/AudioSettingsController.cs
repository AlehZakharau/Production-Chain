using CommonBaseUI.Data;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CommonBaseUI.Settings
{
    public class AudioSettingsController : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider sliderSound;
        [SerializeField] private Slider sliderMusic;
        //[SerializeField] private Slider sliderVoice;
        [SerializeField] private GameSettingsDataManager gameSettingsDataManager;
        
        private void Start()
        {
            sliderSound.value = gameSettingsDataManager.SoundVolume;
            sliderMusic.value = gameSettingsDataManager.MusicVolume;
            //sliderVoice.value = data.VoiceVolume;
            mixer.SetFloat("SoundVolume", Mathf.Log10(sliderSound.value) * 20);
            mixer.SetFloat("MusicVolume", Mathf.Log10(sliderMusic.value) * 20);
            //mixer.SetFloat("VoiceVolume", Mathf.Log10(sliderVoice.value) * 20);
        }

        public void ChangeSoundVolume()
        {
            var volume = Mathf.Log10(sliderSound.value) * 20;
            mixer.SetFloat("SoundVolume", volume);
            gameSettingsDataManager.SoundVolume = sliderSound.value;
        }

        public void ChangeMusicVolume()
        {
            var volume = Mathf.Log10(sliderMusic.value) * 20;
            mixer.SetFloat("MusicVolume", volume);
            gameSettingsDataManager.MusicVolume = sliderMusic.value;
        }

        // public void ChangeVoiceVolume()
        // {
        //     var volume = Mathf.Log10(sliderVoice.value) * 20;
        //     mixer.SetFloat("VoiceVolume", volume);
        //     data.VoiceVolume = sliderVoice.value;
        // }
    }
}