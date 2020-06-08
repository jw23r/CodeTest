using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform aim;
    GameObject enemyShip;
    public GameObject bullet; 
    public float coolDown;
    public float coolDownMin;
    public float coolDownMax;
    float time;
    public AudioSource shoot;
    // Start is called before the first frame update
    void Start()
    {
        enemyShip = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= coolDown)
        {
            if (!shoot.isPlaying) shoot.Play();
            Instantiate(bullet, aim.position, aim.rotation);
            time = 0;
            coolDown = Random.Range(coolDownMin, coolDownMax);
        }
        transform.LookAt(new Vector3(enemyShip.transform.position.x, 0, enemyShip.transform.position.z));


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Bullet")
        {
            HUDController.score += 35;
            Destroy(gameObject);
        }
    }
}
