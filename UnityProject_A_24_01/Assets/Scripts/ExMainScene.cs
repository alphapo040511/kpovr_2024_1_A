using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExMainScene : MonoBehaviour
{
    public void GoToShootGame()                                  //��ư�� ȣ�� �� �Լ��� ����
    {
        SceneManager.LoadScene("GameScene_Gun");                  //Scene �̵�
    }
    public void GoToJumpGame()                                  //��ư�� ȣ�� �� �Լ��� ����
    {
        SceneManager.LoadScene("GameScene_Jump");                  //Scene �̵�
    }
    public void GoExit()                                        //��ư�� ȣ�� �� �Լ��� ����
    {
        Application.Quit();                                         //���� ����
    }
}
