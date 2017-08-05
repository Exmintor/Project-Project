using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string ID;
    private float cooldown;
    private float tickTimer;
    public int NumTargets { get; private set; }
    public StatusEffect statusEffect { get; private set; }

    public Ability(string id, float cooldown, int numTargets, StatusEffect statusEffect)
    {
        this.ID = id;
        this.cooldown = cooldown;
        this.NumTargets = numTargets;
        this.statusEffect = statusEffect;
    }
}
