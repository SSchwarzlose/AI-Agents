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

    public virtual void Seeking(Transform agent)
    {
        _state = "Seeking";
    }
}

public class Aggressive : State
{
    public float pursueSpeed = 4;
    public float seekSpeed = 2;

    private Vector3 _corner1 = new Vector3(-8.0f, -8.0f, 0.0f);
    private Vector3 _corner2 = new Vector3(8.0f, -8.0f, 0.0f);
    private Vector3 _corner3 = new Vector3(-8.0f, 8.0f, 0.0f);

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

    public override void Seeking(Transform agent)
    {
        base.Seeking(agent);

        if (agent.position != _corner1)
        {
            agent.LookAt(_corner1);
            agent.Translate(_corner1*seekSpeed * Time.deltaTime);
        }
        else if (agent.position != _corner2)
        {
            agent.LookAt(_corner2);
            agent.Translate(_corner2 * seekSpeed * Time.deltaTime);
        }
        else if (agent.position != _corner3)
        {
            agent.LookAt(_corner3);
            agent.Translate(_corner3 * seekSpeed * Time.deltaTime);
        }
        else Idle();
    }
}

public class Normal : State
{
    public float PursueSpeed = 3;
    public float SeekSpeed = 2;

    private readonly Vector3 _corner1 = new Vector3(-8.0f, -8.0f, 0.0f);
    private readonly Vector3 _corner2 = new Vector3(8.0f, -8.0f, 0.0f);
    private readonly Vector3 _corner3 = new Vector3(-8.0f, 8.0f, 0.0f);

    public override void Idle()
    {
        base.Idle();
    }

    public override void Pursuit(Transform agent, Transform target)
    {
        base.Pursuit(agent, target);
        agent.LookAt(target);
        agent.Translate(Vector3.forward * PursueSpeed * Time.deltaTime);
    }

    public override void Attack(Transform agent, Transform target)
    {
        base.Attack(agent, target);

    }

    public override void Seeking(Transform agent)
    {
        base.Seeking(agent);

        if (agent.position != _corner1)
        {
            agent.LookAt(_corner1);
            agent.Translate(_corner1 * SeekSpeed * Time.deltaTime);
        }
        else if (agent.position != _corner2)
        {
            agent.LookAt(_corner2);
            agent.Translate(_corner2 * SeekSpeed * Time.deltaTime);
        }
        else if (agent.position != _corner3)
        {
            agent.LookAt(_corner3);
            agent.Translate(_corner3 * SeekSpeed * Time.deltaTime);
        }
        else Idle();
    }
}