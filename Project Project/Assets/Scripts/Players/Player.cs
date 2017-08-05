using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public PlayerClass playerClass;
    public PlayerManager playerManager;

    public int maxHealth;
    public float CurrentHealth { get; private set; }

    public float physAtkModifier;
    public float magAtkModifier;
    public float phsDefModifier;
    public float magDefModifier;

    public int teamNumber;

    public List<Ability> abilities { get; private set; }
    private List<Player> targets;

    private List<StatusEffect> currentStatusEffects;

    private float timeSinceLastAttack = 0;
    public float timeBetweenAttacks;

    private void Awake()
    {
        abilities = new List<Ability>();
        targets = new List<Player>();
        currentStatusEffects = new List<StatusEffect>();
    }
    // Use this for initialization
    void Start()
    {
        CurrentHealth = maxHealth;
        AddBasicAttack();
        playerManager.RegisterNewPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        targets = playerManager.GetPlayers();
        timeSinceLastAttack += Time.deltaTime;
        if(timeSinceLastAttack >= timeBetweenAttacks)
        {
            timeSinceLastAttack = 0;
            TakeAction();
        }

        DealWithStatusEffects();
    }

    private void AddBasicAttack()
    {
        StatusEffect basicDamage = new StatusEffect(Effect.Damage, 10, 0, 0);
        abilities.Add(new Ability("Basic Attack", 0, 1, basicDamage));
    }

    private void TakeAction()
    {
        Ability ability = ChooseAbility(); //Fix it so that is chooses relevant Ability
        List<Player> currentTargets = new List<Player>();
        for(int i = 0; i < ability.NumTargets; i++)
        {
            Player target = ChooseTarget(); //Make sure that he doesn't select the same player twice
            currentTargets.Add(target);
        }

        if (currentTargets.Count != 0 && ability != null)
        {
            foreach(Player target in currentTargets)
            {
                AffectTarget(target, this, ability);
            }
        }
    }

    private Player ChooseTarget()
    {
        Player target = ChooseRandomEnemy();
        return target;
    }

    private Ability ChooseAbility()
    {
        Ability ability = ReturnBasicAttack();
        return ability;
    }

    private void DealWithStatusEffects()
    {
        foreach(StatusEffect status in currentStatusEffects)
        {
            switch(status.effect)
            {
                case Effect.Poison:
                    status.durationTimer += Time.deltaTime;
                    status.timeSinceLastTick += Time.deltaTime;
                    if (status.durationTimer >= status.Duration)
                    {
                        //Remove status effect from list
                    }
                    else if(status.timeSinceLastTick >= status.TickTimer)
                    {
                        TakeDamage(status.Modifier);
                    }
                    break;
                case Effect.Healing:
                    status.durationTimer += Time.deltaTime;
                    status.timeSinceLastTick += Time.deltaTime;
                    if(status.durationTimer >= status.Duration)
                    {
                        //Remove status effect from list
                    }
                    else if(status.timeSinceLastTick >= status.TickTimer)
                    {
                        //Make him heal a specific target
                    }
                    break;
            }
        }
    }

    private void AffectTarget(Player target, Player user, Ability ability) //The key to your problem is here.
    {
        switch(ability.statusEffect.effect)
        {
            case (Effect.Damage):
                target.TakeDamage(ability.statusEffect.Modifier);
                break;
            case (Effect.Healing):
                this.ChannelHealing(ability, target); //But this is the new channeled heal
                break;
            case (Effect.Heal):
                target.HealYourself(ability); //It doesn't work as channeled ability
                break;
            case (Effect.Poison):
                target.InflictPoison(ability);
                break;
            case (Effect.Redirect):
                //this.RedirectIncrease(ability); 
                //target.RedirectDecrease(ability);
                break;
        }
    }

    private Player ChooseRandomEnemy()
    {
        int numTargets = 0;
        foreach (Player player in targets)
        {
            if (player.IsEnemy(teamNumber))
            {
                numTargets++;
            }
        }

        int target = Random.Range(1, numTargets + 1);
        int targetSearch = 0;
        foreach (Player player in targets)
        {
            if (player.IsEnemy(teamNumber))
            {
                targetSearch++;
            }
            if (targetSearch == target)
            {
                return player;
            }
        }

        return null;
    }

    private Ability ReturnBasicAttack()
    {
        foreach (Ability ability in abilities)
        {
            if (ability.ID == "Basic Attack")
            {
                return ability;
            }
        }

        return null;
    }

    public bool IsEnemy(int teamNum)
    {
        if (teamNum != teamNumber)
        {
            return true;
        }
        return false;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        if(CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
    }

    public void HealYourself(Ability ability)
    {
        CurrentHealth += ability.statusEffect.Modifier;
        if(CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
        if(CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }

    public void InflictPoison(Ability ability)
    {
        currentStatusEffects.Add(ability.statusEffect);
    }

    public void ChannelHealing(Ability ability, Player target)
    {
        currentStatusEffects.Add(ability.statusEffect);
    }
}
