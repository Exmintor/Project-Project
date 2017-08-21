using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusInfo
{
    public Player User { get; private set; }
    public Player Target { get; private set; }
    public StatusEffect StatusEffect { get; private set; }

    public StatusInfo(Player user, Player target, StatusEffect statusEffect)
    {
        this.User = user;
        this.Target = target;
        this.StatusEffect = statusEffect;
    }
}
