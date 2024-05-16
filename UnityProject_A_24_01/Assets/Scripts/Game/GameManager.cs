using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] circleObject;                     //��ü �������� �����´�.
    public Transform genTransform;                      //���� ��ġ ����
    public float timeCheck;                             //���� �ð� ���� ���� (float)
    public bool isGen;                                  //���� üũ (bool)


    public void GenObject()
    {
        isGen = false;                                  //������ �Ϸ� �Ǿ����� bool �� false ����
        timeCheck = 1.0f;                               //���� �Ϸ� �� 1.0�ʷ� �ð� �ʱ�ȭ
    }
    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen == false)                                          //isGen �÷��װ� false �� ���
        {
            timeCheck -= Time.deltaTime;                            //�� ������ ���ư��鼭 �ð��� ���� ��Ų��.
            if(timeCheck <= 0.0f)                                    //0�� ���ϰ� �Ǿ��� ���
            {
                int RandNumber = Random.Range(0, 3);                    //0~2�� ���� �ѹ� ����
                GameObject Temp = Instantiate(circleObject[RandNumber]);        //������ ������ Temp ������Ʈ�� �ִ´�.
                Temp.transform.position = genTransform.position;    //������ġ�� ���� ��Ų��.
                isGen = true;
            }
        }
    }

    public void MergeObject(int index, Vector3 position)            //�浹�� ��ü�� index ��ȣ�� ��ġ�� �����´�
    {
        GameObject Temp = Instantiate(circleObject[index]);         //������ ���� ������Ʈ�� Temp�� �ִ´�.
        Temp.transform.position = position;                         //Temp ������Ʈ�� ��ġ�� �Լ��� �޾ƿ� ��ġ��
        Temp.GetComponent<CircleObject>().Used();                     //�����Ǿ����� ���Ǿ��ٰ� ǥ�� �������
    }
}