using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public int Speed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Home");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Home"))
        {
            TotalScript.Ins.hp--;
            Destroy(gameObject);
        }
    }
}
