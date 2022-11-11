using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public AttackZone attackZone;
    public EnemyState enemyState;
    public int Example_Damage;
    public float Attackcur;
    public float Attackcool;
    // Start is called before the first frame update
    void Start()
    {
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        Example_Damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(attackZone.EnemyIn == true) 
        {
            Debug.Log(attackZone.Enemy);
            transform.LookAt(attackZone.Enemy[0].transform);
            enemyState = attackZone.Enemy[0].GetComponent<EnemyState>();
        }
        if(attackZone.EnemyIn == true)
        {
            Attackcur += Time.deltaTime;
            if (Attackcur > Attackcool)
            {
                enemyState.Example_Hp -= Example_Damage;
                Attackcur = 0;
            }
        }
        
    }
}
