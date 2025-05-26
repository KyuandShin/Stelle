using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{

    private GameObject player;
    private Transform playerTransform;

    public Transform visualTransform;
    Rigidbody rb;
    float moveSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = PlayerMovement.player;
        //playerTransform = player.transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateImageFacing();


    }

    void UpdateImageFacing()
    {
        if (rb.linearVelocity.x < 0f)
        {
            visualTransform.localScale = new Vector3(-1f, 1f, 1f);
            return;
        }

        if (rb.linearVelocity.x > 0f)
        {
            visualTransform.localScale = new Vector3(1f, 1f, 1f);
            return;
        }        


    }


    void FixedUpdate()
    {

        Vector3 dirToPlayer = (-transform.position + PlayerMovement.player.transform.position);
        dirToPlayer.y = 0;
        dirToPlayer = dirToPlayer.normalized;
        Vector3 moveDirection = new Vector3(dirToPlayer.x * moveSpeed, rb.linearVelocity.y, dirToPlayer.z * moveSpeed);
        rb.linearVelocity = moveDirection;
        

    }
    

}
