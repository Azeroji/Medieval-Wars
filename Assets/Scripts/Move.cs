using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_test : MonoBehaviour
{
    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("Attack");
    }
}