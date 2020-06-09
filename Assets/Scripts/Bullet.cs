using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

   
    Rigidbody bullet; /// the ridgebody of the bullet

    public float speed = 20;    /// how fast the bullet will move

    float time;/// keeps track of time
    // Start is called before the first frame update
    /// <summary>
    /// sets the ridige body
    /// adds force to the ridge body to shoot in direction of foward
    /// </summary>
    void Start()
    {
       
        bullet = GetComponent<Rigidbody>();

       bullet.AddForce(transform.forward * speed , ForceMode.Impulse);

    }
    // Update is called once per frame
    /// <summary>
    /// keeps track of time
    /// removes bullet after 2.5 seconds
    /// </summary>
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2.5) Destroy(gameObject);
    }
    /// <summary>
    /// destroys object if it hits an asteroid or an enemy
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "asteroid" )
        {
        
            Destroy(gameObject);
        }
        
        
    }
}

