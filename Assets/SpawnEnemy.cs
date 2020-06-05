using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform balldir;
    public GameObject ball;
    float time = 0;
    public float roationSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * roationSpeed * Time.deltaTime);
     
        time += Time.deltaTime;
        if (time > 2) {
            Instantiate(ball, balldir.position, balldir.rotation);
            time = 0;
        }
    }
}
