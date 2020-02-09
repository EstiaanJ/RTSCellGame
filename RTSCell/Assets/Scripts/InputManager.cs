using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    public float panSpeed = 5;

    private float panDetect = 15f;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }


    void MoveCamera()
    {
        float moveX = Camera.main.transform.position.x;
        float moveY = Camera.main.transform.position.y;

        float xPos = Input.mousePosition.x;
        float yPos = Input.mousePosition.y;

        if (Input.GetKey(KeyCode.A) || xPos > 0 && xPos < panDetect)
        {
            moveX -= panSpeed;
            print("move x neg");
        }
        else if (Input.GetKey(KeyCode.D) || xPos < Screen.width && xPos > (Screen.width - panDetect))
        {
            moveX += panSpeed;
            print("move x pos");
        }

        if (Input.GetKey(KeyCode.W) || yPos < Screen.height && yPos > (Screen.height - panDetect))
        {
            moveY += panSpeed;
            print("move y pos");
        }
        else if (Input.GetKey(KeyCode.S) || yPos > 0 && yPos < panDetect)
        {
            moveY -= panSpeed;
            print("move y neg");
        }

        Vector3 newPos = new Vector3(moveX, moveY, 0);

        Camera.main.transform.position = newPos;
    }
}

