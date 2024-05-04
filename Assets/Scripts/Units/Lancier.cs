using UnityEngine;
using System.Collections.Generic;

public class Lancier : Unit {
    public Lancier( int x, int y, Teams color )
    {
        unitType = UnitType.Lancier;
        unitName = "Lancier";
        unitDescription = "";
        hp = 10;
        baseDamage = new Dictionary<UnitType, float>() {{UnitType.Guerrier, 0.65f}, {UnitType.Lancier, 0.55f}, {UnitType.Eclaireur, 0.85f}, {UnitType.Cavalier, 0.55f}, {UnitType.CavalierRoyal, 0.15f}, {UnitType.Charette, 0.75f}, {UnitType.Archer, 0.70f}, {UnitType.Catapulte, 0.85f}, {UnitType.Belier, 0.75f}, {UnitType.Infirmier, 0.75f}};
        movement = 2;
        ammo = 3;
        stamina = 70;
        staminaPerDay = 0;
        range = 1;
        vision = 2;
        cost = 50;
        isPower = false;
        canCapture = true;

        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "15":"14" )) ;
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/Lancier.png":"Assets/UnitsPng/Blue/Lancier.png")));        
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}