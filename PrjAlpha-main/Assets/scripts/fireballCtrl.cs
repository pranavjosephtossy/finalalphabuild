using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballCtrl : MonoBehaviour
{
    private Rigidbody rb;
    
    
    public float shootForce;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);  
    }

    //detroy ghost on collision
     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

}




