using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController Controller;
    

    [Header("Mouvement ")]
    public GameObject M_Point;
    public float M_Speed;
    public bool M_CanMove;
    public Vector3 M_Navigation;


    // Update is called once per frame
    void Update()
    {
        //Battlerite
        /*float Axex = Input.GetAxis("Horizontal");
        float Axez = Input.GetAxis("Vertical");

        Vector3 Axes = transform.right * Axex + transform.forward * Axez;
        Vector3 Move = Axes * M_Speed * Time.deltaTime;

        Movement(Move);*/

        //Leauge of Puanteur//

        if (Input.GetMouseButtonDown(0))
        {
            SetNavigation(M_Point.transform.position);
        }
        CalculateMovement(M_Navigation,M_Speed);
        
    }

    public void CalculateMovement(Vector3 Point,float Speed)
    {

    }

    public void SetNavigation(Vector3 Point)
    {

    }

    public void Movement(Vector3 Move)
    {
        if(M_CanMove)
        {
        Controller.Move(Move);
        }
    }

    public IEnumerator Attack(float Delay,GameObject Target)
    {
        M_CanMove = false;
        yield return new WaitForSeconds(Delay);
        //CREATE BULLET WITH TARGET //
        Debug.Log("Create Bullet at " + Target.name);
        M_CanMove = true;
    }
}
