using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody bullet;
    public float randomMin = 20f;
    public float randomMax = 20f;
   public float speed = 20;
     float time;
    // Start is called before the first frame update
    void Start()
    {
       
        bullet = GetComponent<Rigidbody>();

       bullet.AddForce(transform.forward * speed , ForceMode.Impulse);

    }
    // Update is called once per frame

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2.5) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "asteroid")
        {
        
            Destroy(gameObject);
        }
        
        
    }
}

