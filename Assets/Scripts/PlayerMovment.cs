using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update

    float moveSpeedVertical = 0;// how fast object moves vertical
 
    public float maxFowardMoveSpeed = 50;// how fast the speed can get to
    
    public float velocity;//keeps track of velicty
    public float turnSpeed;// how fast player can turn left and right
    public Transform projectileSpawn;// dir used to spawn bullet
    public GameObject bullet;// the object that gets spawned when player shoots
    Rigidbody player;//the ridge body of the player used for adding force
    public ParticleSystem particles;// the players particels
    public AudioSource rockets;//sound when moving foward
    public AudioSource shooting;//sound when shooting



    // Start is called before the first frame update
    /// <summary>
    /// gets the players ridgebody on the game object
    /// </summary>
    void Start()
    {
        player = GetComponent<Rigidbody>();



    }
    /// <summary>
    /// updates if the player is shooting 
    /// rootates the player
    /// moves the player
    /// </summary>
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
    /// <summary>
    /// creates a bullet when the player lets go of  space
    /// when the player lets go of  space turns on audio source
    /// </summary>
    private void Shooting()
    {
        if (Input.GetKeyUp("space"))
        {
            //print("space");
            Instantiate(bullet, projectileSpawn.position, projectileSpawn.rotation);
            if (!shooting.isPlaying) shooting.Play();

        }
    }


    /// <summary>
    /// moves the player in the entered direction and uses the given axis to check whtehr to move or not
    /// playes rocket sound when adding velocity
    /// </summary>
    /// <param name="dir"></param> what axis we are looking for to move the object
    /// <param name="speed"></param> how fast the player will move
    /// <param name="forceDir"></param> what direction we want the player to movein
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

        if (speed > maxFowardMoveSpeed)
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


