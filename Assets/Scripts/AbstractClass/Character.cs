using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character: MonoBehaviour
{
    private int _health;
    private float _speed;
    private bool _isAlive;

    //public abstract void Move(float speed);
    public abstract void Attack();

    public virtual void takeDamage(int damage)
    {
        Health -= damage;
    }

    public virtual bool isDie()
    {
        if (Health <= 0)
        {
            IsAlive = false;
            //Destroy(gameObject);
        }
        return !IsAlive;
    }

    public int Health { get { return _health; } set { _health = value; } }
    public float Speed { get { return _speed; } set { _speed = value; } }
    public bool IsAlive { get { return _isAlive; } set { _isAlive = value; } }

}
