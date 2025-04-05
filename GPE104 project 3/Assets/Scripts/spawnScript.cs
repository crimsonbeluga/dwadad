using System;
using NUnit.Framework;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject[] SpawnObjects;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Spawn()
    {
       
        Instantiate(SpawnObjects[0],transform.position, transform.rotation);
        


    }
}
