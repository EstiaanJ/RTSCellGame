using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    //using https://www.youtube.com/watch?v=LoKNYlWWeSM as a reference
    //Note that the video is for MOBA movement not strictly RTS movement.
    Camera cam; 

    public LayerMask groundLayer;
    public NavMeshAgent unitAgent;
    // Start is called before the first frame update
    void Awake ()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            unitAgent.SetDestination(GetPointUnderCursor());
        }
    }


    private Vector3 GetPointUnderCursor()
    {
        Vector2 screenPos = Input.mousePosition;
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(screenPos);

        RaycastHit hitPos;
        Physics.Raycast(mouseWorldPos, cam.transform.forward, out hitPos, 100, groundLayer);

        return hitPos.point;
    }
}
