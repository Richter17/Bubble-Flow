using UnityEngine;
using UnityEditor;
using System.Collections;


public class ClearPlayerPrefs : ScriptableObject
{
    [MenuItem ("Tools/Clear PlayerPrefs")]
    static void ClearPrefs()
    {
     	PlayerPrefs.DeleteAll(); 
    }


}