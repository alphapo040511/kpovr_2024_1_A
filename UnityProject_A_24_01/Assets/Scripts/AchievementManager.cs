using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    public List<Achievement> achievements;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddProgress(string achievementName, int amount)     //���� ���� ��Ȳ�� �߰� �ϴ� �Լ�
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);        //�ش� �̸��� �ִ� ������ ����Ʈ���� ã�Ƽ� �����´�.
        if(achievement != null)
        {
            achievement.AddProgress(amount);                    //ã�� ������ Ƚ���� ī�����Ѵ�.
        }

    }
}