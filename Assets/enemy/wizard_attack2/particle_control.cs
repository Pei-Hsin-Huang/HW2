using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_control : MonoBehaviour
{
    ParticleSystem part;
    
    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        print( "pc" );
    }
}
