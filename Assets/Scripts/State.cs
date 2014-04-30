using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class State
{
    public static string _state = "";

    public virtual void Idle()
    {
        _state = "Idle";
    }

    public virtual void Pursuit(Transform agent, Transform target)
    {
        _state = "Pursuing";
    }

    public virtual void Attack(Transform agent, Transform target)
    {
        _state = "Attacking";
    }
}

public class Aggressive : State
{
    public float pursueSpeed = 4;
    public float seekSpeed = 2;

    public override void Idle()
    {
        base.Idle();
    }

    public override void Pursuit(Transform agent, Transform target)
    {
        base.Pursuit(agent, target);
        agent.LookAt(target);
        agent.Translate(Vector3.forward*pursueSpeed*Time.deltaTime);
    }

    public override void Attack(Transform agent, Transform target)
    {
        base.Attack(agent, target);

    }
}

public class Normal : State
{
    public float pursueSpeed = 3;
    public float seekSpeed = 2;

    public override void Idle()
    {
        base.Idle();
    }

    public override void Pursuit(Transform agent, Transform target)
    {
        base.Pursuit(agent, target);
        agent.LookAt(target);
        agent.Translate(Vector3.forward * pursueSpeed * Time.deltaTime);
    }

    public override void Attack(Transform agent, Transform target)
    {
        base.Attack(agent, target);

    }
}