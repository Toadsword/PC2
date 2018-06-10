using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour {

    [SerializeField] Elements objGoodElem;
    [SerializeField] List<Elements> objEnemyElem;

    [SerializeField] ScriptableObject goodAction;
    [SerializeField] ScriptableObject badAction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Elements playerElem = collision.transform.GetComponent<PlayerController>().GetElem();
            ResultElemInter result = ElementChecks.ComparePlayerElem(objGoodElem, objEnemyElem);
            switch(result)
            {
                case ResultElemInter.ALLY:
                    Destroy(gameObject);
                    //goodAction.ToString();
                    break;
                case ResultElemInter.ENEMY:
                    //badAction.ToString();
                    break;
            }
        }
    }
}
