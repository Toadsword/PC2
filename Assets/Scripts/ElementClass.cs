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

public enum Element
{
    NORMAL,
    WATER,
    FIRE,
    EARTH,
    AIR,

    WOOD,
    ICE,
    NONE,
}

public struct ElementInteractions{
    public Element baseElement;
    public List<Element> allyElements;
    public List<Element> enemyElements;

    public ElementInteractions(Element argBaseElement, List<Element> argAllyElements, List<Element> argEnemyElements)
    {
        baseElement = argBaseElement;
        allyElements = argAllyElements;
        enemyElements = argEnemyElements;
    }
}


public static class ElementClass {

        // CONSTRUCTOR          | BASE ELEMENT  | ALLY ELEMENTS                                                     | ENEMY ELEMENTS
    static ElementInteractions[] interactions  = new ElementInteractions[] {
        new ElementInteractions(Element.NORMAL, new List<Element>(),                                                new List<Element>()),
        new ElementInteractions(Element.WATER,  new List<Element>(new Element[] { Element.ICE }),                   new List<Element>()),
        new ElementInteractions(Element.FIRE,   new List<Element>(new Element[] { Element.AIR }),                   new List<Element>(new Element[] { Element.WATER})),
        new ElementInteractions(Element.EARTH,  new List<Element>(new Element[] { Element.WATER, Element.AIR }),    new List<Element>(new Element[] { Element.FIRE})),
        new ElementInteractions(Element.AIR,    new List<Element>(),                                                new List<Element>()),
        new ElementInteractions(Element.WOOD,   new List<Element>(),                                                new List<Element>(new Element[] { Element.FIRE})),
        new ElementInteractions(Element.ICE,    new List<Element>(new Element[] { Element.WATER }),                 new List<Element>(new Element[] { Element.FIRE}))
    };

	public static ResultElemInter CheckElements(Element baseElement, Element otherElement)
    {
        ElementInteractions interaction = new ElementInteractions(Element.NONE, new List<Element>(), new List<Element>());

        for (int i = 0; i < interactions.Length; i++)
        {
            if (baseElement == interactions[i].baseElement)
            {
                interaction = interactions[i];
                break;
            }
        }

        if (interaction.baseElement == Element.NONE)
        {
            Debug.LogError("ELEMENT " + interaction.baseElement.ToString() + " IS NOT DEFINED IN THE TABLE.");
            return ResultElemInter.UNKNOWN;
        }

        if(interaction.allyElements.Contains(otherElement))
            return ResultElemInter.ALLY;
        if (interaction.enemyElements.Contains(otherElement))
            return ResultElemInter.ENEMY;

        return ResultElemInter.NORMAL;
    }
}
