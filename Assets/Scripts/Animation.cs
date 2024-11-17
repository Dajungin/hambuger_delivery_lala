using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Player 태그를 가진 물체
        {

            animator.SetBool("Jump", true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
