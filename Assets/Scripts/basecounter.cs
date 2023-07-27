using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basecounter : MonoBehaviour
{
    bool selected = false;
    public bool getselected()
    {
        return selected;
    }
    public void setterselected()
    {
        selected = true;
    }
    public void resetterselected()
    {
        selected = false;
    }

    public virtual void interact(playerMovement pos) {
        Debug.Log("baseclass");
    }
    
}
