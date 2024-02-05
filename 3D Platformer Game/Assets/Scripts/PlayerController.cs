using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    [SerializeField] private float pushForce = 750f;
    private float movement;
    [SerializeField] private float speed = 5f;
    public Vector3 respawnPoint;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        gameManager = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rbPlayer.AddForce(0, 0, pushForce * Time.fixedDeltaTime);
        rbPlayer.velocity = new Vector3(movement * speed, rbPlayer.velocity.y, rbPlayer.velocity.z);
        FallDetector();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag ("Barier"))
        {
            gameManager.RespawnPlayer();
        }
        
    }
    private void FallDetector()
    {
        if(rbPlayer.position.y<-2f)
        {
            gameManager.RespawnPlayer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndTrigger"))
        {
            gameManager.LevelUp();
        }
        
    }

}
