using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashcounter : basecounter
{
    kitchenobject kobjjj;
   //SerializeField] Transform toppos;
    // Start is called before the first frame update

    public override void interact(playerMovement pos)
    {
        Debug.Log(transform.name + "Interacted!!!");
        if (pos.hasobj == true)
        {
            if (kobjjj == null)
            {
                //pos.transform.SetParent(this.transform);
                kobjjj = pos.GetComponentInChildren<kitchenobject>();
                kobjjj.transform.SetParent(this.transform);
                kobjjj.DestroySelf();
                pos.hasobj = false;
               

            }
        }
    }
}
