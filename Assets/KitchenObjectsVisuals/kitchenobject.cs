using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenobject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kobj;

    counter ccc;
    
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kobj;
    }

    public void SetClearcounter(counter cou)
    {
        if (ccc != null)
        {
           
            ccc.clearkobj();
          
        }
        this.ccc = cou;
        cou.SetKobj(this);
        transform.parent = cou.gkft();
        // transform.parent = cou.transform;
        transform.localPosition = Vector3.zero;

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
