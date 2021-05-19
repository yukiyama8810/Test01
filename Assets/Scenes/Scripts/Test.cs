using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody rb;
    public Transform cam;
    public float spd = 3;
    public float qspd;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 relativePos = cam.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, qspd);
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * -spd, 0, Input.GetAxis("Vertical") * -spd));
    }


}
