using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SaveManager : Singleton<SaveManager>
{
    override protected void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    } 
    
}
