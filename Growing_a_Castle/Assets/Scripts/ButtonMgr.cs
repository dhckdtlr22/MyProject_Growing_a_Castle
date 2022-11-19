using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMgr : MonoBehaviour
{
    public EnemyMaker enemyMaker;
    public GameObject ClosePop;
    public GameObject Cancel;
    public TotalState total;
    public void Start()
    {
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
    }
    public void BattleBut()
    {
        Cancel.SetActive(true);
        StartCoroutine(CancelClose());
        enemyMaker.IsBattle = true;
        enemyMaker.MonsterCount = 0;
    }
    public void ClosePopUp()
    {
        ClosePop.SetActive(false);
        total.CastleHp = int.Parse(total.data[total.CastleUpgradeLv]["CastleHp"].ToString());
    }
    IEnumerator CancelClose()
    {
        yield return new WaitForSeconds(1f);
        Cancel.SetActive(false);
    }
}
