using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    //音を鳴らす
    private float soundNum;
    
    private float SOUNDNUM = 10;
    
    //移動音
    public AudioClip moveSound;

    private AudioSource  audioSource ;


    GameObject tank;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        audioSource = gameObject.GetComponent<AudioSource>();

        tank = GameObject.Find("Tank");

    }

    void Update()
    {
        Move();
        Turn();

        if (movementInputValue > 0f)
        {
            movementInputValue = 1f;
            soundNum++;
        }
        else if (movementInputValue < 0)
        {
            movementInputValue = -1f;
            soundNum++;
        }
        else
        {
            movementInputValue = 0f;
        }

        if (soundNum >= SOUNDNUM)
        {
            //音を鳴らす
            audioSource.PlayOneShot(moveSound);

            soundNum = 0;
        }

        rb.AddForce(Vector3.down * 100, ForceMode.Acceleration);

    }

    // 前進・後退のメソッド
    void Move()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // 旋回のメソッド
    void Turn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}