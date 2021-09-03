using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public ControlMain player;
    GameObject self;
    public int speed_H;
    public int point;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed_H = -speed_H;
        self = this.gameObject;
        rb = self.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        int rang = Random.Range(-3, 50);
        if (rang < 0) {
            changeMouvement();
        }
        move();
    }

    void changeMouvement() {
        speed_H = -speed_H;
        self.transform.localScale = new Vector3(-self.transform.localScale.x, self.transform.localScale.y, self.transform.localScale.z);
    }

    void move() {
        rb.velocity = new Vector2(speed_H, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        if (other.gameObject.CompareTag("attack"))
        {
            player.addScore(point);
            Destroy(self);
            //anim.SetBool("Jumping", false);
        }
    }
}
