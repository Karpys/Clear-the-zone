using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController Controller;
    public CharacterState State;

    [Header("Attack")]
    public bool Attacking;
    public float AtkSpeed;
    public AttackScript AttackScript;

    [Header("Mouvement ")]
    public GameObject M_Point;
    public float M_Speed;
    public bool M_CanMove;
    public Vector3 M_Navigation;
    public PointLook LookAt;
    public bool LockTarget;
    public GameObject TargetLocked;
    /*public Vector3 DebugVec;
    public GameObject Test;
    public GameObject Test2;*/
    [Header("Animation")]
    public Animator Anim;
    public Vector3 CharacterMovement;
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

        if (Input.GetMouseButtonDown(1) ||Input.GetMouseButton(1))
        {
            
            if(CheckEnnemy())
            {
                
            }else
            {
                ResetTarget();
                SetNavigation(M_Point.transform.position);
            }
        }
        if(LockTarget)
        {
            SetNavigation(TargetLocked.transform.position);
        }
        Movement(CalculateMovement(M_Navigation,M_Speed));
        LookAt.LookAt = M_Navigation;
        ProcessAnimation();
    }

    //Movement//

    public IEnumerator ResetNavigation()
    {
        yield return new WaitForEndOfFrame();
        M_Navigation = transform.position;
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
            SetCharacterMovement(Move);
        }
    }

    public void SetState()
    {
        if(State == CharacterState.IDLERUN)
        {
            M_CanMove = true;
            Attacking = false;
        }
        if(State == CharacterState.ATTACKING)
        {
            Attacking = true;
            M_CanMove = false;
        }
    }

    //Movement//

    //Animation//

    public void ProcessAnimation()
    {
        //Attack
        if(State == CharacterState.ATTACKING)
        {

        }
        //Run && Idle//
        if(State == CharacterState.IDLERUN)
        {
            if(CharacterMovement!=Vector3.zero)
            {
                Anim.speed = 1.0f;
                Anim.SetBool("Running", true);
            }else
            {
                Anim.speed = 1.0f;
                Anim.SetBool("Running", false);
            }
        }
    }

    public void SetCharacterMovement(Vector3 Movement)
    {
        CharacterMovement = Movement;
    }

    //Attack//
    public void ResetTarget()
    {
        TargetLocked = null;
        LockTarget = false;
    }

    public void SetTarget(GameObject Target)
    {
        TargetLocked = Target;
        LockTarget = true;
    }
    /*public IEnumerator Attack(float Delay, GameObject Target)
    {
        M_CanMove = false;
        yield return new WaitForSeconds(Delay);
        //CREATE BULLET WITH TARGET //
        Debug.Log("Create Bullet at " + Target.name);
        M_CanMove = true;
    }*/


    //Utilities//
    public bool CheckEnnemy()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Targetable"))
            {
                SetTarget(hit.collider.gameObject.transform.root.gameObject);
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    public enum CharacterState
    {
        NULL,
        IDLERUN,
        ATTACKING,
    }
}
