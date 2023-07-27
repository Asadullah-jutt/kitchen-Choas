using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeliverymanagersingleUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI rname;
    [SerializeField] Transform icon;
    [SerializeField] Transform icontemp;

    private void Awake()
    {
        icontemp.gameObject.SetActive(false);
    }
    public void setRecipeSo(recipeSO so)
    {
        rname.text = so.namee;
        foreach (Transform child in icon)
        {
            if (child == icon)
                continue;
            Destroy(child.gameObject);
        }
        foreach (KitchenObjectSO kit in so.recipelist)
        {
            Transform ic = Instantiate(icontemp, icon);
            ic.gameObject.SetActive(true);
            ic.GetComponent<Image>().enabled = true;
            ic.GetComponent<Image>().sprite = kit.icon;
        }
    }
}
