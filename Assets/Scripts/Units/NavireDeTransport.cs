using UnityEngine;

public class NavireDeTransport : Unit {
    public NavireDeTransport(int x,int y,Teams color)
    {
        unitName = "NavireDeTransport";
        unitDescription = "";
        hp = 10;
        movement = 6;
        ammo = 0;
        stamina = 99;
        staminaPerDay = 1;
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