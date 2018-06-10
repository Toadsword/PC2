using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : MonoBehaviour {

    public Elements allyElem;

	// Use this for initialization
	void Start () {
        allyElem = Elements.FIRE;
    }
	
    public Elements GetElement()
    {
        return allyElem;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ElementChecks.ChangePlayerElem(allyElem);
        }
    }
}
