using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMain : MonoBehaviour
{
    public GameObject player;
    public GameObject faceNeutral;
    public GameObject faceZappy;
    public GameObject zap;
    public GameObject endGameScreen;
    public Text scoreText;
    public Text lighthingCounter;

    public int speed_H;
    public int speed_V;
    public int rotation_speed;
    float movement_H;
    float movement_V;
    bool rotation_R;
    bool rotation_L;
    bool zapMode;
    int zapTimer;
    int zapNum;
    int score;
    bool endGameFlag;



    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        zapNum = 10;
        endGameFlag = false;
        zapMode = false;
        score = 0;
        rb = player.GetComponent<Rigidbody2D>();
        switchZapFace();
        lighthingCounter.text = "" +zapNum;

    }

    // Update is called once per frame
    void Update()
    {
        movement_H = Input.GetAxisRaw("Horizontal");
        movement_V = Input.GetAxisRaw("Vertical");
        if (movement_H > 0)
        {
            rb.velocity = new Vector2(speed_H, rb.velocity.y);
        }
        else if (movement_H < 0)
        {
            rb.velocity = new Vector2(-speed_H, rb.velocity.y);
        }
        if (movement_V > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed_V);

        }
        else if (movement_V < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed_V);
        }

        if (zapTimer == 0 && zapNum >0 && Input.GetKeyDown(KeyCode.Space))
        {
            switchZapFace();
            zapTimer = 10;
            zapNum--;
            lighthingCounter.text = "" + zapNum;
        }

    }

    private void FixedUpdate()
    {
        rotation_L = Input.GetKey(KeyCode.Z);
        rotation_R = Input.GetKey(KeyCode.X);
       
        if (rotation_L)
        {
            rb.AddTorque(rotation_speed * 5, ForceMode2D.Force);
        }
        if (rotation_R)
        {
            rb.AddTorque(-(rotation_speed * 5), ForceMode2D.Force);
        }
        if (zapTimer > 0) {
            print(zapTimer);
            zapTimer--;
            if (zapTimer == 0) {
                switchZapFace();
                
            }
        }
        if (zapNum <= 0 && zapTimer == 0 && !endGameFlag)
        {
            endGameFlag = true;
            endGame();
        }
    }
    private void switchZapFace() {
        zapMode = !zapMode;
        faceNeutral.gameObject.SetActive(zapMode);
        faceZappy.gameObject.SetActive(!zapMode);
        zap.gameObject.SetActive(!zapMode);
    }
    private void endGame() {
        scoreText.text = ""+score + " Points";
        endGameScreen.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public void addScore(int point)
    {
        score = score + point;
    }
}

