using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood_control : MonoBehaviour
{
    public GameObject my_camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(my_camera.transform.position);
        
    }
}
