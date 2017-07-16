using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWidget : BasicWidget {
    public static MapWidget m_instace;
    public static MapWidget Instance
    {
        get
        {
            return m_instace;
        }
    }
    private void Awake()
    {
        m_instace = this;
    }

}
