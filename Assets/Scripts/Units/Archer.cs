using UnityEngine;
using System.Collections.Generic;

public class Archer : Unit {
    public Archer(int x,int y,Teams color)
    {
        unitType = UnitType.Archer;
        unitName = "Archer";
        unitDescription = "";
        hp = 10;

        baseDamage = new Dictionary<UnitType, float>() {{UnitType.Guerrier, 0.15f}, {UnitType.Lancier, 0.70f}, {UnitType.Eclaireur, 0.45f}, {UnitType.Cavalier, 0.70f}, {UnitType.CavalierRoyal, 1.05f}, {UnitType.Charette, 0.70f}, {UnitType.Archer, 0.75f}, {UnitType.Catapulte, 0.80f}, {UnitType.Belier, 0.70f}, {UnitType.Infirmier, 0.70f}, {UnitType.NavireDeTransport, 0.55f}, {UnitType.Radeau, 0.65f}, {UnitType.Galere, 0.40f}};

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


        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "03":"10" )) ;
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/image_2024-03-11_234556703-removebg-preview.png":"Assets/UnitsPng/Blue/Archer.png")));

        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}