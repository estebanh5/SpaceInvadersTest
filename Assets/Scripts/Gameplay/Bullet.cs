using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{

    private string EnemyTag = "Enemy";

    [SerializeField]
    private float MoveForce = 20.0f;

    private float DestroyTime = 5.0f;

    private Rigidbody2D Rigidbody;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.drag = 10.0f;
    }


    void Start()
    {
        StartCoroutine(DestroyBullet());
    }


    void Update()
    {



        Rigidbody.AddForce(Vector2.up * MoveForce * Time.deltaTime * 100);


    }

    private IEnumerator DestroyBullet ()
    {

        yield return new WaitForSeconds(DestroyTime);

        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.tag == EnemyTag)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy?.Destroy();

            GameObject.Destroy(gameObject);
        }
    }

   
}
