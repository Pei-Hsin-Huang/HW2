using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wizar2_control : MonoBehaviour
{
    GameObject wizar2;
    public Slider blood;
    float speed = 0.1f;
    float angle = 100.0f;
    float timer = 5;
    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        wizar2 = gameObject;
        Walk();
        blood.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        count = count + Time.deltaTime;
        if ( blood.value > 0 )
        {
            Turn();
            Walk();
        }
        
    }

    void Turn()
    {
        if ( count > timer )
        {
            wizar2.transform.Rotate(0, angle, 0, Space.Self);
            count = 0;
            timer = Random.Range(0, 5);
            angle = Random.Range(90, 180);
        }
    }

    void Walk()
    {
        Vector3 v;
        v = Vector3.forward * speed;
        wizar2.transform.Translate(v*Time.fixedDeltaTime, Space.Self);

    }
}
