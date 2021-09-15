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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectEnnemy();
        }

        if(AtkSpeed.Clock>0)
        { 
            AtkSpeed.Clock -= Time.deltaTime;
        }
    }

    public void SelectEnnemy()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.collider.CompareTag("Targetable"))
            {
                if(AtkSpeed.Clock<=0)
                {
                    AtkSpeed.Reset();
                    StartCoroutine(Controller.Attack(AttackLock, hit.collider.gameObject.transform.parent.gameObject));
                }
            }
        }
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
