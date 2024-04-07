using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Guerrier g1 = new Guerrier(3,4,Teams.Red);

        Lancier g2 = new Lancier(4,5,Teams.Blue);

        Infirmier g3 = new Infirmier(3,8,Teams.Red);

    }

}
