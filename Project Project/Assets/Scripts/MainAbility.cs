using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAbility : MonoBehaviour {

    public string ID;
    public float cooldown;
    public float channelTime;
    public float tickTimer;
    public int numTargets;

    public Effect effect;
    public float increase;
    public float duration;
	// Use this for initialization
	void Start ()
    {
        Player player = GetComponent<Player>();
        StatusEffect statusEffect = new StatusEffect(effect, increase, duration);
        Ability ability = new Ability(ID, cooldown, channelTime, tickTimer, numTargets, statusEffect);
        player.abilities.Add(ability);
	}
}
