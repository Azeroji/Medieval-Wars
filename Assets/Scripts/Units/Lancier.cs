using UnityEngine;

public class Lancier : Unit {
    public Lancier( int x, int y, Teams color )
    {
        unitName = "Lancier";
        unitDescription = "";
        hp = 10;
        baseDamage = 0.95f;
        movement = 2;
        ammo = 3;
        stamina = 70;
        staminaPerDay = 0;
        range = 1;
        vision = 2;
        cost = 50;
        isPower = false;

        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "15":"14" )) ;
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}