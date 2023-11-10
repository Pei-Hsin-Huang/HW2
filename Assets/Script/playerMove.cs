// 小地圖作法：創Render texture丟給camera接output，在Canvas創RawImage接Render texture
// 從2D調整Canvas中的RawImage

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody rigid;
    float jump_height = 4.0f;
    public float inout_speed = 10.0f;
    // float hor_speed = 2.0f;
    float turn_speed = 100.0f;
    bool onGround = false;
    public GameObject direction;

    
    // Start is called before the first frame update
    void Start()
    {   
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        float inoutMove=0; //= Input.GetAxis("Vertical") * speed * Time.deltaTime;
        // float horMove=0;
        float turnMove=0; //= Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(Input.GetKey("w")){
            inoutMove=1;
        }  

        if(Input.GetKey("s")){
            inoutMove=-1;
        }  

        if(Input.GetKey("a")){
            // horMove=-1;
            turnMove=-1;
        } 

        if(Input.GetKey("d")){
            // horMove=1;
            turnMove=1;
        } 

        if(Input.GetKey("space") && onGround){
            // Debug.Log(jump);
            onGround = false;
            rigid.velocity = new Vector3(0, jump_height,0);
        }
        
        // Move player
        Transform direction_position = direction.GetComponent<Transform>();
        Vector3 dir = direction_position.position - transform.position;
        transform.position += inoutMove*dir*inout_speed*Time.deltaTime;
        //Rotate
        transform.Rotate(new Vector3(0,1*turnMove*turn_speed*Time.deltaTime,0));
        
        // transform.rotation.x=0;
        // transform.rotation.z=0;
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "ground"){
            onGround = true;
        }
    }
}
