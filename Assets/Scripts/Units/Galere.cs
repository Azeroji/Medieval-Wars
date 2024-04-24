using UnityEngine;

public class Galere : Unit {
    public Galere(int x,int y,Teams color)
    {
        unitName = "Galere";
        unitDescription = "";
        hp = 10;
        baseDamage = 1.15f;
        movement = 5;
        ammo = 9;
        stamina = 99;
        staminaPerDay = 1;
        range = 5;
        vision = 2;
        cost = 50;
        isPower = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "02":"07" )) ;
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}