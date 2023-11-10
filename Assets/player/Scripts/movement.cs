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
    public bool hitted_by_toony = false;
    private int hittedState;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        a = GameObject.Find("MaleCharacterPolyart").GetComponent<Animator>();
        hittedState = Animator.StringToHash("Base Layer.GetHit01_SwordAndShield");
    }

    // Update is called once per frame
    void Update()
    {
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


        /*if ( !(currentState.fullPathHash == Animator.StringToHash("GetHit01_SwordAndShield")) )
        {
            if ( hitted )
            {
                a.SetBool( "hit", true );
            }
            else
            {
                a.SetBool( "hit", false );
                print( "leave" );
                hitted = false;
            }
        }
        
        else
        {
            a.SetBool( "hit", false );
            print( "leave" );
            hitted = false;
        }*/
        AnimatorStateInfo currentState = a.GetCurrentAnimatorStateInfo(0);

        if (currentState.fullPathHash == hittedState){
            //print("test");
            a.SetBool( "hit", false );
        }

        if ( hitted_by_toony )
            a.SetBool( "hit", true );



        dir += Physics.gravity * Time.deltaTime;
        controller.Move(dir * Time.deltaTime);
    }

    void OnTriggerEnter( Collider other )
    {
        if ( other.gameObject.name == "little_boom(Clone)" )
        {
            //print("hit");
            a.SetBool( "hit", true );
            //hitted = true;
        }

        else if ( other.gameObject.name == "TT_RTS_Demo_Character Variant" )
        {
            //print("hit");
            a.SetBool( "hit", true );
            //hitted = true;
        }

        else if ( other.gameObject.name == "PolyArtWizardMaskTintMat Variant" )
        {
            //print("hit");
            a.SetBool( "hit", true );
            //hitted = true;
        }

        else if ( other.gameObject.name == "PolyArtWizardStandardMat Variant" )
        {
            //print("hit");
            a.SetBool( "hit", true );
            //hitted = true;
        }
        
    }

    void OnParticleCollision(GameObject other)
    {
        print( "pc2" );
        if ( other.gameObject.name == "blue_att" )
        {
            //print("hit");
            a.SetBool( "hit", true );
            //hitted = true;
        }
    }

    
}
