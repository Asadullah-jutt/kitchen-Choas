using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class platecompletevisuals : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] platekitchenobject platecc;
    [Serializable]
    public struct kitchenObjectSO_GameObject 
    {
        public KitchenObjectSO kitobj;
        public GameObject obj;
    }
    public List<kitchenObjectSO_GameObject> objlist;

    public void oningredientadd(KitchenObjectSO a)
    {
        foreach (kitchenObjectSO_GameObject obj in objlist)
        {
            if (obj.kitobj == a)
                obj.obj.SetActive(true);
        }
    }

   
}
