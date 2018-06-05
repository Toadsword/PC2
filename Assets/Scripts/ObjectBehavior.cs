using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour {

    [SerializeField] Element objElem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Element playerElem = collision.transform.GetComponent<PlayerController>().GetElem();
            if(ElementClass.CheckElements(objElem, playerElem) == ResultElemInter.ENEMY)
            {
                Destroy(gameObject);
            }
        }
    }
}
