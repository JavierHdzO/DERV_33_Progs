using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFisicas : MonoBehaviour
{
    public static int X=0;
    public static int Y=0;
    public float desplazamiento = 10;
    

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Y == 1) 
        {
            rb.MovePosition(rb.position + transform.forward * desplazamiento 
            * Time.deltaTime);
        }
        if (X == -1)
        {
            rb.MovePosition(rb.position + transform.right * -1f * desplazamiento 
            * Time.deltaTime);
        }
        if ( Y == -1)
        {
            rb.MovePosition(rb.position + transform.forward * -1f * desplazamiento 
            * Time.deltaTime);
        }
        if ( X == 1)
        {
            rb.MovePosition(rb.position + transform.right * desplazamiento 
            * Time.deltaTime);
        }

    }

}
