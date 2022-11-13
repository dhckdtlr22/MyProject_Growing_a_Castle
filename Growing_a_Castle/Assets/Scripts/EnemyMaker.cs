using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMaker : MonoBehaviour
{
    public GameObject BattalPop;
    public GameObject EnemyPrefab;
    public Text EnemyCountText;
    public Text KillText;
    public Slider KillSlider;

    public float curtime;
    public float cooltime;
    public bool IsBattle;
    public int MonsterCount;
    public int CountMax;
    public int KillCount;

    public TotalState totalState;

    // Start is called before the first frame update
    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(IsBattle ==true)
        {
            
            curtime += Time.deltaTime;

            if (curtime > cooltime && MonsterCount < CountMax)
            {
                int rand = Random.Range(-15, 14);
                GameObject Enemy = Instantiate(EnemyPrefab);
                Enemy.name = "Enemy";
                Enemy.transform.position = new Vector3(transform.position.x + rand, transform.position.y, transform.position.z);
                curtime = 0;
                MonsterCount++;
            }
            EnemyCountText.text = $"{KillCount}/{CountMax}";
            KillSlider.value = (float)KillCount / CountMax;
        }
        else if(IsBattle == false)
        {
            EnemyCountText.text = $"Stage {totalState.Stage}";
            KillSlider.value = 0;
        }
        
        if (KillCount == CountMax)
        {
            IsBattle = false;
            curtime = 0;
            KillText.text = $"처치 :{KillCount}마리";
            KillCount = 0;
            MonsterCount = 0;
            BattalPop.SetActive(true);
        }
        
    }
}
