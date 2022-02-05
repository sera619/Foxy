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


    private void Start() {
        target = FindObjectOfType<CharPlayer>().transform; 
    }

    private void Update() {
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange){
            FollowPlayer();
        }
        
    }



    public void GoHome(){
        if (transform.position == spawnPositon.transform.position){
            animator.SetBool("Move", false);
        }
        animator.SetBool("Move", true);
        animator.SetFloat("Horizontal", (spawnPositon.position.x - transform.position.x));
        animator.SetFloat("Vertical", (spawnPositon.position.y  - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, spawnPositon.position, speed * Time.deltaTime);
    }

    public void FollowPlayer(){
        animator.SetBool("Move", true);
        animator.SetFloat("Horizontal", (target.position.x - transform.position.x));
        animator.SetFloat("Vertical", (target.position.y  - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


}
