using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSettings : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("isStart", true);

    }
}
