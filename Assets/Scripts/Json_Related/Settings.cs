using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Settings : MonoBehaviour {

	// a link to the JSON file
	public TextAsset jsonTA;
//	public string settingsURL;
//	public string locale = "en";

	// the data
	public LevelData[] levelInfo;
	Dictionary<string, object> gameTexts;
	bool audioSetting;

	void Awake(){
//		if(!HasLocalSettings()){
//			if(!string.IsNullOrEmpty(locale)){
//				jsonTA = Resources.Load<TextAsset>("json_"+locale);
//			}
			if(jsonTA!=null){
			Dictionary<string, object> dict = (Dictionary<string, object>) MiniJSON.Json.Deserialize(jsonTA.text);
				LoadDict(dict);
			}

//			if(!string.IsNullOrEmpty(settingsURL)){
//				StartCoroutine(DownloadSettings());
//			}
//		}else{
//			LoadLocalSettings();
//		}
	}

	void LoadDict( Dictionary<string, object> dict ){
		List<object> levelInfoAL = (List<object>) dict["LevelInfo"];
		if(levelInfo!=null){
			foreach(LevelData ld in levelInfo){
				Destroy(ld);
			}
		}
		levelInfo = new LevelData[levelInfoAL.Count];

		for(int i = 0; i < levelInfoAL.Count; i++){
			Dictionary<string, object> levelDataDict = (Dictionary<string, object>) levelInfoAL[i];
			levelInfo[i] = gameObject.AddComponent<LevelData>();
			levelInfo[i].LoadFromDict(levelDataDict);
		}

		gameTexts = (Dictionary<string, object>) dict["GameTexts"];
		audioSetting = (bool) dict["Audio"];

	}

	public Dictionary<string, object> ToDict(){
		Dictionary<string, object> dict = new Dictionary<string, object>();
		List<object> al = new List<object>();
		
		for(int i = 0; i < levelInfo.Length; i++){
			Dictionary<string, object> levelDataHT = levelInfo[i].ToDict();
			al.Add(levelDataHT);
		}

		dict["LevelInfo"] = al;
		dict["GameTexts"] = gameTexts;
		dict["Audio"] = audioSetting;
		return dict;
	}

	//void SaveLocalSettings(){
	//	string json = MiniJSON.Json.Serialize(ToDict());
	//	PlayerPrefs.SetString("settings",json);
	//}

	//void LoadLocalSettings(){
	//	string json = PlayerPrefs.GetString("settings");
	//	LoadDict((Dictionary<string, object>) MiniJSON.Json.Deserialize(json));
	//}
//
//	bool HasLocalSettings(){
//		return PlayerPrefs.HasKey("settings");
//	}
//
//	void Update(){
//		if(Input.GetKeyDown(KeyCode.S)){
//			SaveLocalSettings();
//		}
//		if(Input.GetKeyDown(KeyCode.D)){
//			PlayerPrefs.DeleteAll();
//		}
//	}
	
	//IEnumerator DownloadSettings(){
		
	//	int attempts = 10;
	//	while(attempts-->0){
	//		WWW www = new WWW(settingsURL);
	//		yield return www;
	//		if (!string.IsNullOrEmpty(www.error)){
	//			Debug.LogWarning("error retry");
	//			yield return new WaitForSeconds(1.0f);
	//			continue;
	//		}
	//		Debug.Log(www.text);
	//		Dictionary<string, object> ht = (Dictionary<string, object>) MiniJSON.Json.Deserialize(www.text);
	//		LoadDict(ht);
	//		yield break;
	//	}
	//}

}
