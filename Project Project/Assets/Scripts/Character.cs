using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public string Race { get; private set; }
    public string PlayerClass { get; private set; }
    public string Background { get; private set; }

    public Character(string name, string race, string playerClass, string background)
    {
        Name = name;
        Race = race;
        PlayerClass = playerClass;
        Background = background;
    }
}
