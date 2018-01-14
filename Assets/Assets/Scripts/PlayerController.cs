using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public Boundary boundary;
    public Transform shotSpawn;
    public GameObject projectile;

    private TankSoundController tankSoundController;
    private bool playerCanMove, playerCanShoot;

    void Start()
    {
        playerCanShoot = true;
        playerCanMove = true;
        tankSoundController = GameObject.FindWithTag("TankSoundController").GetComponent<TankSoundController>();
    }

    //Maybe can get power up and then be able to fire multiple shots? Boss fight with multiple shots?
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) && GameObject.FindGameObjectWithTag("TankBullet") == null && playerCanShoot)
        //if (Input.GetButton("Fire1")  && playerCanShoot)
        {
            tankSoundController.PlayTankShotSound();
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        GameObject tank = GameObject.FindWithTag("Tank");
        Rigidbody rb = tank.GetComponent<Rigidbody>();

        if (playerCanMove)
        {
            float leftRightMovement = Input.GetAxis("Horizontal");

            
            Vector3 movement = new Vector3(leftRightMovement, 0.0f, 0.0f);
            rb.velocity = movement * speed;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), rb.position.y, rb.position.z);
        }
        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }   

    public void StartPlayerMovement()
    {
        playerCanMove = true;
    }

    public void StopPlayerMovement()
    {
        playerCanMove = false;
    }

    public void BlockPlayerShooting()
    {
        playerCanShoot = false;
    }

    public void EnablePlayerShooting()
    {
        playerCanShoot = true;
    }
}
