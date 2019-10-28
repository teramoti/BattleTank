using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject shellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    public int shotCount;

    [SerializeField]
    private float timeBetweenShot = 0.5f;
    private float timer;
    [SerializeField]
    private float deleteBullet = 5.0f;
    void Start()
    {
       // shellLabel.text = "×" + shotCount;
    }

    void Update()
    {
        timer += Time.deltaTime;
        /*射撃ボタン1が押されたとき*/
        bool fire = Input.GetButtonDown("Fire2");
        if (fire==true && timer > timeBetweenShot)
        {
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
            timer = 0.0f;
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * shotSpeed);
            shell.transform.rotation = this.transform.rotation;
            Destroy(shell, deleteBullet);
        }
    }
}