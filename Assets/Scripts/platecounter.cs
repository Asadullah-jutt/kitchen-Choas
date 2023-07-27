using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platecounter :basecounter
{
    // Start is called before the first frame update
    [SerializeField] KitchenObjectSO kobj;
    [SerializeField] Transform toppos;
    public Transform kobjprefab;

  

   
    public override void interact(playerMovement pos)
    {
        Debug.Log(transform.name + "Interacted!!!");

        if (pos.hasobj == false)
        {
          
            pos.hasobj = true;
            kobjprefab = Instantiate(kobj.prefab, pos.pickpos);
            // kobjprefab.GetComponent<Transform>().SetParent();
            //coutaineranimater.conins.setanimation();
            // kobjprefab = null;
        }
        else
        {
            // kobjprefab.transform.SetParent(pos);

        }
    }
    void Start()
    {
        
    }



}
