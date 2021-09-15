using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera Cam;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }
}
