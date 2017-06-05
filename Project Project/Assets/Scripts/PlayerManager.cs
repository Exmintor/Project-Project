using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private List<Player> players;

    private void Awake()
    {
        players = new List<Player>();
    }

    // Use this for initialization
    void Start ()
    {

    }
    
    // Update is called once per frame
    void Update ()
    {

    }

    public void RegisterNewPlayer(Player player)
    {
        players.Add(player);
    }

    public List<Player> GetPlayers()
    {
        return players;
    }
}
