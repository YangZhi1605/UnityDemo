using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //.删除 Start 和 Update 函数，因为你不想在游戏开始时或在每一帧处理任何事务。

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"此时与加血草莓触发器发生碰撞的对象是{other}");

        //访问 RubyController 组件
        RubyController controller = other.GetComponent<RubyController>();

        if(controller != null)
        {
            //在当前的血量小于最大血量的情况，才会触发加血和销毁草莓游戏对象
            if(controller.Health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
            
        }
    }
}
