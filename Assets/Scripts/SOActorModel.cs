using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Create Actor", menuName = "Create Actor")]
public class SOActorModel : ScriptableObject
{

    public string actorName;
    public enum ActorType
    {
        Player,
        SmallTeddyBear,
        BigTeddyBear,
        BossTeddyBear,
        Bullet,
    }
public ActorType actorType;

public int health;
public float speed;
public int hitPower;
public int score;


public GameObject actor;
public GameObject actorBullet;

}
