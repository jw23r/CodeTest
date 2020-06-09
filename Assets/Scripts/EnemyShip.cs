using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
  
    public Transform aim;  /// keeps track of what direction enemyship is facing used to instaceate bullets dir 

    GameObject playerShip;/// players gameobject used to keep track of where to amim at player
                         
    public GameObject bullet;  /// gameobject used to shoot bullet
                          
    public float coolDown;  /// keeps track of when to shoot
                          
    public float coolDownMin;/// the min time that the cool down can every be before shooting

    public float coolDownMax;  /// the longest cooldown can ever take

    float time; /// keeps track of time

    public AudioSource shoot; /// sound to play when shooting
    // Start is called before the first frame update
    /// <summary>
    /// finds the players gameobject
    /// </summary>
    void Start()
    {
        playerShip = GameObject.Find("Player");
    }

    // Update is called once per frame
    /// <summary>
    /// shoots bullets
    /// looks at player
    /// </summary>
    void Update()
    {
        Shoot();

        transform.LookAt(new Vector3(playerShip.transform.position.x, 0, playerShip.transform.position.z));


    }
    /// <summary>
    /// when time is greter than the cooldown time will shoot bullet at player
    /// </summary>
    private void Shoot()
    {
        time += Time.deltaTime;
        if (time >= coolDown)
        {
            if (!shoot.isPlaying) shoot.Play();
            Instantiate(bullet, aim.position, aim.rotation);
            time = 0;
            coolDown = Random.Range(coolDownMin, coolDownMax);
        }
    }
    /// <summary>
    /// if gets hit by bullet it gets destroyed and adds 35 points to score
    /// if runs in to player they lose 1 life
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Bullet")
        {
            HUDController.numberOfEnemys -= 1;
            HUDController.score += 35;
            Destroy(gameObject);
        }
        if(other.transform.tag == "Player")
        {
            HUDController.lives -= 1;
        }
    }
}
