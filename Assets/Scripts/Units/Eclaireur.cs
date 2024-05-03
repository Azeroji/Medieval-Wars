using UnityEngine;
using System.Collections.Generic;

public class Eclaireur : Unit {
    public Eclaireur(int x,int y,Teams color)
    {
        unitType = UnitType.Eclaireur;
        unitName = "Eclaireur";
        unitDescription = "";
        hp = 10;
        baseDamage = new Dictionary<UnitType, float>() {{UnitType.Guerrier, 0.70f}, {UnitType.Lancier, 0.65f}, {UnitType.Eclaireur, 0.35f}, {UnitType.Cavalier, 0.06f}, {UnitType.CavalierRoyal, 0.01f}, {UnitType.Charette, 0.45f}, {UnitType.Archer, 0.45f}, {UnitType.Catapulte, 0.55f}, {UnitType.Belier, 0.45f}, {UnitType.Infirmier, 0.45f}};
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
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/image_2024-03-11_234539751-removebg-preview.png":"Assets/UnitsPng/Blue/Eclaireur.png")));
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}