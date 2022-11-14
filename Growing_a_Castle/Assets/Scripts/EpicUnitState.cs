using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicUnitState : MonoBehaviour
{
    public AttackZone attackZone;
    public EnemyState enemyState;
    public EnemyMaker enemyMaker;

    public int Example_EpicDamage;
    public float Attackcur;
    public float Attackcool;
    // Start is called before the first frame update
    void Start()
    {
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyMaker.IsBattle == true)
        {
            if (attackZone.EnemyIn == true)
            {
                Debug.Log(attackZone.Enemy);
                transform.LookAt(attackZone.Enemy[0].transform);
                enemyState = attackZone.Enemy[0].GetComponent<EnemyState>();
                Attackcur += Time.deltaTime;
                if (Attackcur > Attackcool)
                {
                    enemyState.Example_Hp -= Example_EpicDamage;
                    Attackcur = 0;
                }
            }
        }
    }
}
