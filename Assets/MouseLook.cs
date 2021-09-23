using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 MousePosition;
    public Camera Cam;

    public Transform playerBody;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            transform.LookAt(new Vector3(raycastHit.point.x,playerBody.position.y,raycastHit.point.z));
        }
    }
}
