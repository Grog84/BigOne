using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ale_BossIA: MonoBehaviour {

    public Transform player;
    static Animator anim;
    [SerializeField]
    private int aggroRange = 10;
    public Slider healthBar;
   

   
    

	void Start ()
    {
        
        anim = GetComponent<Animator>();
	}

   
    void Update ()
    {
        
        healthBar.gameObject.SetActive(false);
        if (healthBar.value <=0)
        {
            return;
        }
        //Vector3 direction = player.position - this.transform.position;
       // float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < aggroRange /*&& angle <30*/)
        {
            healthBar.gameObject.SetActive(true);
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f );


            anim.SetBool("isIdle", false);
            if(direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else 
            {
               
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                
                
               
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
	}
}
