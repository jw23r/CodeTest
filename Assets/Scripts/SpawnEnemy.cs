using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform enemydir;//direction the enemy will be spawned in
    public GameObject enemy;//what gameobject to instanite
    float time = 0;//kepps track of time used 
    public float roationSpeed = 20;//used for how fast the spane location should roate
    float randomXOffset;// stores where to set the x offset
    float randomYOffset;// stores where to set the y offset
    public int numOfSpawns;// how many enemys to spawn
    int i = 0;// used to keep track of how many enemys spawned
   

    // Update is called once per frame
    /// <summary>
    /// roates the object
    /// sets a random number for x an y offset
    /// keeps track of time for when to spawn the next object
    /// spawns an enemy at ste of seet location from spawn postion;
    /// </summary>
    void Update()
    {
        transform.Rotate(Vector3.up * roationSpeed * Time.deltaTime);
        randomXOffset = Random.Range(-50, 50);
        randomYOffset = Random.Range(-50, 50);

        Vector3 offset = new Vector3(randomXOffset, 0, randomYOffset);
        time += Time.deltaTime;
        if ( i < numOfSpawns && time > .3f) 
        {
            i++;
            HUDController.numberOfEnemys++;
            Instantiate(enemy, enemydir.position + offset, enemydir.rotation);
            time = 0;
        }
    }
}
