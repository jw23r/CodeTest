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
   public Transform projectileSpawn;
   public GameObject bullet;
    Rigidbody player;
 
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();

       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp("space"))
        {
            print("space");
            Instantiate(bullet, projectileSpawn.position, projectileSpawn.rotation);

        }
        PlayerRotation();
        PlayerVelocity("Vertical", moveSpeedVertical, Vector3.forward);
        PlayerVelocity("Horizontal", moveSpeedHorizontal, Vector3.right);
    }

    private void PlayerRotation()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {


            transform.LookAt(new Vector3(hit.point.x, 0, hit.point.z));

        }
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
    

