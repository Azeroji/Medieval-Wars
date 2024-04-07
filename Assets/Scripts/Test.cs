using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    Guerrier g1;
    Lancier g2;
    Infirmier g3;
    // Start is called before the first frame update
    void Start()
    {
        g1 = new Guerrier(3,4,Teams.Red);

        g2 = new Lancier(4,5,Teams.Blue);

        g3 = new Infirmier(3,8,Teams.Red);

    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            g1.Attack(g2);
        }

    }

}
