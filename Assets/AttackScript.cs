using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    public CharacterMouvement Controller;
    public float AttackLock;
    public Cooldown AtkSpeed;
    public GameObject Projectile;
    public GameObject Socket;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !Controller.Attacking && CheckTarget())
        {
            SelectEnnemy();
            
            Controller.Anim.SetTrigger("Attacking");
            Controller.Anim.speed = 10.0f;
            Controller.State = CharacterMouvement.CharacterState.ATTACKING;
            Controller.SetState();
            StartCoroutine(Controller.ResetNavigation());
        }

        if (AtkSpeed.Clock>0)
        { 
            AtkSpeed.Clock -= Time.deltaTime;
        }
    }

    public bool CheckTarget()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Targetable"))
            {
                return true;
            }else
            {
                return false;
            }
        }
        return false;
    }
    public void SelectEnnemy()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.collider.CompareTag("Targetable"))
            {
                Controller.LookAt.PointLookAt = hit.collider.gameObject;  
            }
        }
    }

    public void CreateProjectile()
    {
        Instantiate(Projectile, Socket.transform.position, Socket.transform.rotation);
    }

    [System.Serializable]
    public struct Cooldown
    {
        public float Setter;
        public float Clock;
        

        public void Reset()
        {
            Clock = Setter;
        }
    }
}
