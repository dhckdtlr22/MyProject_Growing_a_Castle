using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum State
    {
        IDLE = 0,
        MOVE,
        ATTACK,
    }
    public State state;
    public float Speed = 1f;
    public bool Attack = false;
    public int Hp = 10;
    public int Damage = 50;
    public float Attackcur;
    public float AttackCool =1f;
    public AttackZone attackZone;
    public EnemyMaker enemyMaker;
    public TotalState total;

    // Start is called before the first frame update
    void Start()
    {
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
        
        state = State.MOVE;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case State.IDLE:
                break;
            case State.MOVE:
                transform.Translate(0, 0, -Speed * Time.deltaTime);
                
                break;
            case State.ATTACK:
                Attackcur += Time.deltaTime;
                if(Attackcur > AttackCool)
                {
                    total.CastleHp -= Damage;
                    Attackcur = 0;
                }
                break;
            
        }
        
        if(Hp <= 0)
        {
            attackZone.Enemy.RemoveAt(0);
            enemyMaker.KillCount++;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            state = State.ATTACK;
        }
    }
}
