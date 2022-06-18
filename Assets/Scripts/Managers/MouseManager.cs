using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class MouseManager : Singleton<MouseManager>
{

    override protected void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    } 

    
     


}
