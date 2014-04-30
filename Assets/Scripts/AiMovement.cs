// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AIMovement.cs" author="Sascha Schwarzlose">
//  
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.Remoting.Contexts;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public float Speed;
    public float Health = 10.0f;

    public GUIText StateText;
    public TextMesh AiStateText;

    public Aggressive AiAgressiveState;
    public Normal AiNormalstate;

    [SerializeField] private float _attackRange = 3.0f;
    [SerializeField] private float _pursueRange = 10.0f;
    [SerializeField] private float _distance;

    public Transform Player;

    private enum State
    {
        Idle,
        Pursue,
        Attack
    }

    //private State aiState = State.Idle;
    Context _context = new Context();

    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        _distance = Vector3.Distance(transform.position, Player.position);
        AiAgressiveState = new Aggressive();

        AgressiveAI();
    }

    //private void Move()
    //{
    //    if (aiState == State.Pursue || aiState == State.Attack)
    //    {
    //        transform.LookAt(Player.transform);
    //        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    //    }
    //}

    void UpdateState(string stateText)
    {
        AiStateText.text = stateText;
    }

    void AgressiveAI()
    {
        if (_distance <= _attackRange)
        {
            //aiState = State.Attack;
            UpdateState(global::State._state);
            AiAgressiveState.Attack(this.transform, Player);
        }

        else if (_distance <= _pursueRange && _distance > _attackRange)
        {
            AiAgressiveState.Pursuit(this.transform, Player);
            UpdateState(global::State._state);
        }

        else
        {
            AiAgressiveState.Idle();
            UpdateState(global::State._state);
        }
    }
}