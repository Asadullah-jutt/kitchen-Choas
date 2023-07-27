using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenuUI : MonoBehaviour
{
    [SerializeField] Button playbutton;
    [SerializeField] Button quitbutton;
    // Start is called before the first frame update

    private void Awake()
    {
        playbutton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
        quitbutton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

   
}
