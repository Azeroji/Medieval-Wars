using UnityEngine;
using System.Collections.Generic;

public class CavalierRoyal : Unit {
    public CavalierRoyal(int x,int y,Teams color)
    {
        unitType = UnitType.CavalierRoyal;
        unitName = "CavalierRoyal";
        unitDescription = "";
        hp = 10;
        baseDamage = new Dictionary<UnitType, float>() {{UnitType.Guerrier, 1.05f}, {UnitType.Lancier, 0.95f}, {UnitType.Eclaireur, 1.05f}, {UnitType.Cavalier, 0.85f}, {UnitType.CavalierRoyal, 0.55f}, {UnitType.Charette, 1.05f}, {UnitType.Archer, 1.05f}, {UnitType.Catapulte, 1.05f}, {UnitType.Belier, 1.05f}, {UnitType.Infirmier, 1.05f}, {UnitType.NavireDeTransport, 0.35f}, {UnitType.Radeau, 0.55f}, {UnitType.Galere, 0.10f}};
        movement = 6;
        ammo = 9;
        stamina = 70;
        staminaPerDay = 0;
        range = 1;
        vision = 3;
        cost = 50;
        isPower = false;
        canCapture = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "08":"04" )) ;
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/image_2024-03-11_234426120-removebg-preview.png":"Assets/UnitsPng/Blue/image_2024-03-11_235444598-removebg-preview.png")));
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}