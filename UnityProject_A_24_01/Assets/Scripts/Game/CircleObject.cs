using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;                             //���콺 Drag �Ǵ�
    public bool isUsed;                             //��� �Ϸ� üũ
    Rigidbody2D rigidbody2d;                        //2D ��ü ���� 

    public int Index;                               //���� ��ȣ ����

    public float EndTime = 0.0f;                    //���� �� �ð� üũ ���� (float)
    public SpriteRenderer spriteRenderer;           //����� ��������Ʈ ���� ��ȯ ��Ű�� ���ؼ� ���� ����

    public GameManager gameManager;                 //���� �Ŵ��� ������

    private void Awake()
    {
        isUsed = false;                                         //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2d = GetComponent<Rigidbody2D>();              //������Ʈ�� ��ü�� ����
        rigidbody2d.simulated = false;                          //���� �ൿ�� ó������ ���������ʰ� ����

        spriteRenderer = GetComponent<SpriteRenderer>();        //������Ʈ�� �پ��ִ� ������Ʈ�� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)                                             //����� �Ϸ�� ������Ʈ�� ������Ʈ ���� �׳� ���� ������. (���콺 Input ������ ���� ����)
            return;

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);         //ȭ�� ��ũ������ ����Ƽ Scene ������ ��ǥ�� �����´�.

            float leftBorder = -5.0f + transform.localScale.x / 2f;                         //������ ��ŭ�̵� ����
            float rightBorder = 5.0f + transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;                           //���콺 ��ġ�� �̵� ���� �Ѱ� �̻�, ���Ϸ� ���� ���� �����ؼ� ���д�.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;                                     //������Ʈ Y�� �� ����
            mousePos.z = 0;                                     //������Ʈ Z�� �� ����
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);          //�� ������Ʈ�� ���콺 ��ġ�� ���Ͼ��ϰ� 0.2 ����ŭ�� �̵����� ���󰣴�.
        }

        if (Input.GetMouseButtonDown(0)) Drag();                //���콺 ��ư�� �������� Drag �Լ� ����
        if (Input.GetMouseButtonUp(0)) Drop();                  //���콺 ��ư�� �ö󰥶� Drop �Լ� ����
    }

    void Drag()                                                 //�巡�� �� �� ���� �� �Լ�
    {
        isDrag = true;                                          //�巡�� ���̴�. (true)
        rigidbody2d.simulated = false;                          //���� �ùķ��̼� ���� (false)
    }

    void Drop()                                                 //��� �� �� ���� �� �Լ�
    {
        isDrag = false;                                         //�巡�� ���̴�. (false)
        isUsed = true;                                          //����� �Ϸ� �Ǿ���. (true)
        rigidbody2d.simulated = true;                           //���� �ùķ��̼� ����� (true)

        gameManager.GenObject();
    }

    public void Used()
    {
        isDrag = false;                     //�巡�� ���̴�. (false)
        isUsed = true;                      //����� �Ϸ� �Ǿ���. (true)
        rigidbody2d.simulated = true;       //���� �ùķ��̼� ����� (true)


    }

    public void OnTriggerStay2D(Collider2D other)               //Trigger�� ������ 
    {
        if(other.tag == "EndLine")                              //�浹���� ��ü�� Tag �� EndLine �� ���
        {
            EndTime += Time.deltaTime;                          //������ �ð���ŭ ���� ���Ѽ� �ʸ� ī��Ʈ �Ѵ�.

            if(EndTime > 1)                                     //1�� �̻� �� ���
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f); //������ ó��
            }

            if(EndTime > 3)                                     //3�� �̻� �� ���
            {
                //Debug.Log("���� ����");                         //�켱 ���� ����
                gameManager.EndGame();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)           //Trigger���� ���� ��
    {
        EndTime = 0;                                            //�浹���� ��ü�� Tag�� EndLine �� ��줤
        spriteRenderer.color = Color.white;                     //�⺻ �������� ����
    }

    public void OnCollisionEnter2D(Collision2D collision)                       //�ش� ������Ʈ�� �浹 ���� �� OnCollisionEnter2D
    {
        if(collision.gameObject.tag == "Fruit")                                 //�浹�� ���� ������ ���
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();     //�浹�� ��ü���� ���� Class�� �޾ƿ´�.

            if (temp.Index == Index && Index < 8)                                                    //�浹 Index�� �� Index�� ����.
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())   //2�� ���ļ� 1���� ����� ���ؼ� ID �˻� �� ū�͸�
                {
                    gameManager.MergeObject(Index, gameObject.transform.position);

                    Destroy(temp.gameObject);                                           //�浹�� ��ü ����
                    Destroy(gameObject);                                                //�ڽŵ� ����

                }
            }
        }

    }
}
