using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coutaineranimater : MonoBehaviour
{
    Animator ani;

    public static coutaineranimater conins;

   

    private void Awake()
    {
        conins = this;
        ani = GetComponent<Animator>();
    }

    public void setanimation()
    {
      
    }


   
}
