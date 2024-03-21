using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExCubePlayer : MonoBehaviour
{
    public Text TextUI = null;          //�ؽ�Ʈ UI
    public int Count = 0;               //���콺 Ŭ�� ī����
    public int Power = 100;             //���� �� ��ġ
    public Rigidbody m_Rigidbody;       //������Ʈ�� ��ü
    
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))     //�����̽��� ������
        {
            Count += 1;                                             //���콺�� Ŭ�� �Ǿ����� Count�� 1�� �ø���.
            TextUI.text = Count.ToString();                         //UI ����
            m_Rigidbody.AddForce(transform.up * Power);             //y������ ������ ���� �ش�.
            Power = Random.RandomRange(100, 200);                   // 100 ~ 200 ������ ���� ���� �ش�
        }

         if(gameObject.transform.position.y >= 2 || gameObject.transform.position.y <= -2)
        {                                   //������Ʈ�� t���� -2�����̰ų� 2�̻��� ��� ���ǹ�
            TextUI.text = "����";
            Count = 0;                      //���н� ī���� �ʱ�ȭ
        }
    }
}
