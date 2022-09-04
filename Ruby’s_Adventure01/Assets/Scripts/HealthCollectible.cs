using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //.ɾ�� Start �� Update ��������Ϊ�㲻������Ϸ��ʼʱ����ÿһ֡�����κ�����

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"��ʱ���Ѫ��ݮ������������ײ�Ķ�����{other}");

        //���� RubyController ���
        RubyController controller = other.GetComponent<RubyController>();

        if(controller != null)
        {
            //�ڵ�ǰ��Ѫ��С�����Ѫ����������Żᴥ����Ѫ�����ٲ�ݮ��Ϸ����
            if(controller.Health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
            
        }
    }
}
