using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NikIAScript : MonoBehaviour
{
    public Transform player;
    static Animator anim;
	private Animator playerMovement;
    public float timerA = 0;
    public float timerB = 0;
    public float timerC = 0;
    public float cooldownA;
    public float cooldownB;
    public float cooldownC;

    

    [SerializeField] private int aggroRange = 30;
    [SerializeField] private int angleOfView = 30;
    


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
		playerMovement =  player.GetComponent<Animator>();
        //timerA = cooldownA;
        //timerB = cooldownB;
        //timerC = cooldownC;


    }

    // Update is called once per frame
    void Update()
    {
        timerA = timerA - Time.deltaTime;
        timerB = timerB - Time.deltaTime;
        timerC = timerC - Time.deltaTime;

        if (timerA > 0f)
            anim.SetBool("isAttackA", false);
        
        
		if(timerB > 0f)
			anim.SetBool("isAttackB", false);

       if (timerC > 0f)
			anim.SetBool("isAttackC", false);
        
		Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        bool isMakingNoise = playerMovement.GetBool("Crouch");


		if (anim.GetBool ("isDead")) 
		{
			return;
		}

        if ((Vector3.Distance(player.position, this.transform.position) < aggroRange /*&& angle < angleOfView )*/|| 
			(Vector3.Distance(player.position, this.transform.position) < aggroRange /*&& angle > angleOfView
			&& (playerMovement.GetFloat("Forward") >= 0.75f)*/)))
        {
      
        
            if (!anim.GetBool("RoarOnce"))
            {
                anim.SetBool("isRoar", true);
            }

            if (!anim.GetBool("isRoar"))
            {

                direction.y = 0;
                if (!anim.GetBool("isAttackA") || !anim.GetBool("isAttackB") || !anim.GetBool("isAttackC"))
                {
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                }
                anim.SetBool("isIdle", false);
                if (direction.magnitude > 3 && !anim.GetCurrentAnimatorStateInfo(0).IsName("creature1roar"))
                {
                    this.transform.Translate(0, 0, 0.05f);
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isAttackA", false);
                    anim.SetBool("isAttackB", false);
                    anim.SetBool("isAttackC", false);
                }
                else
                {
                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWalking", false);
                    if (anim.GetBool("isAttacking") && timerA <= 0f)
                    {
                        anim.SetBool("isAttackA", true);
                        anim.SetBool("isAttackB", false);
                        anim.SetBool("isAttackC", false);
                        timerA = cooldownA;
                    }
                    else if (anim.GetBool("isAttacking") && timerB <= 0f)
                    {
                        anim.SetBool("isAttackA", false);
                        anim.SetBool("isAttackB", true);
                        anim.SetBool("isAttackC", false);
                        timerB = cooldownB;
                    }
                    else if (anim.GetBool("isAttacking") && timerC <= 0f)
                    {
                        anim.SetBool("isAttackA", false);
                        anim.SetBool("isAttackB", false);
                        anim.SetBool("isAttackC", true);
                        timerC = cooldownC;
                    }
                }
            }

        
        }
    
       /* else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }*/

	 }

    private void onRoar(int roarEnd)
    {
        if (roarEnd == 1)
        {
            anim.SetBool("isRoar",false);
            anim.SetBool("RoarOnce", true);
        }
    }

}