using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class deliveryCounter : basecounter
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public static deliveryCounter Instance { get; private set; }

    public List<recipeSO> recipes;

    private List<recipeSO> orders;

    private void Awake()
    {
        Instance = this;
    }
    public override void interact(playerMovement pos)
    {
        Debug.Log(transform.name + "Interacted!!!");
        if (pos.hasobj == true)
        {
            // platekitchenobject placedplate = GetComponentInChildren<platekitchenobject>();
            platekitchenobject playerplate = pos.GetComponentInChildren<platekitchenobject>();
            //  Debug.Log(placedplate);
            if (playerplate != null )
            {
                if (checkdeliveredOrder(playerplate))
                {
                    playerplate.transform.SetParent(this.transform);
                    pos.hasobj = false;
                    gamemanager.Instance.delivered();
                    OnRecipeCompleted?. Invoke(this, EventArgs.Empty);
                    Destroy(playerplate.gameObject);
                    fillOrder();

                }
            }
        }
    }

    private void Start()
    {
        orders = new List<recipeSO>(); 
        fillOrder();
       
    }
    bool checkdeliveredOrder(platekitchenobject playerplate)
    {
        bool hasthing = false;
        foreach (recipeSO r in orders)
        {
            if(r.recipelist.Count == playerplate.klist.Count)
            {
                hasthing = true;
                foreach (KitchenObjectSO p in playerplate.klist)
                {
                    if (!r.recipelist.Contains(p))
                        hasthing = false;
                }
                if (hasthing == true)
                {
                    orders.Remove(r);
                    return true;
                }
            }
        }
        return false;
    }

    void fillOrder()
    {
        if(orders.Count != 4)
        {
            recipeSO r = recipes[UnityEngine.Random.Range(0, recipes.Count)];
            Debug.Log(r);
            orders.Add(r);
            OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            Invoke("fillOrder", 3f); 
        }    
    }
    
    public List<recipeSO> GetWaitingRecipeSOList()
    {
        return orders;
    }

}
