using System.Collections;
using System.IO;
using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.Networking;

namespace UI.Data
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] private SaveLoadJsonWindows saveLoadJsonWindows;
        [SerializeField] private SaveLoadJsonWeb saveLoadJsonWeb;
        
        private readonly Data data = new Data();

        private const string Filename = "GameData";

        #region Property

        public float SoundVolume
        {
            get => data.soundVolume;
            set
            {
                data.soundVolume = value;
                saveLoadJson.SaveToJson(Filename, data);
            }
        }

        public float MusicVolume
        {
            get => data.musicVolume;
            set
            {
                data.musicVolume = value;
                saveLoadJson.SaveToJson(Filename, data);
            }
        }
        
        public float VoiceVolume
        {
            get => data.voiceVolume;
            set
            {
                data.voiceVolume = value;
                saveLoadJson.SaveToJson(Filename, data);
            }
        }

        public bool FullScreen
        {
            get => data.fullScreen;
            set
            {
                data.fullScreen = value;
                saveLoadJson.SaveToJson(Filename, data);
            }
        }
        public int ResWidth
        {
            get => data.resWidth;
            set
            {
                data.resWidth = value;
                saveLoadJson.SaveToJson(Filename, data);
            }
        }
        public int ResHeight
        {
            get => data.resHeight;
            set
            {
                data.resHeight = value;
                saveLoadJson.SaveToJson(Filename, data);
            }
        }
        public ScreenResolutions16and9 Resolution
        {
            get => data.resolution;
            set
            {
                data.resolution = value;
                saveLoadJson.SaveToJson(Filename, data);
            }
        }

        public Languages Languages
        {
            get => data.currentLanguage;
            set
            {
                data.currentLanguage = value;
                saveLoadJson.SaveToJson(Filename, data);
            }
        }

        #endregion

        private SaveLoadJson saveLoadJson;

        private void Start()
        {
            #if UNITY_WEBGL
                saveLoadJson = saveLoadJsonWeb;
                saveLoadJson.LoadFromJson(FILENAME, data);
            #else
                saveLoadJson = saveLoadJsonWindows;
                saveLoadJson.LoadFromJson(Filename, data);
            #endif
        }
    }
}