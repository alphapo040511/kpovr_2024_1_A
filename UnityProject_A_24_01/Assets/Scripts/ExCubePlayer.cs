using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExCubePlayer : MonoBehaviour
{
    public Text TextUI = null;          //텍스트 UI
    public int Count = 0;               //마우스 클릭 카운터
    public int Power = 100;             //물리 힘 수치
    public Rigidbody m_Rigidbody;       //오브젝트의 강체
    
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))     //스페이스를 누를때
        {
            Count += 1;                                             //마우스가 클릭 되었을때 Count를 1씩 올린다.
            TextUI.text = Count.ToString();                         //UI 갱신
            m_Rigidbody.AddForce(transform.up * Power);             //y축으로 설정한 힘을 준다.
            Power = Random.RandomRange(100, 200);                   // 100 ~ 200 사이의 값의 힘을 준다
        }

         if(gameObject.transform.position.y >= 2 || gameObject.transform.position.y <= -2)
        {                                   //오브젝트의 t값이 -2이하이거나 2이상일 경우 조건문
            TextUI.text = "실패";
            Count = 0;                      //실패시 카운터 초기화
        }
    }
}
