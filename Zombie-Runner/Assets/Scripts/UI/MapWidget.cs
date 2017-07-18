using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapWidget : BasicWidget {

    public static MapWidget m_instace;

    public static MapWidget Instance
    {
        get
        {
            return m_instace;
        }
    }

    public Transform m_Content;
    public List<GameObject> m_ListOfPointOnMap = new List<GameObject>();


    private void Awake()
    {
        m_instace = this;

        foreach(Transform img in m_Content.transform)
        {
            m_ListOfPointOnMap.Add(img.gameObject);
        }
    }

    public Image GetImageById(string id)
    {
        Debug.Log("Geting Image by Id");
        foreach(GameObject img in m_ListOfPointOnMap)
        {
            if (img.name.Equals(id))
            {
                return img.GetComponent<Image>();
            }
        }
        return null;
    }

    public void SetImageColorByName(string id,Color c)
    {
        if (GetImageById(id).color != c)
        {
            GetImageById(id).color = c;
        }
    }
}
