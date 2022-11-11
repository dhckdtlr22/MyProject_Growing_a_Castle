using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public AttackZone attackZone;
    // Start is called before the first frame update
    void Start()
    {
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();

    }

    // Update is called once per frame
    void Update()
    {
        if(attackZone.EnemyIn == true) 
        {
            Debug.Log(attackZone.Enemy);
            transform.LookAt(attackZone.Enemy[0].transform);
        }    

    }
}
