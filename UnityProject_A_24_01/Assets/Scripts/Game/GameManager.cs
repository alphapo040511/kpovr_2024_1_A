using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject[] circleObject;                     //물체 프리팹을 가져온다.
    public Transform genTransform;                      //생성 위치 설정
    public float timeCheck;                             //생성 시간 설정 변수 (float)
    public bool isGen;                                  //생성 체크 (bool)

    public int Point;                                   //점수
    public int BestScore;                               //최고 점수

    public static event Action<int> OnPointChanged;             //점수가 변경 되었을때 이벤트를 발생 시킨다.
    public static event Action<int> OnBestScoreChanged;         //최고 점수가 변경 되었을때 이벤트를 발생 시킨다.


    public void GenObject()
    {
        isGen = false;                                  //생성이 완료 되었으니 bool 을 false 변경
        timeCheck = 1.0f;                               //생성 완료 후 1.0초로 시간 초기화
    }
    // Start is called before the first frame update
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore");
        GenObject();
        OnPointChanged?.Invoke(Point);
        OnBestScoreChanged?.Invoke(BestScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen == false)                                          //isGen 플레그가 false 일 경우
        {
            timeCheck -= Time.deltaTime;                            //매 프레임 돌아가면서 시간을 감소 시킨다.
            if(timeCheck <= 0.0f)                                    //0초 이하가 되었을 경우
            {
                int RandNumber = UnityEngine.Random.Range(0, 3);                    //0~2의 랜덤 넘버 생성
                GameObject Temp = Instantiate(circleObject[RandNumber]);        //프리팹 생성후 Temp 오브젝트에 넣는다.
                Temp.transform.position = genTransform.position;    //고정위치에 생성 시킨다.
                isGen = true;
            }
        }
    }

    public void MergeObject(int index, Vector3 position)            //충돌한 물체의 index 번호와 위치를 가져온다
    {
        GameObject Temp = Instantiate(circleObject[index]);         //생성된 과일 오브젝트를 Temp에 넣는다.
        Temp.transform.position = position;                         //Temp 오브젝트의 위치는 함수로 받아온 위치값
        Temp.GetComponent<CircleObject>().Used();                     //생성되었을때 사용되었다고 표시 해줘야함

        Point += (int)Mathf.Pow(index, 2) * 10;                         //index의 2승으로 포인트 증가 POW 함수 활용
        OnPointChanged?.Invoke(Point);                                  //포인트가 변경되었을때 이벤트에 변경 되었다고 알림
    }

    public void EndGame()                                               //게임 종료가 되었을 때 함수
    {
        int BestScore = PlayerPrefs.GetInt("BestScore");                //기존에 저장된 점수를 불러온다.

        if(Point > BestScore)                                           //기존 포인트와 비교한다.
        {
            BestScore = Point;
            PlayerPrefs.SetInt("BestScore", Point);                     //포인트가 더 클 경우 저장한다.
            OnBestScoreChanged?.Invoke(BestScore);
        }

        //종료 시 해야 할일 나중에 추가
    }
}
