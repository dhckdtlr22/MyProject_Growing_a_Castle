using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMake : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Curtime;
    public float Cooltime;
    public int EnemyCount;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Curtime += Time.deltaTime;
        if(Curtime > Cooltime)
        {
            InsPos();
            GameObject Enemy = Instantiate(EnemyPrefab, dir, transform.rotation);
            EnemyCount++;
            Enemy.name = "Enemy";
            Curtime = 0;
        }
        
    }
    public void InsPos()
    {
        int a = Random.Range(-25, 25);
        int b = Random.Range(1, 5);
        switch (b)      
        {
            case 1:
               dir= new Vector3(a, 0, 25);
                break;
            case 2:
                dir = new Vector3(a, 0, -25);
                break;
            case 3:
                dir = new Vector3(25, 0, a);
                break;
            case 4:
                dir = new Vector3(-25, 0, a);
                break;
        }
       
    }
}
