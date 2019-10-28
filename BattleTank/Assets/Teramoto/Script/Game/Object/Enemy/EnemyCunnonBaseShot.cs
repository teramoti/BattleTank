using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCunnonBaseShot : MonoBehaviour
{
    public GameObject enemyShellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    private int shotIntarval;

    [SerializeField]
    private int shotTime=60;

    private AudioSource audioSource;

    [SerializeField]
    private float destroyTime=3.0f;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }


        shotIntarval += 1;

        if (shotIntarval % 60 == 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, destroyTime);
        }
    }
}