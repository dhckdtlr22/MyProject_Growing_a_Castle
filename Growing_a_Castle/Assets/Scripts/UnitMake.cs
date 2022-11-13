using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMake : MonoBehaviour
{
    public Transform[] Pos;
    public GameObject UnitPrefab;
    public TotalState total;
    public int UnitNumMax = 15;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            Pos[i] = GameObject.Find($"UnitPos{i+1}").GetComponent<Transform>();

        }
        GameObject Unit = Instantiate(UnitPrefab, Pos[total.UnitNum].position, transform.rotation);
        Unit.name = $"Unit{total.UnitNum}";
        total.UnitNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void UnitInstantiate()
    {
        if(total.UnitNum < UnitNumMax && total.MyCoin >= total.UnitInsCost )
        {
            total.MyCoin -= total.UnitInsCost;
            GameObject Unit = Instantiate(UnitPrefab, Pos[total.UnitNum].position, transform.rotation);
            Unit.name = $"Unit{total.UnitNum}";
            total.UnitNum++;
        }
        
    }
    

    //에픽유닛 생성시켜야함
}
