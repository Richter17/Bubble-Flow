using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelData : MonoBehaviour {

	public int enemies;
	public string theName;

	public void LoadFromDict( Dictionary<string,object> ht ){
		enemies = (int)(long) ht["Enemies"]; // since all numbers are parsed as long we need to cast them back to int from long
		theName = (string) ht["Name"];
	}

	public Dictionary<string, object> ToDict(){
		Dictionary<string, object> ht = new Dictionary<string, object>();
		ht["Enemies"] = enemies;
		ht["Name"] = theName;
		return ht;
	}
	
}
