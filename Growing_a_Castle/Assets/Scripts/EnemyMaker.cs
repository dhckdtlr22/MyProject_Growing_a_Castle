using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject EnemyPrefab;
    
    public float curtime;
    public float cooltime;

    // Start is called before the first frame update
    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { 
        curtime += Time.deltaTime;

        if(curtime > cooltime)
        {
            int rand = Random.Range(-15, 14);
            GameObject Enemy = Instantiate(EnemyPrefab);
            Enemy.name = "Enemy";
            Enemy.transform.position = new Vector3(transform.position.x + rand, transform.position.y, transform.position.z);
            curtime = 0;
        }
    }
}
