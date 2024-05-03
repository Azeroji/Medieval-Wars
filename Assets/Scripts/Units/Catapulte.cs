using UnityEngine;
using System.Collections.Generic;

public class Catapulte : Unit {
    public Catapulte(int x, int y,Teams color)
    {
        unitType = UnitType.Catapulte;
        unitName = "Catapulte";
        unitDescription = "";
        hp = 10;
        baseDamage = new Dictionary<UnitType, float>() {{UnitType.Guerrier, 0.25f}, {UnitType.Lancier, 0.85f}, {UnitType.Eclaireur, 0.55f}, {UnitType.Cavalier, 0.85f}, {UnitType.CavalierRoyal, 1.05f}, {UnitType.Charette, 0.80f}, {UnitType.Archer, 0.85f}, {UnitType.Catapulte, 0.85f}, {UnitType.Belier, 0.80f}, {UnitType.Infirmier, 0.80f}, {UnitType.NavireDeTransport, 0.60f}, {UnitType.Radeau, 0.85f}, {UnitType.Galere, 0.55f}};
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