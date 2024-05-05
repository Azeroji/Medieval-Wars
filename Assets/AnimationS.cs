using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationS : MonoBehaviour
{

    private Animator mAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void animateHorse(bool isDeath)
    {
        mAnimator.SetTrigger("TrOpen");
        mAnimator.SetBool("isDeath", isDeath);
        
    }

}
