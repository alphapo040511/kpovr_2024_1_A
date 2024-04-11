using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ExRay : MonoBehaviour
{
public Text UIText;                         //�ؽ�Ʈ ����
public int Point;                           //����Ʈ ����
public float checkEndTime = 30.0f;  //���� ���� �ð� ���� (30��)

    void Update()
    {
        checkEndTime -= Time.deltaTime;             //�ʸ� ���������� ����.

        if (checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);         //������ ������ ���� ������ �����Ѵ�.
            SceneManager.LoadScene("ResultScene");      //��� â���� �̵��Ѵ�.
        }

            if (Input.GetMouseButtonDown(1))                     //GetMouseButtonDown(1) ������ ��ư ���콺�� ������ ��
            {
                Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);       //Ray�� �����ϰ� ī�޶��� ���콺 ��ġ���� Ray�� ���.

                RaycastHit hit;                                                 //Ray�� ��� �浹�� ��ü�� ���� Hit �ֱ� ���� ����

                if (Physics.Raycast(cast, out hit))                             //�浹�Ŀ� ���� Hit ���� ���
                {
                    Debug.Log(hit.collider.gameObject.name);                    //�浹�� ������Ʈ�� �̸��� �޾ƿ´�.
                    Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);    //RayCast ���� ����׷� �� �� �ְ� �Ѵ�.

                    if (hit.collider.gameObject.tag == "Target")                //�浹�� ������Ʈ�� TAG �̸��� Target�� ���
                    {
                        Destroy(hit.collider.gameObject);                       //�ش� ������Ʈ�� �ı��Ѵ�.
                        Point += 1;                                             //�ı��� ����Ʈ +1
                                                                                //if (Point >= 10) DoChangeScene();                       //����Ʈ�� 10���� �ѱ�� Scene�� ��ȯ�Ѵ�.
                    }
                }

                else
                {
                    Point = 0;                                                  //Miss �� ����Ʈ 0��
                }

                UIText.text = Point.ToString();                                 //UI�� ǥ��
            }
        }

        void DoChangeScene()                                                    //�� ��ȯ�� ���� �Լ� ����
        {
            SceneManager.LoadScene("ResultScene");                              //ResultScene ���� ��ȯ �ȴ�.
        }
}
