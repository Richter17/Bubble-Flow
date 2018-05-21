using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelInfo{

    public int levelIndex;
    public string levelName;
    public float levelScore;
    public List<ElementsInLevel> elementsInLevel;
    [Serializable]
    public class ElementsInLevel{
        public string elementName;
        public Vector3 elementPosition;
        public Quaternion elementRotation;
        public ElementsInLevel(string name, Vector3 pos, Quaternion rot)
        {
            this.elementName = name;
            this.elementPosition = pos;
            this.elementRotation = rot;
        }
    }

    public LevelInfo(int indx, string name, float score, List<ElementsInLevel> elements)
    {
        this.levelIndex = indx;
        this.levelName = name;
        this.levelScore = score;
        this.elementsInLevel = elements;
    }

    
}
