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
    public PointLook LookAt;
    /*public Vector3 DebugVec;
    public GameObject Test;
    public GameObject Test2;*/
    void Start()
    {
        M_Navigation = new Vector3(transform.position.x,0,transform.position.z);
    }

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
        Movement(CalculateMovement(M_Navigation,M_Speed));
        LookAt.LookAt = M_Navigation;
    }

    public Vector3 CalculateMovement(Vector3 Point,float Speed)
    {
        Vector3 Direction = (new Vector3(M_Navigation.x, 0, M_Navigation.z) - new Vector3(transform.position.x, 0, transform.position.z)).normalized;
        Vector3 VectorV = Direction * M_Speed * Time.deltaTime;
        if(NextStepTooFar(transform.position, VectorV, M_Navigation))
        {
            Debug.Log("Stop");
            return Vector3.zero;
        }else
        {
            return VectorV;
        }
    }

    public bool NextStepTooFar(Vector3 Position, Vector3 NextStep,Vector3 Point)
    {
        Position.y = 0;
        NextStep.y = 0;
        Point.y = 0;
        if(Vector3.Distance(Position,Position + NextStep) > Vector3.Distance(Position,Point))
        {
            return true;
        }else
        {
            return false;
        }
        
    }

    public void SetNavigation(Vector3 Point)
    {
        M_Navigation = Point;
    }

    public void Movement(Vector3 Move)
    {
        if(M_CanMove)
        {
            if(Move!=Vector3.zero)
            {
                Controller.Move(Move);
            }
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
