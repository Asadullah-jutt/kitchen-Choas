using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class countUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI counting;
    [SerializeField] Image img;
    [SerializeField] private TextMeshProUGUI gameover;
    [SerializeField] private TextMeshProUGUI recipedeli;
    [SerializeField] private TextMeshProUGUI recipecount;
    [SerializeField] Image circle;
    [SerializeField] Image incircle;
    float time;
    private void Start()
    {
        gamemanager.Instance.OnStateChanged += Instance_OnStateChanged;
          hide();
    }

    private void Instance_OnStateChanged(object sender, System.EventArgs e)
    {
        if (gamemanager.Instance.iscountdownstartactive())
            show();
        else
            hide();
    }

    private void Update()
    {
        if (gamemanager.Instance.IsGamePlaying())
        {
            circle.gameObject.SetActive(true);
            incircle.gameObject.SetActive(true);
            circle.enabled = true;
            incircle.enabled = true;

            time = gamemanager.Instance.gameplaytimegetter();
            if (time <= 0.3)
                incircle.color = Color.red;
            else
                incircle.color = Color.blue;
            incircle.fillAmount = time;
        }
        else if(gamemanager.Instance.IsGameOver())
        {
            circle.gameObject.SetActive(false);
            incircle.gameObject.SetActive(false);
            counting.enabled = false;
            img.gameObject.SetActive(true);
            gameover.enabled = true;
            recipedeli.enabled = true;
            recipecount.text = gamemanager.Instance.totaldeliveries.ToString();
            recipecount.enabled = true;

        }

    }

    void show()
    {
        counting.enabled =  true;
        textc();
    }
    void textc()
    {
       int time = gamemanager.Instance.gameplayingtimer();
        Debug.Log(time);
        counting.text = time.ToString();
        if (time > 0)
            Invoke("textc", 0.5f);
        else
            hide();
    }
    void hide()
    {
        counting.enabled = false;
    }
}
