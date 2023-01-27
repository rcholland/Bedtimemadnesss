using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float speed;
    [SerializeField] private GameObject shootingPoint;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

       


        if (Input.GetButtonDown("Fire1"))
        { Attack();
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
}//left right moving

