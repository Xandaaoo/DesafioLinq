 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DTO;
using System.IO;
using System.Linq;

public class GameController : MonoBehaviour
{
    public PlayersData playersData;

    private void Start() { LoadJson(); }

    public void Answer1()
    {
        var morePoints = playersData.players
                        .Select(player => new { Player = player.name, Points = player.points })
                        .OrderByDescending(player => player.Points)
                        .Take (3)
                        .ToList();
        changeText(morePoints.AllToString());
    }

    public void Answer2()
    {
        var all = playersData.players
                        .Select(player => new { Player = player.name, Country = player.countryName, Heroes = player.heroes })
                        .OrderBy(player => player.Country)
                        .ToList();
        string noheroCountry = "";

        foreach (var player in all)
        {
            if (player.Heroes.Count == 0) noheroCountry += (player.ToString());
        }

        changeText(noheroCountry);
    }

    public void Answer3()
    {
        var less = playersData.players
            .GroupBy(player => player.countryName)
            .Select(country => new { Class = country.Key, Count = country.Count() })
            .OrderBy(count => count.Count)
            .Take(1)
            .ToList();

        var most = playersData.players
            .SelectMany(player => player.heroes)
            .GroupBy(player => player.heroClassName)
            .Select(hero => new { Class = hero.Key, Count = hero.Count() })
            .OrderByDescending(count => count.Count)
            .Take(1)
            .ToList();


        changeText(most.AllToString() + less.AllToString());
        //Debug.Log(less.AllToString());
    }
    public void Answer4()
    {
        

        var most = playersData.players
            .GroupBy(player => player.countryName)
            .Select(country => new { Class = country.Key, Count = country.Count() })
            .OrderByDescending(count => count.Count)
            .Take(1)
            .ToList();

        changeText(most.AllToString());
    }

    public void Answer5()
    {
        var plataform = playersData.players
            .GroupBy(plat => plat.platformName)
            .Select(plat => new { Plataform = plat.Key, Points = plat.Sum(Points => Points.points) / plat.Count() })
            .OrderByDescending(Points => Points.Points)
            .Take(1)
            .ToList();

        changeText(plataform.AllToString());
    }
    public void Answer6()
    {
        var plataform = playersData.players
            .Select(player => new { Player = player.name, Gold = player.heroes.Sum(hero => hero.gold) })
            .OrderByDescending(Player => Player.Gold)
            .Take(10)
            .ToList();

        changeText(plataform.AllToString());
    }

    public void LoadJson()
    {
        var json = Resources.Load<TextAsset>("data1.json");
        playersData = JsonUtility.FromJson<PlayersData>(json.text);
        changeText(playersData.ToString());
    }





    public Text textMesh;

   
    private void changeText(string text)
    {
        textMesh.text = text;
    }

}
