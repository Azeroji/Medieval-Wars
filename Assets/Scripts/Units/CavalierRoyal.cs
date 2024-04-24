using UnityEngine;

public class CavalierRoyal : Unit {
    public CavalierRoyal(int x,int y,Teams color)
    {
        unitName = "CavalierRoyal";
        unitDescription = "";
        hp = 10;
        baseDamage = 1.05f;
        movement = 6;
        ammo = 9;
        stamina = 70;
        staminaPerDay = 0;
        range = 1;
        vision = 3;
        cost = 50;
        isPower = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "08":"04" )) ;
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}