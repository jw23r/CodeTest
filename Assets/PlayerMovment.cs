using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5;
    public float maxMoveSpeed = 15;
    CharacterController body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {


            transform.LookAt(new Vector3(hit.point.x, 0, hit.point.z));

        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") > 0)
        {
            print("moving horzontal");
            moveSpeed += 1;
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Vertical") > 1)
        {
            print("moving Vertical");
            moveSpeed += 1;

        }
        if(moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }
        if (Input.GetAxis("Vertical") <= 0 && Input.GetAxis("Horizontal") <= 0)
        {
            moveSpeed = 5;
        }
        
        Vector3 moveDis = transform.forward * v * moveSpeed;
        moveDis += transform.right * h * moveSpeed;
        body.SimpleMove(moveDis);
    }
}
    

