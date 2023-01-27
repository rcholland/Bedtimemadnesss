using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IActorTemplate
{
    float speed;

    int health;
    int hitPower;
    GameObject actor;
    string colourName;
    [SerializeField] SOActorModel ActorModel;


    // Start is called before the first frame update
    void Awake()
    {
        ActorStats(ActorModel);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);


    }
    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        actor = actorModel.actor;
        colourName= actorModel.colourName;
    }

    public int SendDamage()
    {
        return hitPower;
    }
    public void TakeDamage(int incomingDamage)
    {
        health = incomingDamage;
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    void ChangeColour()
    {
        if (colourName == "red")

        { GetComponent<Renderer>().material.color = Color.red; }
    }
}