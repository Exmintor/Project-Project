using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public string Race { get; private set; }
    public string PlayerClass { get; private set; }
    public string Background { get; private set; }
    public int Price { get; private set; }

    public Character(string name, string race, string playerClass, string background, int price)
    {
        Name = name;
        Race = race;
        PlayerClass = playerClass;
        Background = background;
        Price = price;
    }
}
