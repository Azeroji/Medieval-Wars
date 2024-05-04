using UnityEngine;
using System.Collections.Generic;

public class Galere : Unit {
    public Galere(int x,int y,Teams color)
    {
        unitType = UnitType.Galere;
        unitName = "Galere";
        unitDescription = "";
        hp = 10;
        baseDamage = new Dictionary<UnitType, float>() {{UnitType.Cavalier, 0.01f}, {UnitType.Archer, 0.10f}, {UnitType.Catapulte, 0.40f}, {UnitType.Galere, 0.55f}};
        movement = 5;
        ammo = 9;
        stamina = 99;
        staminaPerDay = 1;
        range = 5;
        vision = 2;
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