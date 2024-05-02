using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenColor : MonoBehaviour
{
    private Renderer renderer1;                              //�������� �����Ѵ�.

    // Start is called before the first frame update
    void Start()
    {
        renderer1 = GetComponent<Renderer>();                //������Ʈ�� �����´�.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))                                             //�����̽��� ������ ��
        {
            Color color = new Color(Random.value, Random.value, Random.value);          //���� ���� �����´�.

            renderer1.material.DOColor(color, 1f)                                        //���������� 1���Ŀ� ����ȴ�.
                .SetEase(Ease.InOutQuad);

            renderer1.material.DOPlay();                                                 //���� Ʈ���� �Ѳ����� ���� ��Ų��.
        }
    }
}
