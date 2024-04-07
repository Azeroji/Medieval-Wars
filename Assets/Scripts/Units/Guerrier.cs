using UnityEngine;

public class Guerrier : Unit {
    public Guerrier( int x, int y, Teams color )
    {
        unitName = "Guerrier";
        unitDescription = "";
        hp = 10;
        baseDamage = 0.55f;
        movement = 3;
        ammo = 0;
        stamina = 99;
        staminaPerDay = 0;
        range = 1;
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