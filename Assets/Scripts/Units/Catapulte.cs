using UnityEngine;

public class Catapulte : Unit {
    public Catapulte(int x, int y,Teams color)
    {
        unitName = "Catapulte";
        unitDescription = "";
        hp = 10;
        baseDamage = 1.05f;
        movement = 5;
        ammo = 9;
        stamina = 50;
        staminaPerDay = 0;
        range = 5;
        vision = 1;
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