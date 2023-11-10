using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toony_control : MonoBehaviour
{
    Animator a;
    GameObject toony;
    public GameObject player;
    public Slider blood;
    float speed = 0.1f;
    float angle = 100.0f;
    float timer = 5;
    float count = 0;
    float attackRange = 2f;
    // Start is called before the first frame update
    void Start()
    {
        toony = gameObject;
        a = GetComponent<Animator>();
        Walk();
        blood.value = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        count = count + Time.deltaTime;
        if ( blood.value > 0 )
        {
            bool isAttack = Attack();

            if ( !isAttack )
            {
                Turn();
                Walk();
            }
        }
    }

    void Turn()
    {
        if ( count > timer )
        {
            toony.transform.Rotate(0, angle, 0, Space.Self);
            count = 0;
            timer = Random.Range(0, 5);
            angle = Random.Range(90, 180);
        }
    }

    void Walk()
    {
        Vector3 v;
        v = Vector3.forward * speed;
        toony.transform.Translate(v*Time.fixedDeltaTime, Space.Self);

    }

    bool Attack()
    {
        float distance = Vector3.Distance(player.transform.position, toony.transform.position);
        if (distance <= attackRange)
        {
            Vector3 dir = player.transform.position - toony.transform.position;
            dir.y = 0;
            toony.transform.rotation = Quaternion.Slerp(toony.transform.rotation,Quaternion.LookRotation(dir),0.3f);
            a.SetBool( "attack", true );
            player.GetComponent<movement>().hitted_by_toony = true;
            return true;
        }

        else
        {
            a.SetBool( "attack", false );
            player.GetComponent<movement>().hitted_by_toony = false;
            return false;
        }
    }
}
