using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stovecounter : basecounter
{
    kitchenobject kobjjj;
    [SerializeField] Transform toppos;
    public CuttingrecipeSO[] CSOarr;
    CuttingrecipeSO output;
    barui pbar;

    private void Awake()
    {
        pbar = GetComponentInChildren<barui>();
    }
    public override void interact(playerMovement pos)
    {
        Debug.Log(kobjjj + "Interacted!!!");
        if (pos.hasobj == true)
        {
            if (kobjjj == null)
            {
                //pos.transform.SetParent(this.transform);
                kobjjj = pos.GetComponentInChildren<kitchenobject>();
                if (canbecooked(kobjjj.GetKitchenObjectSO()) )
                {
                    print("picked");
                    kobjjj.transform.SetParent(this.transform);
                    pos.hasobj = false;
                    kobjjj.transform.position = toppos.position;
                    putonflame();

                }
               

                //  GetComponent<kitchenobject>().SetClearcounter(this) ;
            }
        }
        else if (kobjjj != null)
        {
            Debug.Log("tried to pick");
            pbar.setcanvasdisable();
            kobjjj.transform.SetParent(pos.pickpos);
            kobjjj = null;
            pos.hasobj = true;
            output = null;

        }
    }
    bool canbecooked(KitchenObjectSO a)
    {
        foreach (CuttingrecipeSO CSOarr in CSOarr)
        {
           // Debug.Log(CSOarr.input + "and " + a);
            if (a == CSOarr.input)
                return true;

        }

        return false;
    }
    private IEnumerator StartCountdown()
    {
        float elapsedTime = 0;
        output = getoutputforinput(kobjjj.GetKitchenObjectSO());
        pbar.imgbarzero(output.tocut);
        int time = output.tocut;
        while (elapsedTime < time) 
        {
            
            elapsedTime += 0.5f;
            pbar.incbar(elapsedTime);
            yield return new WaitForSeconds(0.5f);
            elapsedTime += 0.5f;
            pbar.incbar(elapsedTime);
            yield return new WaitForSeconds(0.5f);
        }
        pbar.setcanvasdisable();
        kobjjj.DestroySelf();
        Transform a = Instantiate(output.output.prefab, this.transform);
        a.transform.position = toppos.position;
        Debug.Log(kobjjj);
        kobjjj = a.GetComponent<kitchenobject>();
        Debug.Log(kobjjj + "Countdown complete!");
        if(output.output != CSOarr[1].output)
            StartCoroutine(StartCountdown());

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

    // Example usage

    void putonflame()
    {

        StartCoroutine(StartCountdown());
    }
}
