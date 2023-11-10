using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    GameObject boom_obj;
    Animator a;
    bool booming = false;
    float speed = 0.1f;
    float angle = 100.0f;
    float timer;
    float last;
    float count;
    float count2;
    float times = 15f;
    // Start is called before the first frame update
    void Start()
    {
        boom_obj = gameObject;
        a = GetComponent<Animator>();
        Walk();
        last = 0f;
        timer = 5;
        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        count = count + Time.deltaTime;
        count2 = count2 + Time.deltaTime;
        if ( count2 > times )
        {
            booming = true;
        }

        bool isAttack = Attack();

        if ( !isAttack )
        {
            Turn();
            Walk();
        }

    }

    void Turn()
    {
        if ( count > timer )
        {
            boom_obj.transform.Rotate(angle, 0, 0, Space.Self);
            last = Time.time;
            count = 0;
            timer = Random.Range(0, 5);
            angle = Random.Range(90, 180);
        }
    }

    void Walk()
    {
        Vector3 v;
        v = Vector3.forward * speed;
        boom_obj.transform.Translate(v*Time.fixedDeltaTime, Space.Self);

    }

    bool Attack()
    {

        if ( booming )
        {
            a.SetBool( "attack", true );
            Destroy( gameObject, 5 );
            return true;
        }

        return false;
    }

    void OnTriggerEnter( Collider other )
    {
        if ( other.gameObject.name == "Player" )
        {
            booming = true;
        }
        
    }

}
