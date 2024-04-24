using UnityEngine;

public class Archer : Unit {
    public Archer(int x,int y,Teams color)
    {
        unitName = "Archer";
        unitDescription = "";
        hp = 10;
        baseDamage = 0.55f;
        movement = 5;
        ammo = 9;
        stamina = 50;
        staminaPerDay = 0;
        range = 3;
        vision = 1;
        cost = 50;
        isPower = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "03":"10" )) ;
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}