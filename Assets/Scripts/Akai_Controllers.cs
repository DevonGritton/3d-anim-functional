using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akai_Controllers : MonoBehaviour
{
    static Animator anim;
    public float speed = 10.0f;
    public float rotationspeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationspeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("IsJumping");
        }

        if (translation != 0)
        {
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);
        }
        else
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);
        }
    }
}
