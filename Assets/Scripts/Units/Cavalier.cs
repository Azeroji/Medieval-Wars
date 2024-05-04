using UnityEngine;
using System.Collections.Generic;

public class Cavalier : Unit {
    public Cavalier(int x,int y,Teams color)
    {
        unitType = UnitType.Cavalier;
        unitName = "Cavalier";
        unitDescription = "";
        hp = 10;
        baseDamage = new Dictionary<UnitType, float>() {{UnitType.Guerrier, 0.75f}, {UnitType.Lancier, 0.70f}, {UnitType.Eclaireur, 0.85f}, {UnitType.Cavalier, 0.55f}, {UnitType.CavalierRoyal, 0.15f}, {UnitType.Charette, 0.75f}, {UnitType.Archer, 0.70f}, {UnitType.Catapulte, 0.85f}, {UnitType.Belier, 0.75f}, {UnitType.Infirmier, 0.75f}, {UnitType.NavireDeTransport, 0.10f}, {UnitType.Radeau, 0.05f}, {UnitType.Galere, 0.01f}};
        movement = 5;
        ammo = 8;
        stamina = 50;
        staminaPerDay = 0;
        range = 1;
        vision = 1;
        cost = 50;
        isPower = false;
        canCapture = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "01":"09" )) ;
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/image_2024-03-11_234524013-removebg-preview.png":"Assets/UnitsPng/Blue/Cavalier.png")));
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}