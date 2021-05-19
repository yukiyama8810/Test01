using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManageScript : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator anim;
    float checkangle;
    Vector3 targetpos;
    Quaternion targetangle;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("Distance", agent.remainingDistance);

        //Playerが視界内(約±60度)に居るかの判定
        targetpos = target.position - transform.position;
        targetangle = Quaternion.LookRotation(targetpos);
        checkangle = Quaternion.Angle(transform.rotation, targetangle);
        if(checkangle < 60f)
        {
            anim.SetBool("FrontPlayer", true);
        }
        else
        {
            anim.SetBool("FrontPlayer", false);
        }


        LookPlayer();

        //var checkrotation = transform.position - target.position;
        //Debug.Log("checkrot : d" + checkrotation);
        //Debug.Log("Vec.Angle : " + Vector3.Angle(transform.position + transform.forward, target.position));

        //var targetrot = target.position - transform.position;
        //var testrot = Quaternion.LookRotation(targetrot);
        //Debug.Log("transform.rotation : " + transform.rotation);
        //Debug.Log("Q.Angle me,Q.LR : " + Quaternion.Angle(transform.rotation, testrot));
    }

    public void LookPlayer()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetangle, 0.75f * Time.deltaTime);
        
        Debug.Log("LookTest");
    }


}
