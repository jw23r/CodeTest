using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update

     float moveSpeedVertical = 0;
    float moveSpeedHorizontal = 0;

    public float maxFowardMoveSpeed = 50;
    public float maxBackWardMoveSpeed = 50;
    public float velocity;

    Rigidbody player;
   // CharacterController body;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();

       // body = GetComponent<CharacterController>();
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

        /*   if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") > 1)
            {
                print("moving horzontal");
                moveSpeed += 1;
            }*/
        PlayerVelocity("Vertical", moveSpeedVertical,Vector3.forward);
        PlayerVelocity("Horizontal", moveSpeedHorizontal, Vector3.right);



        /*
        Vector3 moveDis = transform.forward * v * moveSpeed;
        moveDis += transform.right * h * moveSpeed;
        body.SimpleMove(moveDis);
    */
    }

    private void PlayerVelocity(string dir, float speed, Vector3 forceDir)
    {
        if (Input.GetAxis(dir) > 0)
        {
            if (speed < 0)
            {
                speed = 0;
            }

            speed += velocity;
            print(moveSpeedVertical);

        }
        if (Input.GetAxis(dir) < 0)
        {
            if (speed > 0)
            {
                speed = 0;
            }

            speed -= velocity;
            //print(moveSpeed);

        }
        if (speed > 10)
        {
            speed = maxFowardMoveSpeed;

        }
        if (speed < -10)
        {
            speed = maxBackWardMoveSpeed;
        }
        if (Input.GetAxis(dir) == 0)
        {
            speed = 0;
        }

        player.AddForce(forceDir * speed * Time.deltaTime, ForceMode.VelocityChange);
        
    }
}
    

