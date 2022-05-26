using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaterialChanger : MonoBehaviour
{
    private SkinnedMeshRenderer _renderer;
    private MaterialPropertyBlock _mpb;

    private Color matColor;

    private void Awake()
    {
        _renderer = GetComponent<SkinnedMeshRenderer>();
    }

    private void Start()
    {
        matColor = Color.white;
        
        //altera as propriedades dos materais deste objeto especifico sem afetar outros objetos com os mesmos materiais
        _mpb = new MaterialPropertyBlock();
    }

    private void Update()
    {
        matColor = Color.Lerp(matColor, Color.red, Time.deltaTime);
        
        _mpb.SetColor("_BaseColor", matColor);
        _renderer.SetPropertyBlock(_mpb);
    }
}
