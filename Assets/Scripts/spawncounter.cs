using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncounter : basecounter
{
    // Start is called before the first frame update
    [SerializeField] KitchenObjectSO kobj;
    [SerializeField] Transform toppos;
    public Transform kobjprefab;
  
    Animator ani;

    private string open_close = "OpenClose";
    public override void interact(playerMovement pos)
    {
        Debug.Log(transform.name + "Interacted!!!");
       
        if (pos.hasobj == false)
        {
            ani.SetTrigger(open_close);
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
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
