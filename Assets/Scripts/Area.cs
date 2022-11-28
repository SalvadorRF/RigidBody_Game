using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    // when the player try to exit the area he will be teleported to the spawn point
    public Transform spawnPoint;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
