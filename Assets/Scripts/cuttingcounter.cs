using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cuttingcounter : basecounter
{


   
    public CuttingrecipeSO[] CSOarr;
    kitchenobject kobjjj;
    [SerializeField] Transform toppos;
    Animator ani; 
    CuttingrecipeSO output;
    int noofcuts = 0;
    private string cut = "Cut";

    barui pbar;

    private void Awake()
    {
        ani = GetComponentInChildren<Animator>();
        pbar = GetComponentInChildren<barui>();
    }
    public override void interact(playerMovement pos)
    {
        Debug.Log(transform.name + "Interacted!!!");
        if (pos.hasobj == true)
        {
            if (kobjjj == null)
            {
                //pos.transform.SetParent(this.transform);
                kobjjj = pos.GetComponentInChildren<kitchenobject>();
                if (canbecut(kobjjj.GetKitchenObjectSO()))
                {
                    kobjjj.transform.SetParent(this.transform);
                   
                    pos.hasobj = false;
                    kobjjj.transform.position = toppos.position;


                }
                else
                    kobjjj = null;
                Debug.Log(kobjjj);
                //  GetComponent<kitchenobject>().SetClearcounter(this) ;
            }
        }
        else if(kobjjj != null)
        {
            if (output == null)
            {
                output = getoutputforinput(kobjjj.GetKitchenObjectSO());
                noofcuts = 0;
                pbar.imgbarzero(output.tocut);
              //  Debug.Log("1");
            }
            else if (noofcuts != output.tocut)
            {
                ani.SetTrigger(cut);
                noofcuts++;
                pbar.incbar(noofcuts);
              // Debug.Log("2");
            }
            else if (output != null)
            {
                pbar.setcanvasdisable();
                kobjjj.DestroySelf();
                Instantiate(output.output.prefab, pos.pickpos);
                pos.hasobj = true;
                output = null;
                Debug.Log("3");
            }
          //  Debug.Log("");
            // output.prefab.transform.SetParent(this.transform);
        }
    }

    bool canbecut(KitchenObjectSO a)
    {
        foreach (CuttingrecipeSO CSOarr in CSOarr)
        {
            if (a == CSOarr.input)
                return true;

        }

        return false;
    }

    public CuttingrecipeSO getoutputforinput(KitchenObjectSO a)
    {
        foreach (CuttingrecipeSO CSOarr in CSOarr)
        {
            if (a == CSOarr.input)
                return CSOarr;

        }

        return null;
    }

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
