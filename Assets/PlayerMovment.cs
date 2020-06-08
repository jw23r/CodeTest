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
    public float turnSpeed;
    public Transform projectileSpawn;
    public GameObject bullet;
    Rigidbody player;
    public ParticleSystem particles;
    public AudioSource rockets;
    public AudioSource shooting;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void Update()
    {
        Shooting();

        RotatePlayer();
     
        PlayerVelocity("Vertical", moveSpeedVertical, Vector3.forward);


    }

    private void RotatePlayer()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up * turnSpeed);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(-Vector3.up * turnSpeed);
        }
    }

    private void Shooting()
    {
        if (Input.GetKeyUp("space"))
        {
            print("space");
            Instantiate(bullet, projectileSpawn.position, projectileSpawn.rotation);
            if (!shooting.isPlaying) shooting.Play();

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
            // print(moveSpeedVertical);
            player.velocity = transform.forward * speed;
            if (!particles.isPlaying) particles.Play();
            if (!rockets.isPlaying) rockets.Play();


        }
        else
        {
            speed = 0;
            if (particles.isPlaying) particles.Stop();



        }

        if (speed > 10)
        {
            speed = maxFowardMoveSpeed;

        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "asteroid")
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if (other.transform.tag == "Enemy")
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if (other.transform.tag == "EnemyBullet")
        {
            HUDController.lives -= 1;
            transform.position = new Vector3(0, 0, 0);
        }
    }
}


