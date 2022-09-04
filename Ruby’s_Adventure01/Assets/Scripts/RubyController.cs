using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{

    //设置处于无敌的时间
    public float timeInvincible = 2.0f;
    //判断是否进入无敌状态
    bool isInvincible;
    //计时器，计算无敌时间剩余多少
    float invincibleTimer;

    //设置Ruby 的最大血量，公开暴露到Unity
    public int maxHealth = 5;
    //角色的当前血量
    private int _currentHealth;

    //对经过private封装的_current字段添加属性
    public int Health { get; set; }


    //游戏角色的移动速度，开放为public，可以在Unity编辑器中进行设置
    public float speed =4.0f;
    //声明一个2D的刚体变量，用于存放游戏角色对象
    Rigidbody2D _rigidbody2d;
    //水平输入
    float _inputX;
    //垂直输入
    float _inputY;

    // Start is called before the first frame update
    void Start()
    {
        //返回Rigidbody2D类型的组件
        //务必已经在Ruby游戏对象上挂接Rigidbody2D组件
        _rigidbody2d = GetComponent<Rigidbody2D>();

        //在每次游戏开始的时候，将最大生命值赋值给初始声明值
        _currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * GetAxisRaw不使用平滑滤波器
         * 就是说GetAxis可以返回-1到1之间的数，比如检测到按键按下的时候，由0不断增加过渡到1
         * GetAxisRaw只能返回-1,0,1三个值！
         */
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputY = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(_inputX, _inputY).normalized;
        _rigidbody2d.velocity = input * speed;

        //在Update中处理无敌时间的剩余计算
        if (isInvincible)
        {
            //逐帧扣除无敌时间计时器
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0)
            {
                //重置为不处于无敌状态
                isInvincible = false;
            }
        }
        
    }

    //自定义修改游戏角色生命值的代码
    public void ChangeHealth(int amount)
    {
        //处于扣血的情况
        if(amount < 0)
        {
            //已经处于无敌状态，直接跳出此处扣血逻辑
            if (isInvincible) return;
            else
            {
                //将判断是否处于无敌的变量赋值，让其表示：处于无敌状态
                isInvincible = true;
                //给控制无敌的时器赋值
                invincibleTimer = timeInvincible;

            }
        }

        // Mathf.Clamp 的内置函数来设置当前生命值
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
        //通过Debug.Log在控制台打印出输出信息
        Debug.Log($"当前的血量是{_currentHealth}/最大血量是{maxHealth}");
    }
}
