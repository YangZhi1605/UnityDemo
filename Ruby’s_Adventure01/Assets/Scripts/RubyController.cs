using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{

    //���ô����޵е�ʱ��
    public float timeInvincible = 2.0f;
    //�ж��Ƿ�����޵�״̬
    bool isInvincible;
    //��ʱ���������޵�ʱ��ʣ�����
    float invincibleTimer;

    //����Ruby �����Ѫ����������¶��Unity
    public int maxHealth = 5;
    //��ɫ�ĵ�ǰѪ��
    private int _currentHealth;

    //�Ծ���private��װ��_current�ֶ��������
    public int Health { get; set; }


    //��Ϸ��ɫ���ƶ��ٶȣ�����Ϊpublic��������Unity�༭���н�������
    public float speed =4.0f;
    //����һ��2D�ĸ�����������ڴ����Ϸ��ɫ����
    Rigidbody2D _rigidbody2d;
    //ˮƽ����
    float _inputX;
    //��ֱ����
    float _inputY;

    // Start is called before the first frame update
    void Start()
    {
        //����Rigidbody2D���͵����
        //����Ѿ���Ruby��Ϸ�����Ϲҽ�Rigidbody2D���
        _rigidbody2d = GetComponent<Rigidbody2D>();

        //��ÿ����Ϸ��ʼ��ʱ�򣬽��������ֵ��ֵ����ʼ����ֵ
        _currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * GetAxisRaw��ʹ��ƽ���˲���
         * ����˵GetAxis���Է���-1��1֮������������⵽�������µ�ʱ����0�������ӹ��ɵ�1
         * GetAxisRawֻ�ܷ���-1,0,1����ֵ��
         */
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputY = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(_inputX, _inputY).normalized;
        _rigidbody2d.velocity = input * speed;

        //��Update�д����޵�ʱ���ʣ�����
        if (isInvincible)
        {
            //��֡�۳��޵�ʱ���ʱ��
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0)
            {
                //����Ϊ�������޵�״̬
                isInvincible = false;
            }
        }
        
    }

    //�Զ����޸���Ϸ��ɫ����ֵ�Ĵ���
    public void ChangeHealth(int amount)
    {
        //���ڿ�Ѫ�����
        if(amount < 0)
        {
            //�Ѿ������޵�״̬��ֱ�������˴���Ѫ�߼�
            if (isInvincible) return;
            else
            {
                //���ж��Ƿ����޵еı�����ֵ�������ʾ�������޵�״̬
                isInvincible = true;
                //�������޵е�ʱ����ֵ
                invincibleTimer = timeInvincible;

            }
        }

        // Mathf.Clamp �����ú��������õ�ǰ����ֵ
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
        //ͨ��Debug.Log�ڿ���̨��ӡ�������Ϣ
        Debug.Log($"��ǰ��Ѫ����{_currentHealth}/���Ѫ����{maxHealth}");
    }
}
