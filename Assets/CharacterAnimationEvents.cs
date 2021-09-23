using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterMouvement Movement;

    public void SetAnimSpeed(float Speed)
    {
        Movement.Anim.speed = Speed;
    }

    public void ResetSpeedAndChangeState(CharacterMouvement.CharacterState State)
    {
        Movement.Anim.speed = 1;
        if(State!=CharacterMouvement.CharacterState.NULL)
        {
            Movement.State = State;
            Movement.SetState();
        }
        Movement.LookAt.PointLookAt = null;
    }

    public void AttackAnimSpeed()
    {
        Movement.Anim.speed = Movement.AtkSpeed;
    }

    public void CallFunctionAttack(string Function)
    {
        Movement.AttackScript.Invoke(Function, 0.0f);
    }

    public void CallFunctionMovement(string Function)
    {
        Movement.Invoke(Function, 0.0f);
    }
}
