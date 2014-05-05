// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AIMovement.cs" author="Sascha Schwarzlose">
//  
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public float Speed;
    public float Health = 100.0f;

    public GUIText StateText;
    public TextMesh AiStateText;

    public Aggressive AiAgressiveState;
    public Normal AiNormalstate;

    [SerializeField] private float _attackRange = 3.0f;
    [SerializeField] private float _pursueRange = 10.0f;
    [SerializeField] private float _distance;

    public Transform Player;
    private Transform _agent;

    private enum State
    {
        Idle,
        Pursue,
        Attack
    }

    //private State aiState = State.Idle;
    

    void Start()
    {
        _agent = this.transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        _distance = CheckDistance(_agent, Player);

        AiAgressiveState = new Aggressive();
		AiNormalstate = new Normal();

        if (Health > 50)
        {
            AgressiveAI();
        }
        else if (Health <= 50)
        {
            NormalAI();
        }
        else
        {
            AgressiveAI();
        }
        
    }

    void UpdateState(string stateText)
    {
        AiStateText.text = stateText;
    }

    float CheckDistance(Transform agent, Transform player)
    {
        return Vector3.Distance(agent.position, player.position);
    }

    public void AgressiveAI()
    {
        if (_distance <= _attackRange)
        {
            UpdateState(global::State._state);
            AiAgressiveState.Attack(_agent, Player);
        }

        else if (_distance <= _pursueRange && _distance > _attackRange)
        {
            AiAgressiveState.Pursuit(_agent, Player);
            UpdateState(global::State._state);
        }

        else
        {
            AiAgressiveState.Idle();
            UpdateState(global::State._state);
        }
    }

    void NormalAI()
    {
		if(null != _agent && null != Player)
		{
	        if (_distance <= _attackRange)
	        {
	            UpdateState(global::State._state);
	            AiNormalstate.Attack(_agent, Player);
	        }
	        else if (_distance <= _pursueRange)
	        {
				Debug.Log(global::State._state);
				Debug.Log(_agent);
				Debug.Log (Player);
	            UpdateState(global::State._state);
	            if (_agent != null) AiNormalstate.Pursuit(_agent, Player);
	        }

	        else if (_distance > _pursueRange)
	        {
	            UpdateState(global::State._state);
	            //AiNormalstate.Seeking(_agent);
	        }
	        else
	        {
	            UpdateState(global::State._state);
	            AiNormalstate.Idle();
	        }
		}
		else print("Could not find refference to _agent or Player. ");
    }
}