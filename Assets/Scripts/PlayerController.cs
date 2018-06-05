using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    float maxSpeedX = 5.0f;
    float force = 100;

    public bool canJump = false;

    public Element playerElem = Element.NORMAL;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ManageMovements();
    }

    void ManageMovements()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float newSpeed = horizontalInput * maxSpeedX;

        if (newSpeed > maxSpeedX)
            newSpeed = maxSpeedX;
        if(newSpeed < -maxSpeedX)
            newSpeed = -maxSpeedX;

        rigid.velocity = (new Vector2(newSpeed, rigid.velocity.y));

        if (Input.GetButton("Jump") && canJump && Mathf.Approximately(rigid.velocity.y, 0.0f))
        {
            canJump = false;
            rigid.AddForce(new Vector2(0, 10000));
        }
    }

    public void SetElem(Element newElem)
    {
        playerElem = newElem;
        if (playerElem == Element.FIRE)
            spriteRenderer.color = Color.red;
    }

    public Element GetElem()
    {
        return playerElem;
    }
}
