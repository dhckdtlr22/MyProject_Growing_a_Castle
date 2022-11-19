using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalState : MonoBehaviour
{
    //���� ������ ���ݰ���
    //�Ϲ�����
    public int MyCoin;
    public int UnitDamage;
    public float UnitSPD;

    //���� ����
    public int EpicUnitDamage;
    public float EpicUnitSPD;

    public List<Dictionary<string, object>> data;

    //���׷��̵� ����
    public int CastleHpMax;
    public int CastleHp;
    public int UnitUpgradeLv;
    public int CastleUpgradeLv;
    public int EpicUnitUpgradeLv;

    //���� ���� �� ����
    public int UnitNum;
    public int EpicMax = 3;
    public int EpicUnitNum = 0;

    //������ ����
    public int PlayerExp;
    public int PlayerExpMax;

    //���� ���׷��̵� ��� ����
    public int CastleUpgradeCost;
    public int UnitUpgradeCost;
    public int EpicUnitUpgardeCost;

    //��������
    public int UnitInsCost;
    public int EpicUnitInsCost;

    public int Stage;

    public Text MyCoinText;
    public Text CastleCostText;
    public Text UnitCostText;
    public Text UnitInsCostText;
    public Text EpicUnitInsCostText;
    public Text EpicUnitCostText;

    public Slider Hpbar;

    public EnemyState enemyState;
    public EnemyMaker enemyMaker;
    // Start is called before the first frame update
    void Start()
    {
        data = CSVReader.Read("Character");
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        CastleHp = int.Parse(data[CastleUpgradeLv]["CastleHp"].ToString());
        CastleHpMax = CastleHp;
    }

    // Update is called once per frame
    void Update()
    {
        UnitDamage = int.Parse(data[UnitUpgradeLv]["UnitATK"].ToString());
        UnitInsCost = int.Parse(data[UnitNum]["UnitInsCost"].ToString());
        UnitSPD = float.Parse(data[UnitUpgradeLv]["UnitSPD"].ToString());
        EpicUnitInsCost = int.Parse(data[EpicUnitNum]["EPICUnitInsCost"].ToString());
        UnitUpgradeCost = int.Parse(data[UnitUpgradeLv]["UnitCost"].ToString());
        EpicUnitUpgardeCost = int.Parse(data[EpicUnitUpgradeLv]["EPICUnitCost"].ToString());

        Hpbar.value = (float)CastleHp / CastleHpMax;

        if (MyCoin > 0 )
        {
            MyCoinText.text = $"{string.Format("{0:#,###}", MyCoin)}";
        }
        else
        {
            MyCoinText.text = $"0";
        }

        CastleCostText.text = $"���:{CastleUpgradeCost}";
        UnitCostText.text = $"���:{UnitUpgradeCost}";
        UnitInsCostText.text = $"���:{UnitInsCost}";
        EpicUnitInsCostText.text = $"���:{EpicUnitInsCost}";
        EpicUnitCostText.text = $"���:{EpicUnitUpgardeCost}";
    }
    public void StageUp()
    {
        Stage++;
        if (Stage % 5 == 0)
        {

            float a = enemyState.Damage * 1.5f;
            enemyState.Damage = (int)a;
            float b = enemyState.Hp * 1.2f;
            enemyState.Hp = (int)b;

            
           if(enemyMaker.cooltime >0.1)
           {
                enemyMaker.cooltime -= 0.05f;
           }
           if(enemyState.Speed < 3)
           {
                enemyState.Speed += 0.05f;
           }
        }
        if (enemyMaker.CountMax < 2000)
        {
            enemyMaker.CountMax += 1;
        }
    }
}
