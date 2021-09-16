using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLook : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PointLookAt;
    public Vector3 LookAt;
    public Transform playerBody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PointLookAt!=null)
        {
            transform.LookAt(new Vector3(PointLookAt.transform.position.x, playerBody.position.y, PointLookAt.transform.position.z));
        }else
        {
            transform.LookAt(new Vector3(LookAt.x, playerBody.position.y, LookAt.z));
        }
    }
}
