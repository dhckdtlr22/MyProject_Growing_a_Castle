using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
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
        Attackcool = totalState.UnitSPD;
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
                    enemyState.Hp -= totalState.UnitDamage;
                    Attackcur = 0;
                }
            }
            
        }
      
        
        
    }
}
