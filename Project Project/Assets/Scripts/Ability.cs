using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string ID;
    private float cooldown;
    private float channelTime;
    private float tickTimer;
    private int numTargets;
    public StatusEffect statusEffect { get; private set; }

    public Ability(string id, float cooldown, float channelTime, float tickTimer, int numTargets, StatusEffect statusEffect)
    {
        this.ID = id;
        this.cooldown = cooldown;
        this.channelTime = channelTime;
        this.tickTimer = tickTimer;
        this.numTargets = numTargets;
        this.statusEffect = statusEffect;
    }
}
