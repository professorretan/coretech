using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager {

    protected static ResourceManager m_Inst;

    Dictionary<string, UnityEngine.Object> cachedObjects = new Dictionary<string, UnityEngine.Object>();

    public static ResourceManager Inst
    {
        get
        {
            if (m_Inst == null)
                m_Inst = new ResourceManager();
            return m_Inst as ResourceManager;
        }
    }

    public static GameObject Create(string prefabName)
    {
        if (!Inst.cachedObjects.ContainsKey(prefabName))
        {
            Inst.cachedObjects[prefabName] = Resources.Load(prefabName);
        }

        return UnityEngine.Object.Instantiate(Inst.cachedObjects[prefabName]) as GameObject;
    }
}
