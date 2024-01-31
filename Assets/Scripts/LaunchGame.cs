using System;
using System.Collections;
using System.Collections.Generic;
using Attribute;
using Const;
using Manager;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    private void Awake()
    {
        InitCustomAttributes attributes = new InitCustomAttributes();
        attributes.Init(typeof(BindPrefab));
        LoadManager.Instance.Init();
    }

    // Start is called before the first frame update
    void Start()
    {

        UIManager.Instance.Show(GamePaths.START_VIEW);
        //LoadManager.Instance.LoadPrefab("View/Login/StartView", transform);


    }


}
