using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class MapSelect : MonoBehaviour
{
    public Texture albedo;
    private GameObject g;
    Renderer m_Renderer;

    void Update()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.SetTexture("_MainTex", albedo);
    }
}
