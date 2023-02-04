using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IActorTemplate

{
    float speed;
    int health;
    int hitPower;
    GameObject actor;
    GameObject bullet;

    [SerializeField] private GameObject shootingPoint;
  

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.gamestate == GameManager.Gamestates.Play)
        {
            Move();




            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }
        }
    }
    void Move()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(horizontal * speed * Vector3.right * Time.deltaTime);

        transform.Translate(vertical * speed * Vector3.forward * Time.deltaTime);
    }

    void Attack()
    {
        Instantiate(bullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
    }
public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;

        actor = actorModel.actor;
        bullet = actorModel.actorBullet;


    }
public int SendDamage()
    {
        return hitPower;
    }
public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }
public void Die()
    {
        Destroy(gameObject);
    }
}//left right moving

