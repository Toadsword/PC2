using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResultElemInter
{
    UNKNOWN = -2,
    ENEMY = -1,
    NORMAL = 0,
    ALLY = 1
}

public enum Elements
{
    NORMAL,
    WATER,
    FIRE,
    ELECTRICITY
}

public static class ElementChecks {
    
    private static PlayerController player = null;

    public static void Init(PlayerController playerController)
    {
        player = playerController;
    }

    public static ResultElemInter ComparePlayerElem(Elements goodElement, List<Elements> badElements)
    {
        Elements playerElem = player.GetElem();
        if (goodElement == playerElem)
            return ResultElemInter.ALLY;
        if (badElements.Contains(playerElem))
            return ResultElemInter.ENEMY;

        return ResultElemInter.NORMAL;
    }

    public static bool ChangePlayerElem(Elements newElem)
    {
        if (player == null)
            Debug.LogError("Player not set in element class.");

        Elements playerElem = player.GetElem();
        if(playerElem == Elements.NORMAL || newElem == Elements.NORMAL)
        {
            playerElem = newElem;
            player.SetElem(newElem);
            return true;
        } 
        else
        {
            return false;
        }
    }

    public static Elements GetPlayerElem()
    {
        if (player == null)
            Debug.LogError("Player not set in element class.");
        return player.GetElem();
    }

    public static PlayerController GetPlayerController()
    {
        return player;
    }
}
