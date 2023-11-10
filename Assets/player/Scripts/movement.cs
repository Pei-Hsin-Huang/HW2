using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 3;
    public float jumpSpeed = 1f;
    [HideInInspector] public Vector3 dir;
    float hInput, vInput;
    CharacterController controller;
    Animator a;
    bool hitted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        a = GameObject.Find("MaleCharacterPolyart").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

        if(controller.isGrounded){
            hInput = Input.GetAxis("Horizontal");
            vInput = Input.GetAxis("Vertical");
            dir = transform.forward * vInput * moveSpeed + transform.right * hInput * moveSpeed;
            
            if(Input.GetKey(KeyCode.Space)){
                dir.y += jumpSpeed;
                a.SetBool( "jump", true );
            }

            else{
                a.SetBool( "jump", false );
                if ( (hInput != 0) || (vInput != 0) ){
                    a.SetBool( "run", true );
                }
                else{
                    a.SetBool( "run", false );
                }
            }
            
        }

        else{
            a.SetBool( "jump", false );
        }


        if ( hitted )
        {
            a.SetBool( "hit", true );
        }
        
        else
        {
            a.SetBool( "hit", false );
        }
        


        dir += Physics.gravity * Time.deltaTime;
        controller.Move(dir * Time.deltaTime);
    }

    void OnTriggerEnter( Collider other )
    {
        if ( other.gameObject.name == "little_boom(Clone)" )
        {
            print("hit");
            //a.SetBool( "hit", true );
            hitted = true;
        }
        
    }

    
}
