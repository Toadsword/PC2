using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeets : MonoBehaviour {

    PlayerController player;

	// Use this for initialization
	void Start () {
        player = transform.parent.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.canJump = true;
    }
}
