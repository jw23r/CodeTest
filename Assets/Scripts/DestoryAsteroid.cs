using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAsteroid : MonoBehaviour
{
    // Start is called before the first frame update
   /// <summary>
   /// if gets hit by player bullet it gets destroyed and adds 10 points to score
   /// if hits player they lose 1 life
   /// </summary>
   /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Bullet")
        {
            HUDController.score += 10;
            HUDController.numberOfEnemys -= 1;
            Destroy(gameObject);

        }
        if (collider.transform.tag == "Player")
        {
            HUDController.lives -= 1;

    

        }

    }
}
