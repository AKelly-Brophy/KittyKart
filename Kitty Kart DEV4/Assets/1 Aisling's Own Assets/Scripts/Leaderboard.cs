using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

struct PlayerStats
{
    public string name;
    public int position;
    public float time;

    public PlayerStats(string n, int p, float t)
    {
        name = n;
        position = p;
        time = t;
    }
}

public class Leaderboard
{
    static Dictionary<int, PlayerStats> lb = new Dictionary<int, PlayerStats>();
    static int carsRegistered = -1;

    public static int RegisterCar(string name)
    {
        carsRegistered++;
        lb.Add(carsRegistered, new PlayerStats(name, 0, 0));
        return carsRegistered;
    }

    public static void SetPosition(int rego, int lap, int checkpoint, float time)
    {
        int position = lap * 1000 + checkpoint;
        lb[rego] = new PlayerStats(lb[rego].name, position, time);

    }

    public static string GetPosition(int rego)
    {
        int index = 0;
        foreach (KeyValuePair<int, PlayerStats> pos in lb.OrderByDescending(key => key.Value.position).ThenBy(key => key.Value.time))
        {
            index++;
            if(pos.Key == rego)
                switch (index)
                {
                    case 1: return "First";
                    case 2: return "Second";
                    case 3: return "Third";
                    case 4: return "Fourth";
                }
        }
        return "Unknown";
    }

    public static List<string> GetPlaces()
    {
        List<string> places = new List<string>();
        foreach (KeyValuePair<int, PlayerStats> pos in lb.OrderByDescending(key => key.Value.position).ThenBy(key => key.Value.time))
        {
            places.Add(pos.Value.name);
        }

        return places;
    }

}
