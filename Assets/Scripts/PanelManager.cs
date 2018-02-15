using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    public Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();

    private void Awake()
    {
        
        Panel[] goes = GetComponentsInChildren<Panel>();
        Debug.Log(goes.Length);
        foreach (Panel panel in goes)
        {
            panel.gameObject.SetActive(false);
            panels.Add(panel.panelName, panel.gameObject);
            

        }
    }
}
