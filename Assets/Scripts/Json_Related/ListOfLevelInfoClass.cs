using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ListOfLevelInfoClass {

    public List<LevelInfo> levels;

    public ListOfLevelInfoClass(List<LevelInfo> levels)
    {
        this.levels = levels;
    }
}
