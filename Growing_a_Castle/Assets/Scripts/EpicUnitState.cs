using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicUnitState : MonoBehaviour
{
    public AttackZone attackZone;
    public EnemyState enemyState;
    public EnemyMaker enemyMaker;
    public TotalState totalState;
    
    public float Attackcur;
    public float Attackcool;
    // Start is called before the first frame update
    void Start()
    {
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        totalState = GameObject.Find("TotalState").GetComponent<TotalState>();
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
                Vector3 dir = transform.localRotation.eulerAngles;
                dir.x = 0;
                transform.localRotation = Quaternion.Euler(dir);
                enemyState = attackZone.Enemy[0].GetComponent<EnemyState>();
                Attackcur += Time.deltaTime;
                if (Attackcur > Attackcool)
                {
                    enemyState.Hp -= totalState.EpicUnitDamage;
                    Attackcur = 0;
                }
            }
        }
    }
}
