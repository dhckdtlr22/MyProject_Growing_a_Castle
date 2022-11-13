using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMgr : MonoBehaviour
{
    public EnemyMaker enemyMaker;
    public GameObject ClosePop;
    public GameObject Cancel;
    public void Start()
    {
        
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
    }
    IEnumerator CancelClose()
    {
        yield return new WaitForSeconds(1f);
        Cancel.SetActive(false);
    }
}
