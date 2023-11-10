using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCube_Creator : MonoBehaviour
{   
    private float column = 40;
    private float row = 80;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Create 3200 (1, 1, 1) cubes to fill the plane
        for(int i=1; i<=column; i++){
            for(int j=1; j<=row; j++){
                yield return new WaitForSeconds(0.001f);
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(i-1, -1, j-1);
                cube.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
