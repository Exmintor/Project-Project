using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour {

    public Player player;

    private float initialLength;
    private float length;
    private float healthPercentage;
    private Color color;

    // Use this for initialization
    void Start ()
    {
        initialLength = GetComponent<SpriteRenderer>().bounds.size.x;
        length = initialLength;
        color = Color.white;
    }
	
    // Update is called once per frame
    void Update ()
    {
        CalculateHealth();
        ChangeColor();
    }

    private void CalculateHealth()
    {
        healthPercentage = (float)player.CurrentHealth / (float)player.maxHealth;
        length = healthPercentage * initialLength;
        transform.localScale = new Vector3(length, transform.localScale.y);
    }

    private void ChangeColor()
    {
        if(healthPercentage > 0.5)
        {
            color = Color.white;
        }
        else if(healthPercentage > 0.25)
        {
            color = new Color(1, 0.5f, 0.15f, 1);
        }
        else
        {
            color = Color.red;
        }

        GetComponent<SpriteRenderer>().color = color;
    }
}
