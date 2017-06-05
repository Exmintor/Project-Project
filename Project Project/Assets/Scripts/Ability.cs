using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string ID;
    public int Damage { get; private set; }
    private int cooldown;

    public Ability(string id, int damage, int cooldown)
    {
        this.ID = id;
        this.Damage = damage;
        this.cooldown = cooldown;
    }
}
