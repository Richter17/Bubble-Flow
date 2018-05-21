using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LevelDesignerWindow : EditorWindow
{

    public static List<LevelInfo> levels = new List<LevelInfo>();
    public static LevelInfo currentLevelInfo;
    public readonly static string NEW_LEVEL_JSON = "New_Level_Json_File_Path";
    public readonly static string LEVELS_LIST_JSON = "Levels_List";


    public static string newLevelJsonPath;
    public static string levelsListJson;
    bool showSettings;
    static TextAsset jsonLevels;

    [MenuItem("Tools/Level Designer")]
    static void Init()
    {
        LevelDesignerWindow window = (LevelDesignerWindow)EditorWindow.GetWindow(typeof(LevelDesignerWindow));
        window.title = "Level Designer";

        ReadFromPlayerPref();
    }

    private void OnGUI()
    {
        #region button Read Levels
        //the GUI style of the button
        GUIStyle readLevelsButton = new GUIStyle("button");
        readLevelsButton.fontSize = 15;
        readLevelsButton.fontStyle = FontStyle.Bold;
        

        //the button itself
        GUILayout.Space(20);
        if (GUILayout.Button("Read level list", readLevelsButton, GUILayout.Height(30)))
        {
            AssetDatabase.Refresh();
            levels = ReadFromListJsonFile();
        }
        #endregion

        #region Levels List
        GUILayout.Label("Levels", EditorStyles.boldLabel);

        
        if (levels.Count <= 0)
        {
            //when there is an error and there no levels or in start of window
            GUILayout.Label("No Levels", EditorStyles.boldLabel);
        }
        else
        {
            //create the list of levels in the build settings

            for (int i = 0; i < levels.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();

                GUILayout.Label("Level " + levels[i].levelIndex + ": " + levels[i].levelName, GUILayout.MaxWidth(200), GUILayout.MinWidth(50));

                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Load", GUILayout.Width(70), GUILayout.Height(20)))
                {

                    //load the scene with the json file
                    LoadLevel(levels[i].levelIndex);
                }
                if (i == 0)
                {
                    EditorGUILayout.EndHorizontal();
                    continue;
                }

                if (GUILayout.Button("Delete", GUILayout.Width(70), GUILayout.Height(20)))
                {
                    DeleteLevelpopUp popup = new DeleteLevelpopUp();
                    popup.levelIndex = levels[i].levelIndex;
                    PopupWindow.Show(new Rect(), popup);
                    //Delete The Level Specified
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        #endregion

        #region Create New Scene
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Create new level", GUILayout.Width(120), GUILayout.Height(30)))
        {
            //Show pop up of creating new scene
            
            PopupWindow.Show(new Rect(), new CreateScenePopup());
        }
        #endregion

        #region Settings
        //The Source of Levels List Json file
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showSettings = EditorGUILayout.Foldout(showSettings, "Settings");

        //foldout options
        if (showSettings)
        {

            //Check if needed, maybe can delete this
            ReadFromPlayerPref();
            EditorGUILayout.BeginHorizontal();

            #region New Level Source Json file
            GUILayout.Label("Source new level Json: ", EditorStyles.boldLabel, GUILayout.Width(200));
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Browse", GUILayout.Width(70)))
                newLevelJsonPath = EditorUtility.OpenFilePanel("Json file", "", "txt");

            if (newLevelJsonPath != string.Empty)
            {
                PlayerPrefs.SetString(NEW_LEVEL_JSON, newLevelJsonPath);
            }

            EditorGUILayout.EndHorizontal();
            #endregion

            GUILayout.Space(3);
            GUILayout.Label(newLevelJsonPath);

            GUILayout.Space(10);

            #region Levels List Json File
            //The Level list json file source control. Important Don't Delete
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Level List Json File: ", EditorStyles.boldLabel, GUILayout.Width(200));
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Browse", GUILayout.Width(70)))
                levelsListJson = EditorUtility.OpenFilePanel("Json File", "", "txt");
            if (levelsListJson != string.Empty)
            {
                PlayerPrefs.SetString(LEVELS_LIST_JSON, levelsListJson);
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(3);
            GUILayout.Label(levelsListJson);
            #endregion
        }
        #endregion
    }

    //popup for new scene creator
    public class CreateScenePopup : PopupWindowContent
    {
        public string sceneName = "Level Name";

        public override void OnGUI(Rect rect)
        {
            EditorGUILayout.LabelField("Name your scene:", EditorStyles.wordWrappedLabel);
            GUILayout.Space(20);
            sceneName = EditorGUILayout.TextField(sceneName);
            //Debug.Log(sceneName);
            if (GUILayout.Button("Create"))
            {
                LoadNewScene(sceneName);
                Debug.Log("Current Level is loaded");
            }
        }

    }

    //popup for deleteing scene
    public class DeleteLevelpopUp : PopupWindowContent
    {
        public int levelIndex;

        public override void OnGUI(Rect rect)
        {
            EditorGUILayout.LabelField("Are you sure you want to delete this level?", EditorStyles.wordWrappedLabel);
            GUILayout.Space(20);
            //Debug.Log(sceneName);
            if (GUILayout.Button("Yes"))
            {
                if (levelIndex == 0)
                {
                    Debug.Log("something went wrong. not deleted");
                    return;
                }
                DeleteLevel(levelIndex);
            }
        }
    }

    public class LoadLevelPopUp : PopupWindowContent
    {
        public int levelIndex;

        public override void OnGUI(Rect rect)
        {
            EditorGUILayout.LabelField("Make sure you saved the level you currently working at!", EditorStyles.wordWrappedLabel);
            GUILayout.Space(20);
            //Debug.Log(sceneName);
            if (GUILayout.Button("Save and load"))
            {
                SaveLevelInJson.SaveLevel();
                LoadLevel(levelIndex);
                Debug.Log("Saved the new level and loaded the level");
            }

            if (GUILayout.Button("Just load"))
            {
                LoadLevel(levelIndex);
                Debug.Log("Loaded level");
            }
        }
    }

    //Creates A new scene and gives the value of the name to it
    public static void LoadNewScene(string sceneName)
    {
        string json = File.ReadAllText(newLevelJsonPath);
        currentLevelInfo = JsonUtility.FromJson<LevelInfo>(json);
        currentLevelInfo.levelName = sceneName;

        levels = ReadFromListJsonFile();

        currentLevelInfo.levelIndex = levels.Count;
        currentLevelInfo.levelScore = 0;

        LoadLevel(0);
        Debug.Log("Loaded source level for new level creation");

        //instaniate all elements into the scene from resources folder
    }

    //Read From PlayerPref the Sources paths
    static void ReadFromPlayerPref()
    {
        if (!PlayerPrefs.HasKey(NEW_LEVEL_JSON))
        {
            PlayerPrefs.SetString(NEW_LEVEL_JSON, "");
        }
        newLevelJsonPath = PlayerPrefs.GetString(NEW_LEVEL_JSON);
        if (!PlayerPrefs.HasKey(LEVELS_LIST_JSON))
        {
            PlayerPrefs.SetString(LEVELS_LIST_JSON, "");
        }
        levelsListJson = PlayerPrefs.GetString(LEVELS_LIST_JSON);
    }

    //Read the level list from json file return null if there error
    public static List<LevelInfo> ReadFromListJsonFile()
    {
        if (levelsListJson != string.Empty)
        {
            if (levelsListJson.Contains("Resources"))
            {
                string thePath = levelsListJson.Remove(levelsListJson.IndexOf(".txt")).Substring(levelsListJson.IndexOf("Resources/") + 10);
                //thePath = thePath.Remove(thePath.IndexOf(".txt"));
                //Debug.Log(thePath);
                jsonLevels = (TextAsset)Resources.Load(thePath);
                //Debug.Log("return list successfuly");
                return JsonUtility.FromJson<ListOfLevelInfoClass>(jsonLevels.text).levels;
            }
            else
            {
                if (File.Exists(levelsListJson))
                {
                    //Debug.Log("return list successfuly");
                    return JsonUtility.FromJson<ListOfLevelInfoClass>(levelsListJson).levels;
                }
                else
                {
                    Debug.Log("the path isn't correct, please check the settings Levels list path");
                    return null;
                }
            }
            

        }
        else
        {
            Debug.Log("There is no path to the json file");
            return null;
        }
    }

    //load a specific level from the level list
    static void LoadLevel(int levelIndex)
    {
        //read all prefabs in the scene
        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            DestroyImmediate(go);
        }

        currentLevelInfo = levels[levelIndex];

        foreach (LevelInfo.ElementsInLevel element in levels[levelIndex].elementsInLevel)
        {
            Instantiate((GameObject)Resources.Load("Prefabs/" + element.elementName), element.elementPosition, element.elementRotation);
        }
        //Debug.Log("Loaded level");
    }

    //delete a specific level and reorder the levels indexes
    static void DeleteLevel(int levelIndex)
    {
        levels = ReadFromListJsonFile();
        string deletedLevelName = levels[levelIndex].levelName;
        if (levels.Remove(levels[levelIndex]))
        {
            for (int i = 0; i < levels.Count; i++)
            {
                levels[i].levelIndex = i;
            }
            ListOfLevelInfoClass levelsWithoutLevel = new ListOfLevelInfoClass(levels);
            string json = JsonUtility.ToJson(levelsWithoutLevel);
            File.WriteAllText(levelsListJson, json);
            AssetDatabase.Refresh();
            Debug.Log("delete " + deletedLevelName + " Level");
        }
        else
        {
            Debug.Log("Can't find the level, Error!");
        }

        
    }

}
