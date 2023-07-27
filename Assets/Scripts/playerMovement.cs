using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
   
    Animator ani;
    [SerializeField] float movespeed = 10f;

    [SerializeField] Gameinput user_input;

    [SerializeField] LayerMask counter;

    public Transform pickpos;


    public bool hasobj = false;

    public Button intr;

   
    Vector3 dir;
    basecounter inc , lastinc;
    Vector3 lastinteraction;

  
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        user_input.onInteractaction += User_input_onInteractaction;
        intr.onClick.AddListener(() =>
        {
            buttonpressintract();
        });
    }

    void buttonpressintract()
    {
        dir = user_input.userinput();
        Debug.Log("Evant Trigger");
        if (dir != Vector3.zero)
        {
            lastinteraction = dir;
        }

        if (Physics.Raycast(transform.position, lastinteraction, out RaycastHit hit, 2f, counter))
        {
            basecounter inc = hit.transform.GetComponent<basecounter>();
            if (inc != null)
                inc.interact(this);
        }
    }


    private void User_input_onInteractaction(object sender, System.EventArgs e)
    {
      
        dir = user_input.userinput();
        Debug.Log("Evant Trigger");
        if (dir != Vector3.zero)
        {
            lastinteraction = dir;
        }

        if (Physics.Raycast(transform.position, lastinteraction, out RaycastHit hit, 2f, counter))
        {
            basecounter inc = hit.transform.GetComponent<basecounter>();
            if (inc != null)
                inc.interact(this);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamemanager.Instance.IsGamePlaying())
            return;
        HandleCollision();
        HandleInput();









    }

    void HandleCollision()
    {
        dir = user_input.userinput();

        if (dir != Vector3.zero)
        {
            lastinteraction = dir;
        }

        if (Physics.Raycast(transform.position, lastinteraction, out RaycastHit hit, 2f, counter))
        {
            inc = hit.transform.GetComponent<basecounter>();

            if (lastinc != null)
            {
                if (lastinc != inc && lastinc.getselected())
                {
                    lastinc.resetterselected();
                    Transform childTransform = lastinc.transform.Find("Selected");
                    childTransform.gameObject.SetActive(false);
                    lastinc = null;
                }
            }
            if (inc.getselected() == false)
            {
                inc.setterselected();
                Transform childTransform = inc.transform.Find("Selected");
                childTransform.gameObject.SetActive(true);
            }
            lastinc = inc;
        }
        else
        {

            if (inc != null)
            {
                if (inc.getselected() == true)
                {
                    inc.resetterselected();
                    Transform childTransform = inc.transform.Find("Selected");
                    childTransform.gameObject.SetActive(false);
                    inc = null;
                }
            }
        }
       
        
    }

    void HandleInput()
    {

        dir = user_input.userinput();

        bool CanMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, 0.7f, dir, movespeed * Time.deltaTime);



        if (!CanMove)
        {
            bool CanMoveX = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, 0.7f, new Vector3(dir.x, 0, 0), movespeed * Time.deltaTime);
            bool CanMoveZ = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2, 0.7f, new Vector3(0, 0, dir.z), movespeed * Time.deltaTime);
            if (!CanMoveX && !CanMoveZ)
                dir = Vector3.zero;
            else if (CanMoveX)
                dir.z = 0;
            else if (CanMoveZ)
                dir.x = 0;

            dir = dir.normalized;
        }
        transform.position = transform.position + dir * movespeed * Time.deltaTime;
        Vector3 a = Vector3.Lerp(transform.forward, dir, Time.deltaTime * 30f);
        if (a != Vector3.zero)
            transform.forward = a;

        if (dir == Vector3.zero)
            ani.SetBool("IsWalking", false);
        else
            ani.SetBool("IsWalking", true);

    }
}
