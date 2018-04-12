using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelsScene : MonoBehaviour {

    public string level;

    public void OpenLevel()
    {
        SceneManager.LoadScene(level);
    }
}
