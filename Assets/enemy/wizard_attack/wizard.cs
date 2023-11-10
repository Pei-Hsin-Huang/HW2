using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wizard : MonoBehaviour, IDestroyable
{
    public GameObject little_boom;
    public Slider blood;
    GameObject w;
    GameObject prefab;
    float timer = 7;
    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        w = gameObject;
        blood.value = 1;
        Vector3 v = new Vector3(w.transform.position.x, w.transform.position.y, w.transform.position.z-1 );
        prefab = Instantiate( little_boom, v, w.transform.rotation );
    }

    // Update is called once per frame
    void Update()
    {
        if ( blood.value > 0 )
        {
            Vector3 v = new Vector3(w.transform.position.x, w.transform.position.y, w.transform.position.z-1 );
            count = count + Time.deltaTime;
            if ( count > timer )
            {
                prefab = Instantiate( little_boom, v, w.transform.rotation );
                count = 0;
            }
        }
        
    }

    public void damage(int damage_value)
    {
        blood.value = blood.value - damage_value;
    }
}
