using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPoint : MonoBehaviour
{
    public enum TransitionType
    {
        sameScene,differentScene
    }
    [Header("Transition Info")]
    public string sceneName;
    public TransitionType transitionType;
    public TransitionDestination.DestinationTag destinationTag;
    bool canTrans;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)&&canTrans==true)
        {
            //TODO: 传送
            Debug.Log("开始传送");
            SceneControl.Instance.TransitionToDestination(this);
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("进入传送门");
        if(other.CompareTag("Player"))
        {
            canTrans = true;
            Debug.Log("按下T传送");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canTrans = false;
        }
    }
}
