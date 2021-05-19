using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManageScript : MonoBehaviour
{
    public float speed;
    public int stop = 1;
    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(
        //    transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed,
        //    0,
        //    transform.position.z + Input.GetAxis("Vertical") * Time.deltaTime * speed);

        //transform.LookAt(new Vector3(
        //    transform.position.x + Input.GetAxis("Horizontal"),
        //    0,
        //    transform.position.z + Input.GetAxis("Vertical")));
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x, 0, z) * speed * stop;
        transform.LookAt(new Vector3(transform.position.x + x * stop, 0,transform.position.z + z * stop ));

        anim.SetFloat("Speed", rb.velocity.magnitude);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

        
        
    }

    public void AttackCancel()
    {
        anim.ResetTrigger("Attack");
    }
}
