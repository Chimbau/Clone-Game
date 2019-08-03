using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    public List<Button> buttons;
    public bool openCondition = false;
    private bool isOpened = false;
    public float openDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        openCondition = CheckButtons();
        if (openCondition)
        {
            OpenDoor();
            isOpened = true;
        }
        else
        {
            CloseDoor();
            isOpened = false;
        }
    }

    public bool CheckButtons()
    {
        foreach (Button button in buttons)
        {
            if (!button.isPressed())
            {
                return false;
            }
        }
        return true;
    }

    public void OpenDoor()
    {
        if (!isOpened)
        {
            transform.position += new Vector3(0, openDistance, 0);
        }
        

    }

    public void CloseDoor()
    {
        if (isOpened)
        {
            transform.position -= new Vector3(0, openDistance, 0);
        }
    }
}
