using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float JumpForce;
    [SerializeField] float moveVelocity;
    [SerializeField] AudioClip[] audioClip;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, this.GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<AudioSource>().clip = audioClip[0];
            GetComponent<AudioSource>().Play();

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            GameObject.Destroy(this.gameObject);

        }
    }
}
