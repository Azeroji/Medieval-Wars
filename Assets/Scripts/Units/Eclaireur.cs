using UnityEngine;

public class Eclaireur : Unit {
    public Eclaireur(int x,int y,Teams color)
    {
        unitName = "Eclaireur";
        unitDescription = "";
        hp = 10;
        movement = 8;
        ammo = 0;
        stamina = 80;
        staminaPerDay = 0;
        range = 1;
        vision = 5;
        cost = 50;
        isPower = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "11":"05" )) ;
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}