using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect { Damage, Heal, Poison, Redirect, DamageUp }

public class StatusEffect
{
    public Effect effect { get; private set; }
    public float Modifier { get; private set; }
    public  float TickTimer { get; private set; }
    public float Duration { get; private set; }

    public float durationTimer = 0;
    public float timeSinceLastTick = 0;

    public StatusEffect(Effect effect, float modifier, float tickTimer, float duration)
    {
        this.effect = effect;
        this.Modifier = modifier;
        this.TickTimer = tickTimer;
        this.Duration = duration;
    }
}
