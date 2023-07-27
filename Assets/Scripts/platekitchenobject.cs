using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platekitchenobject : kitchenobject
{
    // Start is called before the first frame update

    public List<KitchenObjectSO> klist;

    private platecompletevisuals visuals;

    [SerializeField] List<KitchenObjectSO> validingredients;
    private void Awake()
    {
        klist = new List<KitchenObjectSO>() ;
        visuals = GetComponentInChildren<platecompletevisuals>();
    }
    public bool checkaddingredient(KitchenObjectSO a)
    {
        if (validingredients.Contains(a))
        {
            if (klist.Contains(a) == false)
            {
                return true;
            }
            else
                return false;
        }
        return false;

    }
    public void addingredient(KitchenObjectSO a)
    {
        klist.Add(a);
        visuals.oningredientadd(a);
    }
 }
