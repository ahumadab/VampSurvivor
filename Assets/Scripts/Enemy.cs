using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [HideInInspector] public Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rigidBody2D;

    [SerializeField] int hp = 999;
    [SerializeField] int damage = 1;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigidBody2D.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        
        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
