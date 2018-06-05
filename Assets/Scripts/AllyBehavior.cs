using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : MonoBehaviour {

    public Element allyElem;

	// Use this for initialization
	void Start () {
        allyElem = Element.FIRE;
    }
	
    public Element GetElement()
    {
        return allyElem;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().SetElem(allyElem);
        }
    }
}
