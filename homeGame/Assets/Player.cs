using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    RaycastHit hit;
    public GameObject hand;
    public GameObject Skill01;
    public GameObject Skill02;
    public GameObject IMG;
    public Image CoolImg;
    public Image CoolImg_1;

    public bool IsChoice;

    public float SCur_01;
    public float SCool_01;

    public float SCur_02;
    public float SCool_02;

    public int cho;
    // Start is called before the first frame update
    void Start()
    {
        TotalScript.Ins.hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsChoice == false)
        {
            SCur_01 += Time.deltaTime;
            SCur_02 += Time.deltaTime;
            CoolImg.fillAmount = SCur_01 / SCool_01;
            CoolImg_1.fillAmount = SCur_02 / SCool_02;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name != "DontIns")
                    {
                        GameObject Hand = Instantiate(hand, hit.point, hand.transform.rotation);
                        Destroy(Hand, 0.1f);
                    }

                }

            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && SCur_01 > SCool_01)
        {
            cho = 1;
            IMG.SetActive(true);
            Time.timeScale = 0;
            IsChoice = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && SCur_02 > SCool_02)
        {
            cho = 2;
            IMG.SetActive(true);
            Time.timeScale = 0;
            IsChoice = true;
        }
        if (IsChoice == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.CompareTag("Ground"))
                {
                    switch (cho)
                    {
                        case 1:
                            Skill_01();
                            break;
                        case 2:
                            Skill_02();
                            break;
                    }
                   
                }
            }
        }
        
    }
    void Skill_01()
    {
        Time.timeScale = 1;
        IsChoice = false;
        SCur_01 = 0;
        IMG.SetActive(false);
        GameObject Skill = Instantiate(Skill01, hit.point, Skill01.transform.rotation);
        Skill.name = "flooring";
    }
    void Skill_02()
    {
        Time.timeScale = 1;
        IsChoice = false;
        SCur_02 = 0;
        IMG.SetActive(false);
        GameObject Skill = Instantiate(Skill02, hit.point, Skill02.transform.rotation);
        Skill.name = "Potop";
    }

}
