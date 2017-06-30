using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect { Damage, Heal, Poison, Redirect, DamageUp }

public class StatusEffect
{
    public Effect effect { get; private set; }
    public float Modifier { get; private set; }
    private float duration;

    public StatusEffect(Effect effect, float modifier, float duration)
    {
        this.effect = effect;
        this.Modifier = modifier;
        this.duration = duration;
    }
}
