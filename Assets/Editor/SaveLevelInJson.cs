using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveLevelInJson : ScriptableObject {

    static string json;
    static List<LevelInfo.ElementsInLevel> elements = new List<LevelInfo.ElementsInLevel>();
    static LevelInfo levelInfo;
    static List<LevelInfo> levels;
    

    [MenuItem("Tools/Save Scene")]
    public static void SaveLevel()
    {
        //read all prefabs in the scene
        foreach (IsPrefab go in FindObjectsOfType<IsPrefab>())
        {
            LevelInfo.ElementsInLevel elementInLevel = new LevelInfo.ElementsInLevel(go.name, go.transform.position, go.transform.rotation);
            elements.Add(elementInLevel);
        }

        //insert the info into the current level
        LevelDesignerWindow.currentLevelInfo.elementsInLevel = elements;

        //read the json file and convert it to the levels     
        //TextAsset jsonFilePath = Resources.Load("Json_Level_List") as TextAsset;
        //levels = JsonUtility.FromJson<ListOfLevelInfoClass>(jsonFilePath.text).levels;
        levels = LevelDesignerWindow.ReadFromListJsonFile();
        if (levels==null)
        {    
            levels = new List<LevelInfo>();
        }

        if(levels.Exists(x => x.levelIndex == LevelDesignerWindow.currentLevelInfo.levelIndex))
        {
            Debug.Log("it's exist");
            levels[LevelDesignerWindow.currentLevelInfo.levelIndex] = LevelDesignerWindow.currentLevelInfo;
            
        }
        else
        {
            levels.Add(LevelDesignerWindow.currentLevelInfo);
        }

        //adding the current level to the levels
        
        ListOfLevelInfoClass listOfLevels = new ListOfLevelInfoClass(levels);
        

        //write the levels list back to the json file
        json = JsonUtility.ToJson(listOfLevels);

        File.WriteAllText(LevelDesignerWindow.levelsListJson, json);
        Debug.Log("Level saved");
        AssetDatabase.Refresh();
    }
}
