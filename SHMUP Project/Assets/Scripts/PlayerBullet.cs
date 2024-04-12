using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletLife = 5f;

    [SerializeField]
    private float rotation = 0f;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private Vector3 spawnPoint;

    [SerializeField]
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
    }
}
