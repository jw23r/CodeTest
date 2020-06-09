using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    Rigidbody asteroid;// the ridged body of the gameobject to add force too
    public float  randomMin = 20f;//the min force applied 
    public float randomMax = 20f;// the max force applied
    float speed;//how fast the object will move
    // Start is called before the first frame update
    /// <summary>
    /// sets the spped to a random amount between min and the max
    /// gets the ridge body on the gameobject
    /// adds force to the object based on the speed
    /// </summary>
    void Start()
    {
        speed = Random.Range(randomMin, randomMax) + Random.Range(randomMin, randomMax);
        asteroid = GetComponent<Rigidbody>();

        asteroid.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);

    }

}
