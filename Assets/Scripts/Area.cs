using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public Transform spawnPoint;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
       print("Player entered the area");
    }
    private void OnTriggerExit(Collider other)
    {
        print("Player exited the area");
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.position = spawnPoint.position;
        }
    }
}
