using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverymanagerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;
    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {
        deliveryCounter.Instance.OnRecipeSpawned += Instance_OnRecipeSpawned;
        deliveryCounter.Instance.OnRecipeCompleted += Instance_OnRecipeCompleted;
       Invoke("UpdateVisual",1f);
    }
    private void Instance_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void Instance_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach (recipeSO recipeso in deliveryCounter.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<DeliverymanagersingleUI>().setRecipeSo(recipeso);
        }
    }

}
