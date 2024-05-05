using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AttackAnimation: MonoBehaviour {

    public GameObject unit;
    private List<GameObject> list = new List<GameObject>();

    void Start () {

        for ( int i = 0; i < 5; i++ ) {
            if ( i < 3 ) {
                list.Add(GameObject.Instantiate(unit, new Vector3(0,i,0), Quaternion.identity));
            } else {
                list.Add(GameObject.Instantiate(unit, new Vector3(-3,i-3,0), Quaternion.identity));
            }
        }

    }

    void Update () {


        foreach ( GameObject item in list ) {

            item.transform.position = Vector2.MoveTowards( item.transform.position , new Vector2( -5, item.transform.position.y ), 0.025f);

            Transform unitRoot = item.transform.Find("UnitRoot");

            if ( unitRoot == null ) {
            unitRoot = item.transform.Find("HorseRoot");
            }

            if (unitRoot != null) {
            Animator animator = unitRoot.gameObject.GetComponent<Animator>();
            animator.SetFloat("RunState", 0.5f );
            }

        }
        
    }

}