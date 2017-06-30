using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterElement { Name, Race, Class, Background }
public class CharacterGenerator : MonoBehaviour {

    public int NumberOfCharacter;
    public List<Character> CharacterList { get; private set; }

    private List<string> names;
    private List<string> races;
    private List<string> classes;
    private List<string> backgrounds;

    private Random rand;

    private void Awake()
    {
        CharacterList = new List<Character>();

        names = new List<string>();
        races = new List<string>();
        classes = new List<string>();
        backgrounds = new List<string>();

        PopulateNames();
        PopulateRaces();
        PopulateClasses();
        PopulateBackgrounds();

        for (int i = 0; i < NumberOfCharacter; i++)
        {
            Character newChar = GenerateRandomCharacter();
            CharacterList.Add(newChar);
        }
    }
    // Use this for initialization
    void Start ()
    {
	}

    private Character GenerateRandomCharacter()
    {
        string name = GetRandomStringFromList(names);
        string race = GetRandomStringFromList(races);
        string playerClass = GetRandomStringFromList(classes);
        string background = GetRandomStringFromList(backgrounds);

        Character character = new Character(name, race, playerClass, background);
        return character;
    }

    private string GetRandomStringFromList(List<string> list)
    {
        int number = Random.Range(0, list.Count);
        string element = list[number];
        return element;
    }

    private void PopulateNames()
    {
        names.Add("Rufus");
        names.Add("Excelsior");
        names.Add("Gruftur");
        names.Add("Skinkle");
        names.Add("Razmataz");
    }

    private void PopulateRaces()
    {
        races.Add("Hyena");
        races.Add("Djinn");
        races.Add("Skeleton");
        races.Add("Snek");
        races.Add("Gifted");
    }

    private void PopulateClasses()
    {
        classes.Add("Warrior");
        classes.Add("Time Mage");
        classes.Add("Old Fart");
        classes.Add("Necromancer");
        classes.Add("Spellsword");
    }

    private void PopulateBackgrounds()
    {
        backgrounds.Add("Veteran");
        backgrounds.Add("Scholar");
        backgrounds.Add("Baker");
        backgrounds.Add("Shoemaker");
        backgrounds.Add("Assassin");
    }
}
