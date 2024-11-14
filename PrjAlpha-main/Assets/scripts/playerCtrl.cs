using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float verticalSpeed;
    public float turnSpeed;
    public float jumpForce;
    private float groundlimit = -5;

    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;


    private Rigidbody playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //vertical and horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * verticalSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * turnSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        //summon fireball
        if (Input.GetKeyDown(KeyCode.P))
        {
            SummonFireball();
        }
        //if player falls of edge(doesnt work in alpha)
        if(transform.position.y> groundlimit)
        {
            Debug.Log("Game Over");
        }
        //summon powerup
        /*
         if (Input.GetKeyDown(KeyCode.Q))
        {
            //call powerup method
        }
         */

    }

    //detroy ghost on collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //destroys ghost
            Destroy(collision.gameObject);
            Debug.Log("collision");
            //suposed to destroy fireball
            //Destroy();
        }
    }

    void SummonFireball()
    {
        if (fireballPrefab != null && fireballSpawnPoint != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            Rigidbody fireballRB = fireball.GetComponent<Rigidbody>();

            if (fireballRB != null)
            { 
                fireballRB.useGravity = false;
                Debug.DrawRay(fireballSpawnPoint.position, fireballSpawnPoint.forward * 10f, Color.red, 1f);
                fireballRB.AddForce(fireballSpawnPoint.forward * 70f, ForceMode.Impulse);
          
            }
        }
    }


}


