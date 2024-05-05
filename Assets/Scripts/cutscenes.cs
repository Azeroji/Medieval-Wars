using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class cutscenes : MonoBehaviour
{
    // Start is called before the first frame update
    Unit[] tabBleu;
    Unit[] tabRed;
    Teams teamAtackant;
    public int nbBleu = 8;
    public int nbRed = 8;
    public int nbBleuFin = 5;
    public int nbRedFin = 3;
    public string unitNameBleu;
    public string unitNameRed;

    Guerrier g1;
    Cavalier g2;
    Cavalier g3;


    public RuntimeAnimatorController animatorController;
    void Start()
    {


        tabBleu = new Cavalier[nbBleu];
        tabRed = new Cavalier[nbRed];
        string parameterValue = ParamsSceneAnimation.name;
        for (int i = 0; i < nbBleu; i++)
        {
            tabBleu[i] = new Cavalier(7, i - 3, Teams.Blue);
            tabRed[i] = new Cavalier(-8, i - 3, Teams.Red);
            if (i < nbBleuFin)
            {
                tabBleu[i].animate(true);
            }
            else
            {
                tabBleu[i].animate(false);

            }
            if (i < nbRedFin)
            {
                tabRed[i].animate(true);

            }
            else
            {
                tabRed[i].animate(false);
            }




        }


    }

    void Update()
    {


    }

    // Update is called once per frame

}
