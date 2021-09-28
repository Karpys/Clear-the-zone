using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    public CharacterMouvement Controller;
    public float AttackLock;
    public float AttackRange;
    public Cooldown AtkSpeed;
    public GameObject Projectile;
    public GameObject Socket;
    // Update is called once per frame
    void Update()
    {
        
        if(Controller.TargetLocked!=null)
        {
            if (!Controller.Attacking && Vector3.Distance(Controller.gameObject.transform.position, Controller.TargetLocked.transform.position)< AttackRange)
            {
                Attack();
            }
        }

        if (AtkSpeed.Clock>0)
        { 
            AtkSpeed.Clock -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        FaceEnnemy();
        Controller.Anim.SetTrigger("Attacking");
        Controller.Anim.speed = 10.0f;
        Controller.State = CharacterMouvement.CharacterState.ATTACKING;
        Controller.SetState();
        StartCoroutine(Controller.ResetNavigation());
    }

    public void FaceEnnemy()
    {
        Controller.LookAt.PointLookAt = Controller.TargetLocked;
        Target = Controller.TargetLocked;
    }

    public void CreateProjectile()
    {
        GameObject Proj = Instantiate(Projectile, Socket.transform.position, Socket.transform.rotation);
        Proj.GetComponent<ProjectileComponent>().Target = Target;
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
