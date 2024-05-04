using UnityEngine;
using System.Collections.Generic;

public class Guerrier : Unit {
    public Guerrier( int x, int y, Teams color )
    {
        unitType = UnitType.Guerrier;
        unitName = "Guerrier";
        unitDescription = "";
        hp = 10;
        baseDamage = new Dictionary<UnitType, float>() {{UnitType.Guerrier, 0.55f}, {UnitType.Lancier, 0.45f}, {UnitType.Eclaireur, 0.12f}, {UnitType.Cavalier, 0.05f}, {UnitType.CavalierRoyal, 0.01f}, {UnitType.Charette, 0.14f}, {UnitType.Archer, 0.15f}, {UnitType.Catapulte, 0.25f}, {UnitType.Belier, 0.14f}, {UnitType.Infirmier, 0.14f}};
        movement = 3;
        ammo = 0;
        stamina = 99;
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
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "02":"07" )) ;
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/image_2024-03-11_234844800-removebg-preview.png":"Assets/UnitsPng/Blue/Guerrier.png")));
        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }

}