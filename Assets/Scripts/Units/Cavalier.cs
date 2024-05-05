using UnityEngine;

public class Cavalier : Unit
{
    public Cavalier(int x, int y, Teams color)
    {
        unitName = "Cavalier";
        unitDescription = "";
        hp = 10;
        baseDamage = 0.75f;
        movement = 5;
        ammo = 8;
        stamina = 50;
        staminaPerDay = 0;
        range = 1;
        vision = 1;
        cost = 50;
        isPower = false;

        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0" + ((color == Teams.Red) ? "01" : "09"));
        Vector2 vector1 = new Vector2(x, y);
        SpawnUnit(vector1);
    }
}