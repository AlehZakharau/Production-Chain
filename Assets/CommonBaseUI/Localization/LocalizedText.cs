using System;
using Assets.SimpleLocalization;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    public string key;
    public TMP_Text TMPText;

    private void Start()
    {
        LocalizationManager.LocalizationChanged += Translate;
    }

    public void Translate()
    {
        var text = LocalizationManager.Localize(key);
        //Debug.Log($"Translated {this.name} {key}");
        TMPText.text = text;
    }
}
