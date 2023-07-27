using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barui : MonoBehaviour
{
    // Start is called before the first frame update

   

    [SerializeField] Image img;

    [SerializeField] Canvas canvas; 

    float setmax;

    private void Awake()
    {
        img.fillAmount = 0f;
        canvas.enabled = false;
    }


    void setcanvasactive()
    {
        canvas.enabled = true;
    }
    public void setcanvasdisable()
    {
        canvas.enabled = false;
    }
    public void imgbarzero(float max)
    {
        img.fillAmount = 0f;
        setmax = max;
        setcanvasactive();
    }

    public void incbar(float progess)
    {
        img.fillAmount = progess / setmax;
    }




}
