using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    public float Speed;
    public int Damage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
            if(Vector3.Distance(transform.position,Target.transform.position)<0.2f)
            {
                Destroy(gameObject);
                Target.GetComponent<LifeManager>().Life -= Damage;
            }
        }else
        {
            Destroy(this.gameObject);
        }
    }
}
