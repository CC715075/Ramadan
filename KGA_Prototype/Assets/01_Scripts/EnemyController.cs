using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemyAtk;
    public float enemyHp;
    public float enemyDef;
    public float enenmySpeed;

    PlayerController playerController;
    Rigidbody2D rigid;
    SpriteRenderer spr;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.left * enenmySpeed;
        spr = GetComponent<SpriteRenderer>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnDamage(float damage)
    {
        enemyHp -= damage;
        spr.color = Color.gray;
        Invoke("ReturnSprite", 0.1f);
        if (enemyHp <= 0)
        {
            DataManager.Instance.killCount += 1;
            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        spr.color = Color.black;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "PlayerBullet")
        {
            OnDamage(playerController.playerAtk);
        }
    }
}
