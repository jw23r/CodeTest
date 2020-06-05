using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform balldir;
    public GameObject ball;
    float time = 0;
    public float roationSpeed = 20;
    float randomXOffset;
    float randomYOffset;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * roationSpeed * Time.deltaTime);
        randomXOffset = Random.Range(-50, 50);
        randomYOffset = Random.Range(-50, 50);

        Vector3 offset = new Vector3(randomXOffset, 0, randomYOffset);
        time += Time.deltaTime;
        if ( i < 10 && time > .3f) 
        {
            i++;

            Instantiate(ball, balldir.position + offset, balldir.rotation);
            time = 0;
        }
    }
}
