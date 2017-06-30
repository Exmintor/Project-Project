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

    private float timeSinceLastAttack = 0;
    public float timeBetweenAttacks;

    private void Awake()
    {
        abilities = new List<Ability>();
        targets = new List<Player>();
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
    }

    private void AddBasicAttack()
    {
        StatusEffect basicDamage = new StatusEffect(Effect.Damage, 10, 0);
        abilities.Add(new Ability("Basic Attack", 0, 0, 0, 1, basicDamage));
    }

    private void TakeAction()
    {
        Ability ability = ChooseAbility(); //Fix it so that is chooses relevant Ability
        List<Player> targets = new List<Player>();
        for(int i = 0; i < ability.NumTargets; i++)
        {
            Player target = ChooseTarget(); //Make sure that he doesn't select the same player twice
            targets.Add(target);
        }

        if (targets.Count != 0 && ability != null)
        {
            foreach(Player target in targets)
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

    private void AffectTarget(Player target, Player user, Ability ability)
    {
        switch(ability.statusEffect.effect)
        {
            case (Effect.Damage):
                target.TakeDamage(ability);
                break;
            case (Effect.Heal):
                target.HealYourself(ability); //It doesn't work as channeled ability
                break;
            case (Effect.Poison):
                //target.InflictPoison(ability);
                break;
            case (Effect.Redirect):
                //target.RedirectDecrease(ability, user);
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

        int target = Random.Range(0, numTargets + 1);
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

    public void TakeDamage(Ability ability)
    {
        CurrentHealth -= ability.statusEffect.Modifier;
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
}
