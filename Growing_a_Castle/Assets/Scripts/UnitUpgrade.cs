using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUpgrade : MonoBehaviour
{
    public TotalState total;
    public int MaxUp = 50; 
    public int EpicMaxUp = 20;
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Upgrade()
    {
        if(total.MyCoin >= total.UnitUpgradeCost && total.UnitUpgradeLv < MaxUp)
        {
            total.MyCoin -= total.UnitUpgradeCost;
            total.UnitUpgradeLv++;
        }
    }
    public void EpicUpgrade()
    {
        if (total.MyCoin >= total.EpicUnitUpgardeCost && total.EpicUnitUpgradeLv < EpicMaxUp)
        {
            total.MyCoin -= total.EpicUnitUpgardeCost;
            total.EpicUnitUpgradeLv++;
        }
    }
    public void CastleUpgrade()
    {
        if (total.MyCoin >= total.CastleUpgradeCost && total.CastleUpgradeLv < MaxUp)
        {
            total.MyCoin -= total.CastleUpgradeCost;
            total.CastleUpgradeLv++;
            total.CastleHp = int.Parse(total.data[total.CastleUpgradeLv]["CastleHp"].ToString());
            total.CastleHpMax = total.CastleHp;
        }
    }
}
