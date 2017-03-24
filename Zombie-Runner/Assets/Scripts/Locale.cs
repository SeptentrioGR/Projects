using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Locale  {
	public enum Languages
	{
		en,gr
	}
	public Languages langTypes;

	private string textName = "text_";
	private Dictionary<string, LocaleData> mLocaleData = new Dictionary<string, LocaleData>();
	private Dictionary<string, TextAsset> mTextFiles = new Dictionary<string, TextAsset>();

	public void LoadTextAssets()
	{
	   foreach(string name in Enum.GetNames(typeof(Languages)))
		{
			string path = textName + name;
			string filepath = path.Replace(".text", "");	
			TextAsset newAsset = Resources.Load(filepath) as TextAsset;
			mTextFiles.Add(name, newAsset);
		
		}
		
	}

	public TextAsset ReturnTextAssetName()
	{
		foreach(string name in mTextFiles.Keys)
		{
			return mTextFiles[name];
		}
		return null;
	}

	public void PrintAllAssets()
	{
		foreach (string id in mTextFiles.Keys)
		{
			Debug.Log("" + id);
		}
	}

	public void PrintAllData()
	{
		foreach (string id in mLocaleData.Keys)
		{
			Debug.Log(""+mLocaleData[id].id);
		}
	}

	public LocaleData getText(string id)
	{
		LocaleData textData = null;
		if (mLocaleData.TryGetValue(id, out textData))
		{
			return textData;
		}
		return null;
	}

	public void LoadResource(string language)
	{
		TextAsset newAsset;
		if (mTextFiles.TryGetValue(language, out newAsset))
		{
			CreateDataFromText(newAsset.text);
		}
	   
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateDataFromText(string text)
	{
		string mID = "";
		string mValue = "";
		char[] delimiterChars = { ';'};

		string[] words = text.Split(delimiterChars);
		foreach(string w in words)
		{
			char[] dataChars = { ':' };
			string[] others = w.Split(dataChars);
			for(int i = 0; i < others.Length; i++) {
				string s = others[i];
				if (s.Equals("id"))
				{
					mID = others[i + 1];
					Debug.Log(mID);
				}
				if (s.Equals("value"))
				{
					mValue = others[i + 1];
					Debug.Log(mValue);
				}
			}
			LocaleData ld = new LocaleData(mID, mValue);
			mLocaleData.Add(mID, ld);
		}
		
	}


}
public class LocaleData
{
	public string id { get; set; }
	public string value { get; set; }
	public LocaleData(string id,string value)
	{
		this.id = id;
		this.value = value;
	}


}

