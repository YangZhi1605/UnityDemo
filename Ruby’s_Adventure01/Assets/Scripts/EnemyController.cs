using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //��Ϸ����Ruby �ͻ�������ײ֮��ĵ�Ѫ
    public int damage = -1;
    //����ĳ���������ߵ���ʱ��
    public float changeTime = 3.0f;
    //�������߷����������1��ʾ�������������ߣ�-1��ʾ���Ÿ���������
    private int _direction = 1;
    //ʣ��ʱ���ʱ��
    private float _timer;
    //���ƻ������ǰ��մ�ֱ�����ߣ�����ˮƽ������
    public bool vertical;
    //�洢�ҽ�Rigidbody�������Ϸ����
    Rigidbody2D _rigidbody2dEnemy;
    //�����˵��ƶ��ٶ�,������Unity
    public float speed = 5.0f;


    // �ڵ�һ��֡����֮ǰ���� Start
    void Start()
    {
        //��ȡ�����������Ϸ����
        _rigidbody2dEnemy = GetComponent<Rigidbody2D>();
        //���ü�ʱ����ʣ��ʱ��
        _timer = changeTime;
    }

    private void Update()
    {
        //�������޵�ʱ����߼�����
        _timer -= Time.deltaTime;
        if (_timer < 0) //����ʱ��ʱ��ʹ������
        {
            //��ʼ����
            _direction = -_direction;
            //���ü�ʱ��ʱ��
            _timer = changeTime;
        }
    }

    //ʹ��FixedUpdate��ÿ0.02��ִ��һ��
    void FixedUpdate()
    {
        
        Vector2 position = _rigidbody2dEnemy.position;
        if (vertical)//����
        {
            position.y += speed * Time.deltaTime*_direction;
        }
        else//����
        {
            position.x += speed * Time.deltaTime*_direction;

        }
        
        //����д��ʵ��Ч��һ��
        //_rigidbody2dEnemy.position = position;
        _rigidbody2dEnemy.MovePosition(position);
    }

    //ע�ⲻ�Ǵ������¼������Ǹ�����ײ�¼�
    //����������У������ҵ�Ѫ���߼�
    private void OnCollisionEnter2D(Collision2D other)
    {
        //��ȡ��ҽ�ɫ����(�����͹ҽӴ˷����Ļ����˷�����ײ����Ϸ����)
        RubyController ruby = other.gameObject.GetComponent<RubyController>();

        if(ruby != null)
        {
            ruby.ChangeHealth(damage);
        }
    }
}
