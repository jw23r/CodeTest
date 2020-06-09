using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToScreen : MonoBehaviour
{
 

    // Update is called once per frame
    /// <summary>
    /// if objest postion moves out of the the y or x returns them inside the x or y on oppiset side
    /// </summary>
    void Update()
    {
        if (transform.position.x > 98) transform.position = new Vector3(-96,transform.position.y,transform.position.z);
        if (transform.position.x < -98) transform.position = new Vector3(96,transform.position.y,transform.position.z);
        if (transform.position.z < -54) transform.position = new Vector3(transform.position.x, transform.position.y, 53);
        if (transform.position.z > 55) transform.position = new Vector3(transform.position.x, transform.position.y, -52);
    }
}
