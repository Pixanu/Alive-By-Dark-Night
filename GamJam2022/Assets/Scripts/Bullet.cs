using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float distanceTravelled;

    void Start()
    {
        damage = GameObject.FindObjectOfType<GunSystem>().damage;
        startPosition = GameObject.FindObjectOfType<GunSystem>().attackPoint.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.name);

        if (collision.transform.GetComponent<Monster>())
        {
            //if(collision.gameObject.GetComponent<Rigidbody>() != null)
            //{
                Debug.Log("hit monster");

                collision.gameObject.GetComponent<CharacterController>().Move(this.GetComponent<Rigidbody>().velocity.normalized * GameObject.FindObjectOfType<GunSystem>().knockbackForce);
            //}

            targetPosition = collision.transform.position;
            DamageDecreased(targetPosition);

            damage -= ((int)distanceTravelled*(int)10/100);
            collision.collider.GetComponent<Monster>().TakeDamage(damage);
        }

        if (collision.transform.name != "Gun Skin")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        Invoke("DestroyBullet", 2.0f);
    }

    private void DamageDecreased(Vector3 targetPos)
    {
        distanceTravelled = Vector3.Distance(startPosition, targetPosition);
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}