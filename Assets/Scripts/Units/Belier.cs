using UnityEngine;
using System.Collections.Generic;

public class Belier : Unit {
    public Belier(int x,int y,Teams color)
    {
        unitType = UnitType.Belier;
        unitName = "Belier";
        unitDescription = "";
        hp = 10;
        movement = 8;
        ammo = 0;
        stamina = 90;
        staminaPerDay = 0;
        range = 1;
        vision = 1;
        cost = 50;
        isPower = false;
        
        team = color;
        posx = x;
        posy = y;
        //Visually displaying the unit
        unitGameObject = Resources.Load<GameObject>("SPUM/SPUM_Units/Unit0"+((color==Teams.Red)? "06":"13" )) ;
        sprite = SpriteFromTexture(LoadTextureFromFile(((color==Teams.Red)? "Assets/UnitsPng/Red/image_2024-03-11_234903992-removebg-preview.png":"Assets/UnitsPng/Blue/image_2024-03-11_235809432-removebg-preview.png")));

        Vector2 vector1 = new Vector2(x-9.5f, y-4.75f);
        SpawnUnit(vector1);
    }
}