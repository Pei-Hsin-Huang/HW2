using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bomb : MonoBehaviour, IDestroyable
{
    private int max_hits = 25;
    private float explode_radius = 3f;
    private Collider[] hits_collider;
    private Coroutine explode_coroutine;
    private bool is_explode = false;
    public LayerMask block_layer;
    private Coroutine instantiate_coroutine;
    private bool is_instantiating = true;
    private Animator animator;

    private void Awake()
    {
        hits_collider = new Collider[max_hits];
    }
    private void Start()
    {
        instantiate_coroutine = StartCoroutine(instantiate());
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!is_instantiating)
        {
            explode_coroutine = StartCoroutine(explode());
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!is_instantiating)
        {
            explode_coroutine = StartCoroutine(explode());
        }
    }
    private void calculate_n_damage()
    {
        if (is_explode) return;
        is_explode = true;
        int hits_count = Physics.OverlapSphereNonAlloc(transform.position, explode_radius, hits_collider);  //can add hit_layer as last argument
        for (int i = 0; i < hits_count; i++)
        {
            // dont damage source bomb
            if (hits_collider[i].transform.root == transform) continue;
            // go find next if hits_collider[i] is not destroyable
            if(!hits_collider[i].TryGetComponent<IDestroyable>(out IDestroyable destroyable)) continue;
            Vector3 direction = hits_collider[i].transform.position - transform.position;
            float distance = direction.magnitude;
            // no need to damage if being blocked
            if (Physics.Raycast(transform.position, direction.normalized, distance, block_layer)) continue;
            destroyable.damage(50);  // can be made more flexible if needed
        }
        print("bomb explode");

    }
    
    IEnumerator explode()
    {
        animator.SetBool("explode", true);
        calculate_n_damage();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    IEnumerator instantiate()
    {
        yield return new WaitForSeconds(0.5f);
        is_instantiating = false;
    }

    public void setExplodeRadius(float radius)
    {
        explode_radius = radius;
    }

    public void damage(int damage_value)
    {
        if (is_explode) return;
        try
        {
            //StopCoroutine(explode_coroutine);
        }
        finally
        {
            explode_coroutine = StartCoroutine(explode());

            Destroy(gameObject);
        }
    }
}
