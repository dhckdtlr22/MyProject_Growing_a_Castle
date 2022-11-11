using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public float Speed;
    public bool Attack = false;
    public int Example_Hp;
    public AttackZone attackZone;
    // Start is called before the first frame update
    void Start()
    {
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        Example_Hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(Attack == false)
        {
            transform.Translate(0, 0, -Speed * Time.deltaTime);
        }
        if(Example_Hp <= 0)
        {
            attackZone.Enemy.RemoveAt(0);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            Attack = true;
        }
    }
}
