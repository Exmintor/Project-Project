using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string ID;
    private float cooldown;
    private float channelTime;
    public StatusEffect statusEffect { get; private set; }

    public Ability(string id, float cooldown, float channelTime, StatusEffect statusEffect)
    {
        this.ID = id;
        this.cooldown = cooldown;
        this.channelTime = channelTime;
        this.statusEffect = statusEffect;
    }
}
