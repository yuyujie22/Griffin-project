using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager :   Singleton<GameManager>
{
    public GameObject player;
    CinemachineVirtualCamera followCamera;
    override protected void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }   
    public void RegisterPlayer(GameObject pl)
    {
        player = pl;
        followCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if(followCamera != null)
        {
            followCamera.Follow = player.transform.GetChild(2);
            followCamera.LookAt= player.transform.GetChild(2);
        }
    }
    /*public Transform GetEntrance()
    {
        foreach (var item in FindObjectsOfType<TransitionDestination>())
        {
            if(item.destinationtag == TransitionDestination.DestinationTag.ENTER)
            {
                
                return item.transform;
               

            }
            
        }
        
        return null;

    }*/
}
