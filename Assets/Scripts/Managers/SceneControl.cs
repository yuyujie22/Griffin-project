using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : Singleton<SceneControl>, IEndGameObserver
{
    GameObject player;
    public GameObject playerPrefab;


    bool fadeFinished;
 
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        
    }
    protected override void OnDestroy()
    {
        base.Awake();
                      
    }

    protected void Start()
    {
        if(player == null)
        {
            player = GameManager.Instance.player;
        }
        
        fadeFinished = true;
    }
    public void TransitionToDestination(TransitionPoint transitionPoint)
    {
        switch(transitionPoint.transitionType){
            case TransitionPoint.TransitionType.sameScene:
                
                StartCoroutine(Transition(SceneManager.GetActiveScene().name,transitionPoint.destinationTag));
                 break;
            case TransitionPoint.TransitionType.differentScene:
                StartCoroutine(Transition(transitionPoint.sceneName,transitionPoint.destinationTag));
                break;


        }
    }
    
    IEnumerator Transition(string sceneName, TransitionDestination.DestinationTag destinationTag)
    {
        
        if(sceneName != SceneManager.GetActiveScene().name)
        {
            //yield return SceneManager.LoadSceneAsync(sceneName);//TODO
            
            //yield return Instantiate(playerPrefab,GetDestination(destinationTag).gameObject.transform.position,GetDestination(destinationTag).gameObject.transform.rotation);
            
            Debug.Log("dif Scene");
            yield return SceneManager.LoadSceneAsync(sceneName);
            Debug.Log(sceneName+"!");
            TransitionDestination.DestinationTag c = (TransitionDestination.DestinationTag)TransitionDestination.DestinationTag.Parse(typeof(TransitionDestination.DestinationTag), sceneName, true);
            Debug.Log(GetDestination(c).gameObject.name+"!!");
            if(player == null)
                player = GameManager.Instance.player;
            
            player= Instantiate(playerPrefab, GetDestination(c).gameObject.transform.position,GetDestination(c).gameObject.transform.rotation);
            yield break;

        }
        else
        {
            Debug.Log(GetDestination(destinationTag).gameObject.name);
            if(player == null)
            {   
                player = GameManager.Instance.player;
            }
            player.transform.SetPositionAndRotation(GetDestination(destinationTag).gameObject.transform.position, GetDestination(destinationTag).gameObject.transform.rotation);
           
            yield return null;  

        }
        
    }
    private TransitionDestination GetDestination(TransitionDestination.DestinationTag destinationTag)
    {
        var entrances = FindObjectsOfType<TransitionDestination>();
        for (int i = 0; i < entrances.Length; i++)
        {   
            if(entrances[i].destinationtag == destinationTag)
            {
                return entrances[i];
            }
        }
        return null;
    }
    public void TransitionToMain()
    {
        StartCoroutine(LoadMain());

    }
 
 
        /// <summary>
    /// 字符串转Enum
    /// </summary>
    /// <typeparam name="T">枚举</typeparam>
    /// <param name="str">字符串</param>
    /// <returns>转换的枚举</returns>
   
    IEnumerator LoadMain()
    {
      
          
          yield return SceneManager.LoadSceneAsync("MainMenu");
          
          yield break;
    }

    public void EndNotify()
    {
        if(fadeFinished)
        {
            Debug.Log("Scene dead");
            fadeFinished = false;
            StartCoroutine(LoadMain());
            
        
        }
        
    }
}
