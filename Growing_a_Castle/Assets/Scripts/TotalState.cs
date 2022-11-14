using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalState : MonoBehaviour
{
    public int MyCoin;

    public int CastleHp;
    public int UnitUpgrade;
    public int CastleUpgrade;
    public int UnitNum;

    public int CastleCost;
    public int UnitCost;
    public int UnitInsCost;
    public int EpicUnitInsCost;
    public int Stage;

    public Text MyCoinText;
    public Text CastleCostText;
    public Text UnitCostText;
    public Text UnitInsCostText;
    public Text EpicUnitInsCostText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyCoinText.text = $"{MyCoin}";
        CastleCostText.text = $"비용:{CastleCost}";
        UnitCostText.text = $"비용:{UnitCost}";
        UnitInsCostText.text = $"비용:{UnitInsCost}";
        EpicUnitInsCostText.text = $"비용:{EpicUnitInsCost}";
    }
}
