using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameLoader : MonoBehaviour {

    string json;
    
    List<LevelInfo.ElementsInLevel> elements;
    LevelInfo levelInfo;

    private void Start()
    {
        elements = new List<LevelInfo.ElementsInLevel>();

        //SaveToJson();
        ReadFromJson();
    }
    public void SaveToJson()
    {
        //read all prefabs in the scene
        foreach (IsPrefab go in FindObjectsOfType<IsPrefab>())
        {
            LevelInfo.ElementsInLevel elementInLevel = new LevelInfo.ElementsInLevel(go.name, go.transform.position, go.transform.rotation);
            //Debug.Log(elementInLevel.elementName);
            elements.Add(elementInLevel);
        }
        //create the source level
        //levelInfo = new LevelInfo(0,0,elements);
        //write it to a json file
        json = JsonUtility.ToJson(levelInfo);
        //writing to a file code 

        string jsonFilePath = Application.streamingAssetsPath + "/testJson.txt";
        if (!File.Exists(jsonFilePath))
            File.Create(jsonFilePath);

        File.WriteAllText(jsonFilePath, json);
    }

    public void ReadFromJson()
    {
        string jsonFilePath = Application.streamingAssetsPath + "/testJson.txt";
        if (!File.Exists(jsonFilePath))
            File.Create(jsonFilePath);
        //reading from file a code and then the text will change to level info
        json = File.ReadAllText(jsonFilePath);
        levelInfo = JsonUtility.FromJson<LevelInfo>(json);

        //instaniate all elements from resources folder
        Debug.Log(levelInfo.elementsInLevel[0].elementName);
    }
    
}
