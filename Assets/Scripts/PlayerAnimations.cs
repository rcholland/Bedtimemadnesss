using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    [SerializeField] Animator animator;
    float horizontal;
    float vertical;

    bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        UpdateAnimations(0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {   if (GameManager.Instance.gamestate == GameManager.Gamestates.Play)
     {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        UpdateAnimations(horizontal, vertical);
        if (Input.GetButtonDown("Fire1"))shoot();
        else if (Input.GetButtonUp("Fire1"))shoot();

      }
}

    public void UpdateAnimations(float h, float v)
    {
        animator.SetFloat("horizontal",h);
        animator.SetFloat("vertical", v);
    }

void shoot()
    {
        shooting = !shooting;
        animator.SetBool("shooting", shooting);

    }
}
