using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    Rigidbody asteroid;
    public float  randomMin = 20f;
    public float randomMax = 20f;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(randomMin, randomMax);
        asteroid = GetComponent<Rigidbody>();

        asteroid.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);

    }
    // Update is called once per frame
    void Update()
        {

        }

}
