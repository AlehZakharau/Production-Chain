using System;
using System.Runtime.Serialization;
using Assets.SimpleLocalization;
using UnityEditor.Experimental.GraphView;

namespace UI.Data
{
    [Serializable]
    public sealed class Data : ISerializable
    {
        public float soundVolume = 1;
        public float musicVolume = 1;
        public float voiceVolume = 1;
        public bool fullScreen;
        public ScreenResolutions16and9 resolution;
        public Languages currentLanguage;
        public int resWidth;
        public int resHeight;
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}