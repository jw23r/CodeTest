using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAsteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Bullet")
        {
            HUDController.score += 10;
            Destroy(gameObject);

        }
        if (collider.transform.tag == "Player")
        {
            HUDController.lives -= 1;
            Destroy(gameObject);

        }

    }
}
