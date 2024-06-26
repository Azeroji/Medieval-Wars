using UnityEngine;
using System.Collections.Generic;

public class Charette : Unit {
    public Charette(int x,int y,Teams color)
    {
        unitType = UnitType.Charette;
        unitName = "Charette";
        unitDescription = "";
        hp = 10;
        movement = 6;
        ammo = 0;
        stamina = 60;
        staminaPerDay = 0;
        vision = 1;
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