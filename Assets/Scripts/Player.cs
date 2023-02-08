using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IActorTemplate

{
    float speed;
    int health;
    int hitPower;
    GameObject actor;
    GameObject bullet;
    Rigidbody rb;

    [SerializeField] float JumpForce = 1000.0f;
    [SerializeField] float drawDistance = 2;
    [SerializeField] private GameObject shootingPoint;
    [SerializeField] bool isJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.gameState == GameManager.GameStates.Play)
        {
            Move();




            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.Space) && isJump)
            {
                jump();
            }
        }
    }
    void fixedupdate()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);
        Debug.DrawRay(transform.position, down * drawDistance, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, down,out hit, 1000))

        {
            Debug.Log("we have hit:" + hit.collider.name);
            Debug.DrawRay(transform.position, down * hit.distance, Color.green);
            isJump = true;
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
        GameManager.playerHealth = actorModel.health;
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

    void jump()
    {
        Vector3 force = Vector3.up*JumpForce;
        rb.AddForce(force, ForceMode.Impulse);
        isJump = false;
    }

}//left right moving

