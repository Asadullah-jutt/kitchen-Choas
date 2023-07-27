using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : basecounter
{
    // Start is called before the first frame update

    //[SerializeField] 
    KitchenObjectSO kobj;
    [SerializeField] Transform toppos;

    Transform kobjprefab;

    

    kitchenobject kobjjj;

    public override void interact(playerMovement pos)
    {
        Debug.Log(transform.name + "Interacted!!!");
        if (pos.hasobj == true)
        {
            platekitchenobject placedplate = GetComponentInChildren<platekitchenobject>();
            platekitchenobject playerplate = pos.GetComponentInChildren<platekitchenobject>();
            Debug.Log(placedplate);
            if (placedplate != null)
            {
                kobjjj = pos.GetComponentInChildren<kitchenobject>();
                if (placedplate.checkaddingredient(kobjjj.GetKitchenObjectSO()))
                {
                    kobjjj.transform.SetParent(this.transform);
                    pos.hasobj = false;
                    placedplate.addingredient(kobjjj.GetKitchenObjectSO());
                    kobjjj.DestroySelf();
                }

                Debug.Log("has came again");

            }
            else if (playerplate != null)
            {
                kobjjj = GetComponentInChildren<kitchenobject>();
                if (kobjjj != null)
                {
                    if (playerplate.checkaddingredient(kobjjj.GetKitchenObjectSO()))
                    {
                        //  kobjjj.transform.SetParent(this.transform);
                        pos.hasobj = true;
                        playerplate.addingredient(kobjjj.GetKitchenObjectSO());
                        kobjjj.DestroySelf();
                    }
                }
                else
                {
                    playerplate.transform.SetParent(this.transform);
                    pos.hasobj = false;
                    playerplate.transform.position = toppos.position;
                }
            }

            else if (kobjjj == null)
            {
                //pos.transform.SetParent(this.transform);
                kobjjj = pos.GetComponentInChildren<kitchenobject>();
                kobjjj.transform.SetParent(this.transform);

                pos.hasobj = false;
                kobjjj.transform.position = toppos.position;

                Debug.Log(kobjjj);
                //  GetComponent<kitchenobject>().SetClearcounter(this) ;

                // pos = null;
            }
          
        }
        else
        {
            platekitchenobject placedplate = GetComponentInChildren<platekitchenobject>();
            if(placedplate != null)
            {

                placedplate.transform.SetParent(pos.pickpos);
               // kobjjj = null;
                pos.hasobj = true;
            }
            else if (kobjjj != null)
            {
                kobjjj.transform.SetParent(pos.pickpos);
                kobjjj = null;
                pos.hasobj = true;
            }
        }
        //if (kobjprefab == null)
        //    kobjprefab = Instantiate(kobj.prefab, toppos);
        //else
        //{
        //    kobjprefab.transform.SetParent(pos);
        //    kobjprefab = null;
        //}
    }
    public Transform gkft()
    {
        return toppos;
    }

    public void SetKobj(kitchenobject kkkk)
    {
        kobjjj = kkkk;
    }
    public kitchenobject getkobj()
    {
        return kobjjj;
    }
    public void clearkobj()
    {
        kobjjj = null;
    }

    public bool haskobj()
    {
        return kobjjj != null;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
