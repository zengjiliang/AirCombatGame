using System;
using System.Collections;
using System.Collections.Generic;
using Attribute;
using Const;
using Manager;
using Module.Reader;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    private void Awake()
    {
        InitCustomAttributes attributes = new InitCustomAttributes();
        attributes.Init(typeof(BindPrefab));
        LoadManager.Instance.Init();
    }

    private const string cJson = "{'planes':[{'planeId':0,'level':1,'attack':5,'fireRate':0.8,'life':100}]}";
    // Start is called before the first frame update
    void Start()
    {

        UIManager.Instance.Show(GamePaths.START_VIEW);
        //LoadManager.Instance.LoadPrefab("View/Login/StartView", transform);
        JsonReader read = new JsonReader();
        read["planes"][0]["fireRate"].Get<float>((val)=>Debug.Log(val));
        read.SetData(cJson);
    }


}
