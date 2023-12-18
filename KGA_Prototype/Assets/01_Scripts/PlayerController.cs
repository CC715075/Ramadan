using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerAtk;
    public float playerHp;
    public float playerDef;
    public float playerSpeed;
    public float bulletSpeed;
    [SerializeField]
    bool isTouchedU, isTouchedD, isTouchedL, isTouchedR;

    public GameObject bulletPre;

    public float fireSpeed;
    float fireDelay;

    void Update()
    {
        PlayerMove();
        Fire();
    }

    void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchedR == true && h >= 1) || (isTouchedL == true && h <= -1))
        {
            h = 0;
        }
        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchedU == true && v >= 1) || (isTouchedD == true && v <= -1))
        {
            v = 0;
        }
        Vector2 curPos = gameObject.transform.position;
        Vector2 nextPos = new Vector2(h, v) * playerSpeed * Time.deltaTime;

        gameObject.transform.position = curPos + nextPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "WallU":
                    isTouchedU = true;
                    break;
                case "WallD":
                    isTouchedD = true;
                    break;
                case "WallL":
                    isTouchedL = true;
                    break;
                case "WallR":
                    isTouchedR = true;
                    break;
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "WallU":
                    isTouchedU = false;
                    break;
                case "WallD":
                    isTouchedD = false;
                    break;
                case "WallL":
                    isTouchedL = false;
                    break;
                case "WallR":
                    isTouchedR = false ;
                    break;
            }
        }
    }

    public void Fire()
    {
        fireDelay += Time.deltaTime;
        if (fireDelay >= fireSpeed)
        {
            GameObject bullet = Instantiate(bulletPre, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
            fireDelay = 0.0f;
        }
    }

}
