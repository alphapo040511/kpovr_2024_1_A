using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenColor : MonoBehaviour
{
    private Renderer renderer1;                              //랜더러를 선언한다.

    // Start is called before the first frame update
    void Start()
    {
        renderer1 = GetComponent<Renderer>();                //컴포넌트를 가져온다.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))                                             //스페이스를 눌렀을 때
        {
            Color color = new Color(Random.value, Random.value, Random.value);          //랜덤 색을 가져온다.

            renderer1.material.DOColor(color, 1f)                                        //랜덤색으로 1초후에 변경된다.
                .SetEase(Ease.InOutQuad);

            renderer1.material.DOPlay();                                                 //여러 트윈을 한꺼번에 실행 시킨다.
        }
    }
}
