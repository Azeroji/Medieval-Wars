using UnityEngine;
using System.Collections.Generic;

public class Radeau : Unit {
    public Radeau(int x,int y,Teams color)
    {
        unitType = UnitType.Radeau;
        unitName = "Radeau";
        unitDescription = "";
        hp = 10;
        movement = 9;
        ammo = 0;
        stamina = 99;
        staminaPerDay = 0;
        range = 1;
        vision = 4;
        cost = 50;
        isPower = false;
        canCapture = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "02":"07" )) ;
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}