using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour, IDestroyable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void damage(int a){
        print("cube destroy");
        Destroy(gameObject);
    }
}
