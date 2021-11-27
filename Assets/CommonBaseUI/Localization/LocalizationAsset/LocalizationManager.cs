using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.SimpleLocalization
{
	/// <summary>
	/// Менеджер локализации
	/// </summary>
    public static class LocalizationManager
    {
		//вызываем, когда меняем язык
		public static event Action LocalizationChanged = () => { };
		//Заполняем словари
		public static readonly Dictionary<string, Dictionary<string, string>> Dictionary = new Dictionary<string, Dictionary<string, string>>();
		//Текущий язык
		private static string _language = "English";

		/// <summary>
		/// Свойство для доступа к полю "язык"
		/// </summary>
        public static string Language
        {
            get { return _language; }
            //set { _language = Application.platform == RuntimePlatform.WebGLPlayer ? "English" : value; LocalizationChanged(); }
            set { _language =  value;
	            LocalizationChanged(); }
        }

		/// <summary>
		/// Язык по-умолчанию
		/// </summary>
        public static void AutoLanguage()
        {
            Language = "English";
        }

		public static void ApplyLocalization()
		{
			LocalizationChanged?.Invoke();
		}

		public static void Read(string path = "Localization")
		{
			#if UNITY_WEBGL
				ReadWebGL(path);
			#else
				ReadWindows(path);
			#endif
		}

		/// <summary>
		/// Читаем данные из таблички
		/// </summary>
		private static void ReadWindows(string path = "Localization")
		{
			if (Dictionary.Count > 0) return;

			var textAssets = Resources.LoadAll<TextAsset>(path);

			foreach (var textAsset in textAssets)
			{
				var text = ReplaceMarkers(textAsset.text).Replace("\"\"", "[quotes]");
				var matches = Regex.Matches(text, "\"[\\s\\S]+?\"");

				foreach (Match match in matches)
				{
					text = text.Replace(match.Value, match.Value.Replace("\"", null).Replace(",", "[comma]").Replace("\n", "[newline]"));
				}

				var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
				var languages = lines[0].Split(',').Select(i => i.Trim()).ToList();

				for (var i = 1; i < languages.Count; i++)
				{
					if (!Dictionary.ContainsKey(languages[i]))
					{
						Dictionary.Add(languages[i], new Dictionary<string, string>());
					}
				}

				for (var i = 1; i < lines.Length; i++)
				{
					var columns = lines[i].Split(',').Select(j => j.Trim()).Select(j => j.Replace("[comma]", ",").Replace("[newline]", "\n").Replace("[quotes]", "\"")).ToList();
					var key = columns[0];

					if (key == "") continue;

					for (var j = 1; j < languages.Count; j++)
					{
						Dictionary[languages[j]].Add(key, columns[j]);
					}
				}
			}
			//AutoLanguage();
		}
		/// <summary>
		/// Читаем данные из таблички
		/// </summary>
		private static void ReadWebGL(string resultText)
        {
            if (Dictionary.Count > 0) return;
  
            string textD = resultText;
            //Debug.Log($" text downloaded {textD.Length}");
            string[] lines = textD.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
  
			var languages = lines[0].Split(',').Select(d => d.Trim()).ToList();
  
  
            for (var j = 1; j < languages.Count; j++)
            {
	            //Debug.Log($"{languages[j]}, {languages.Count}");
	            if (!Dictionary.ContainsKey(languages[j]))
	            {
		            Dictionary.Add(languages[j], new Dictionary<string, string>());
	            }
            }
  
            for (var k = 1; k < lines.Length; k++)
            {
	            var columns = lines[k].Split(',').Select(j => j.Trim()).Select(j =>
		            j.Replace("[comma]", ",").Replace("[newline]", "\n").Replace("[quotes]", "\"")).ToList();
	            var key = columns[0];
  
	            if (key == "") continue;
  
	            for (var j = 1; j < languages.Count; j++)
	            {
		            //Debug.Log($"Key : {key}, word: {columns[j]}");
		            Dictionary[languages[j]].Add(key, columns[j]);
	            }
            }
  
            LocalizationChanged?.Invoke();
            AutoLanguage();
        }

		/// <summary>
		/// Производим поиск по ключевому слову
		/// </summary>
		/// <param name="localizationKey"></param>
		/// <returns></returns>
	    public static bool HasKey(string localizationKey)
	    {
		    return Dictionary[Language].ContainsKey(localizationKey);
	    }

	    /// <summary>
		/// Получаем значение из соответствующей колонки таблички, по ключевому слову
		/// </summary>
		public static string Localize(string localizationKey)
        {
			if (Dictionary.Count == 0)
	        {
		        Debug.Log($"Dictionary null");
		        //Read(Downloader.resultText);
		        Read();
	        }

			//if (!Dictionary.ContainsKey(Language)) throw new KeyNotFoundException("Language not found: " + Language); //Debug

			if (!Dictionary.ContainsKey(Language))
			{
				Language = "English";
				Debug.Log($"Key was changed to english");
			}

			if (!Dictionary[Language].ContainsKey(localizationKey))
			{
				Debug.Log($"Key has been not found");
				throw new KeyNotFoundException("Translation not found: " + localizationKey);
			}

			if (Language == "English")
			{
				//Debug.Log($"it was english");
				return Dictionary[Language][localizationKey];
			}

	        var missed = !Dictionary[Language].ContainsKey(localizationKey) || string.IsNullOrEmpty(Dictionary[Language][localizationKey]);

	        if (missed)
	        {
		        Debug.LogWarningFormat("Translation not found: {localizationKey} ({0}).", Language);

		        return Dictionary["English"].ContainsKey(localizationKey) ? Dictionary["English"][localizationKey] : localizationKey;
	        }

	        //Debug.Log($"'return {Dictionary[Language][localizationKey]}");
	        return Dictionary[Language][localizationKey];
		}

	    /// <summary>
	    /// Перегрузка метода для форматированного вывода
	    /// </summary>
		public static string Localize(string localizationKey, params object[] args)
        {
            var pattern = Localize(localizationKey);

            return string.Format(pattern, args);
        }

		/// <summary>
		/// "Костыль", чтобы подставлять в шрифт символ из другого шрифта, если его нет, а он нужен
		/// </summary>
		/// <returns></returns>
	    public static string GetChars()
	    {
		    var asset = Resources.Load<TextAsset>("Localization/Common");

		    if (asset == null) return "";

		    var chars = new List<char>();

		    foreach (var s in "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZАаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~Ξ ") if (!chars.Contains(s)) chars.Add(s);
		    foreach (var s in asset.text)
		    {
			    if (!chars.Contains(char.ToLower(s))) chars.Add(char.ToLower(s));
			    if (!chars.Contains(char.ToUpper(s))) chars.Add(char.ToUpper(s));
		    }

		    chars.Sort();

		    var text = new System.Text.StringBuilder();

		    foreach (var s in chars) text.Append(s);

		    return text.ToString();
	    }

		/// <summary>
		/// Чтобы можно было заменять некоторые символы
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
	    private static string ReplaceMarkers(string text)
        {
            return text.Replace("[Newline]", "\n");
        }
    }
}