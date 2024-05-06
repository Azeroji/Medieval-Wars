using System;
using System.Collections.Generic;

public class Batiment : Terrain
{
    public bool can_produce = true;
    public UnitType[] units_produced;

    // produce unit
    public void produce_unit(Player player, UnitType unit)
    {
        // new position of unit produite
        posx_unit = posx;
        posy_unit = posy;
        
        // produce unit
        // Archer
        if (unit == UnitType.Archer)
        {  
            // check if can produce
            int cost = Archer.cost;     
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Archer(posx_unit, posy_unit, player.team));
        }

        // Belier
        else if (unit == UnitType.Belier)
        {
            // check if can produce
            int cost = Belier.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Belier(posx_unit, posy_unit, player.team));
        }

        // Catapulte
        else if (unit == UnitType.Catapulte)
        {
            // check if can produce
            int cost = Catapulte.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Catapulte(posx_unit, posy_unit, player.team));
        }

        // Cavalier
        else if (unit == UnitType.Cavalier)
        {
            // check if can produce
            int cost = Cavalier.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Cavalier(posx_unit, posy_unit, player.team));
        }

        // CavalierRoyal
        else if (unit == UnitType.CavalierRoyal)
        {
            // check if can produce
            int cost = CavalierRoyal.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new CavalierRoyal(posx_unit, posy_unit, player.team));
        }

        // Charette
        else if (unit == UnitType.Charette)
        {
            // check if can produce
            int cost = Charette.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Charette(posx_unit, posy_unit, player.team));
        }

        // Eclaireur
        else if (unit == UnitType.Eclaireur)
        {
            // check if can produce
            int cost = Eclaireur.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Eclaireur(posx_unit, posy_unit, player.team));
        }

        // Galere
        else if (unit == UnitType.Galere)
        {
            // check if can produce
            int cost = Galere.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Galere(posx_unit, posy_unit, player.team));
        }

        // Guerrier
        else if (unit == UnitType.Guerrier)
        {
            // check if can produce
            int cost = Guerrier.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Guerrier(posx_unit, posy_unit, player.team));
        }

        // Infirmier
        else if (unit == UnitType.Infirmier)
        {
            // check if can produce
            int cost = Infirmier.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Infirmier(posx_unit, posy_unit, player.team));
        }

        // Lancier
        else if (unit == UnitType.Lancier)
        {
            // check if can produce
            int cost = Lancier.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Lancier(posx_unit, posy_unit, player.team));
        }

        // NavireDeTransport
        else if (unit == UnitType.NavireDeTransport)
        {
            // check if can produce
            int cost = NavireDeTransport.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new NavireDeTransport(posx_unit, posy_unit, player.team));
        }

        // Radeau
        else if (unit == UnitType.Radeau)
        {
            // check if can produce
            int cost = Radeau.cost;
            if (player.funds < cost) {
                return false;
            }
            // produce unit
            player.AddUnit(new Radeau(posx_unit, posy_unit, player.team));
        }

        // ne peut plus produire dans le meme tour
        can_produce = false;
        return true;
    }

}