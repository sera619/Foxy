using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    [SerializeField] public Transform spawnPositon;

    private Transform target;
    private bool isAttacking = false;


    public float AttackTime = 1f;
    private float timeRemaining;



    private void Start() {
        target = FindObjectOfType<CharPlayer>().transform; 
    }

    private void Update() {
        if(isAttacking){
            timeRemaining -= Time.deltaTime;
            if( timeRemaining <= 0){
                isAttacking = false;
            }
            return;

        }
        if(!isAttacking && Vector3.Distance(target.position, transform.position) == minRange){
             Attack();
            }
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange){
            FollowPlayer();
        }else{
            GoHome();
        }

        
        
    }


    public void Attack(){
        if(isAttacking){
            return;
        }
        if(animator.GetBool("Move")){
            animator.SetBool("Move", false);
        }
        animator.SetTrigger("Attack");
        timeRemaining = AttackTime;
        transform.position = transform.position;
        speed = 0;
        isAttacking = true;
        
    }

    public void GoHome(){
        animator.SetBool("Move", true);
        animator.SetFloat("Horizontal", (spawnPositon.position.x - transform.position.x));
        animator.SetFloat("Vertical", (spawnPositon.position.y  - transform.position.y));
        animator.SetFloat("LastHorizontal",(spawnPositon.position.x  -transform.position.x));
        animator.SetFloat("LastVertical", (spawnPositon.position.y - target.position.y));
        transform.position = Vector3.MoveTowards(transform.position, spawnPositon.position, speed * Time.deltaTime);
        if (transform.position == spawnPositon.transform.position){
            animator.SetBool("Move", false);
        }
    }

    public void FollowPlayer(){
        animator.SetBool("Move", true);
        animator.SetFloat("Horizontal", (target.position.x - transform.position.x));
        animator.SetFloat("Vertical", (target.position.y  - transform.position.y));
        animator.SetFloat("LastHorizontal",(spawnPositon.position.x  -transform.position.x));
        animator.SetFloat("LastVertical", (spawnPositon.position.y - target.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


}
