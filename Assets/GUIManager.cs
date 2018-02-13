using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

    private static GUIManager m_Instance;
    public static GUIManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public GameObject[] ListOfPanels;
    private Dictionary<string, GameObject> ListOfPanelsByID = new Dictionary<string, GameObject>();

    private void Awake()
    {
        m_Instance = this;
    }

    void Start () {
        foreach (var item in ListOfPanels)
        {
            ListOfPanelsByID.Add(item.name, item);
        }
	}

    public void ShowPanel(string id,bool value = true)
    {
        GameObject panel = null;
        if (ListOfPanelsByID.TryGetValue(id, out panel))
        {
            panel.SetActive(value);
        }
    }


    public GameObject GetPanel (string id)
    {
        GameObject panel = null;
        if (ListOfPanelsByID.TryGetValue(id, out panel))
        {
            return panel;
        }
        return null;
    }

    void Update () {
		
	}
}
