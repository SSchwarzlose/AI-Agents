using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    private int currentLevel;

    void Start()
    {
        currentLevel = Application.loadedLevel;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
            Application.LoadLevel(currentLevel+1);
    }
}
