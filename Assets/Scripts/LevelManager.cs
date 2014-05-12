using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    
    private EventManager _event = new EventManager();
	// Use this for initialization
	void Start ()
	{
	    EventManager.onPlayerEnter += StartNewMission;
	}

    void StartNewMission()
    {
        Debug.Log("New Mission started!");
    }

    // Update is called once per frame
	void Update () 
    {
	
	}
}
