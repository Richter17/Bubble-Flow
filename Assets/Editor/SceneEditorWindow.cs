using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class SceneEditorWindow : EditorWindow
{

    public static List<EditorBuildSettingsScene> buildScenes = new List<EditorBuildSettingsScene>();
    PopupWindowContent checkIfSureToRemoveScene;
    static string sourceScenePath, destinationScenePath;
    bool showSettings;
    [MenuItem("Window/Scene Editor Menu")]
    static void Init()
    {
        SceneEditorWindow window = (SceneEditorWindow)EditorWindow.GetWindow(typeof(SceneEditorWindow));
    }

    private void OnGUI()
    {
        GUIStyle readLevelsButton = new GUIStyle("button");
        readLevelsButton.fontSize = 15;
        readLevelsButton.fontStyle = FontStyle.Bold;
        GUILayout.Space(20);
        if (GUILayout.Button("Read level list", readLevelsButton, GUILayout.Height(30)))
        {
            //Debug.Log("Go");
            buildScenes = ReadScenes();
        }
        GUILayout.Label("Levels", EditorStyles.boldLabel);
        if (buildScenes.Count <= 0)
        {
            GUILayout.Label("No Levels", EditorStyles.boldLabel);
        }
        else
        {
            //create the lsit of levels in the build settings

            for (int i = 0; i < buildScenes.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                //Take the path of the scene and only take the name of the scene
                string sceneName = buildScenes[i].path.Substring(buildScenes[i].path.LastIndexOf('/')+1);
                sceneName = sceneName.Remove(sceneName.IndexOf(".unity"));
                //write the name
                GUILayout.Label("   " + sceneName, GUILayout.MaxWidth(200), GUILayout.MinWidth(50));
                //Go to the scene in editor button
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Go to",GUILayout.Width(70), GUILayout.Height(20)))
                {
                    
                    EditorSceneManager.OpenScene(buildScenes[i].path);
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Create new scene", GUILayout.Width(120), GUILayout.Height(30)))
        {
            PopupWindow.Show(new Rect(), new CreateScenePopup());
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        showSettings = EditorGUILayout.Foldout(showSettings, "Settings");

        if (showSettings)
        {
            
            EditorGUILayout.BeginHorizontal();
            
            GUILayout.Label("Source scene: ", EditorStyles.boldLabel, GUILayout.Width(130));
            GUILayout.FlexibleSpace();
            if(GUILayout.Button("Browse", GUILayout.Width(70)))
                sourceScenePath = EditorUtility.OpenFilePanel("Scene File","","unity");
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(3);
            GUILayout.Label(sourceScenePath);

            GUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Destination path: ", EditorStyles.boldLabel, GUILayout.Width(130));
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Browse", GUILayout.Width(70)))
                destinationScenePath = EditorUtility.OpenFolderPanel("Scene Destination", "", "");
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(3);
            GUILayout.Label(destinationScenePath);
        }
    }


    public static List<EditorBuildSettingsScene> ReadScenes()
    {
        buildScenes.Clear();
        if (EditorBuildSettings.scenes.Length <= 0) return null;
        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            buildScenes.Add(EditorBuildSettings.scenes[i]);

        }
        return buildScenes;
    }
    
    public static void CreateScene(string sceneName)
    {
        FileUtil.CopyFileOrDirectory(sourceScenePath, destinationScenePath + "\\"+sceneName+".unity" );
        EditorSceneManager.OpenScene(destinationScenePath + "\\" + sceneName + ".unity");
        AssetDatabase.Refresh();
        Debug.Log("Create new scene named: "+ sceneName);
    }
    
    public static void DeleteScene(Scene scenePath)
    {
        Debug.Log(scenePath);
        if(EditorSceneManager.CloseScene(scenePath, false))
        {
            Debug.Log("scene have been deleted");
            AssetDatabase.Refresh();
            
        }
    }

    public class CreateScenePopup : PopupWindowContent
    {
        public string sceneName = "Level";

        public override void OnGUI(Rect rect)
        {
            EditorGUILayout.LabelField("Name your scene:", EditorStyles.wordWrappedLabel);
            GUILayout.Space(20);
            sceneName = EditorGUILayout.TextField(sceneName);
            //Debug.Log(sceneName);
            if(GUILayout.Button("Create"))
            {
               CreateScene(sceneName);
            }
        }
        
    }
}
