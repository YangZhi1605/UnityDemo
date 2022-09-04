using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //游戏对象Ruby 和机器人碰撞之后的掉血
    public int damage = -1;
    //控制某个方向行走的总时间
    public float changeTime = 3.0f;
    //控制行走方向的正反：1表示沿着正方向行走，-1表示沿着负方向行走
    private int _direction = 1;
    //剩余时间计时器
    private float _timer;
    //控制机器人是按照垂直方向走，还是水平方向走
    public bool vertical;
    //存储挂接Rigidbody组件的游戏对象
    Rigidbody2D _rigidbody2dEnemy;
    //机器人的移动速度,公开到Unity
    public float speed = 5.0f;


    // 在第一次帧更新之前调用 Start
    void Start()
    {
        //获取机器人这个游戏对象
        _rigidbody2dEnemy = GetComponent<Rigidbody2D>();
        //设置计时器的剩余时间
        _timer = changeTime;
    }

    private void Update()
    {
        //和设置无敌时间的逻辑相似
        _timer -= Time.deltaTime;
        if (_timer < 0) //当计时器时间使用完了
        {
            //开始反向
            _direction = -_direction;
            //重置计时器时间
            _timer = changeTime;
        }
    }

    //使用FixedUpdate，每0.02秒执行一次
    void FixedUpdate()
    {
        
        Vector2 position = _rigidbody2dEnemy.position;
        if (vertical)//纵向
        {
            position.y += speed * Time.deltaTime*_direction;
        }
        else//横向
        {
            position.x += speed * Time.deltaTime*_direction;

        }
        
        //两种写法实现效果一样
        //_rigidbody2dEnemy.position = position;
        _rigidbody2dEnemy.MovePosition(position);
    }

    //注意不是触发器事件，而是刚体碰撞事件
    //在这个方法中，添加玩家掉血的逻辑
    private void OnCollisionEnter2D(Collision2D other)
    {
        //获取玩家角色对象(即，和挂接此方法的机器人发生碰撞的游戏对象)
        RubyController ruby = other.gameObject.GetComponent<RubyController>();

        if(ruby != null)
        {
            ruby.ChangeHealth(damage);
        }
    }
}
