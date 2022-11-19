using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float Curtime;
    public float Cooltime;

    public float Curtime_1;
    public float Cooltime_1;
    public GameObject[] Enemy;
    public GameObject FirePos;
    public GameObject bullet;
    public float Distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Curtime += Time.deltaTime;
            if (Curtime > Cooltime)
            {
                Destroy(gameObject);
            }
        if (gameObject.name == "Potop")
        {
            Curtime_1 += Time.deltaTime;
            Enemy = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < Enemy.Length; i++)
            {
                float a = Vector3.Distance(transform.position, Enemy[i].transform.position);

                if (Distance > a)
                {
                    if(Curtime_1 > Cooltime_1)
                    {
                        Debug.Log(a);
                        transform.LookAt(Enemy[i].transform);
                        Instantiate(bullet, FirePos.transform.position, FirePos.transform.rotation);
                        Curtime_1 = 0;
                    }
                    
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "flooring")
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                TotalScript.Ins.Score++;
            }
        }
    }
}
