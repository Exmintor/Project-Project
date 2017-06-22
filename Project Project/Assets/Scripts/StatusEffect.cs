using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect { Damage, Heal, Poison, DamageUp }

public class StatusEffect
{
    public Effect effect { get; private set; }
    public float Increase { get; private set; }
    private float duration;

    public StatusEffect(Effect effect, float increase, float duration)
    {
        this.effect = effect;
        this.Increase = increase;
        this.duration = duration;
    }
}
