using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FunctionTimer
{

    private static List<FunctionTimer> activeTimerList;
    private static GameObject initGameObject;
    private static void InitIfNeeded() //Initialize the list of FunctionTimers upon the creation of the first timer
    {
        if (initGameObject == null)
        {
            initGameObject = new GameObject("FunctionTimer_InitGameObject");
            activeTimerList = new List<FunctionTimer>();
        }
    }

    public static FunctionTimer Create(Action action, float timer, string timerName = null) //'Create' funtion entry point
    {        
        InitIfNeeded();
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));
        FunctionTimer functionTimer = new FunctionTimer(action, timer, gameObject, timerName);
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.Update;
        activeTimerList.Add(functionTimer);
        return functionTimer;
    }

    private static void RemoveTimer(FunctionTimer functionTimer) //Removes a timer from the FunctionTimer list via timer name
    {
        InitIfNeeded();
        activeTimerList.Remove(functionTimer);
    }

    public static void StopTimer(string timerName)
    {
        for(int i=0; i<activeTimerList.Count; i++)
        {
            if (activeTimerList[i].timerName == timerName)
            {
                activeTimerList[i].DestroySelf();
                i--;
            }
        }
    }

    //Dummy class to have access to MonoBehaviour functions
    public class MonoBehaviourHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();
        }
    }

    // FunctionTimer class below
    float time;
    Action action;
    GameObject gameObject;
    private bool isDestroyed;
    string timerName;

    private FunctionTimer(Action action, float time, GameObject gameObject, string timerName)
    {
        this.action = action;
        this.time = time;
        isDestroyed = false;
        this.gameObject = gameObject;
        this.timerName = timerName;
    }


    public void Update()
    {
        if (!isDestroyed)
        {
            time -= Time.deltaTime;
            if(time < 0) { action(); DestroySelf(); }
        }
    }

    private void DestroySelf()
    {
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
        RemoveTimer(this);
    }
}
