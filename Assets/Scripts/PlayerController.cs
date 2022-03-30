using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.4f;
    public float range = 20;
    public GameObject greenBoxPrefab;
    public bool alreadyInstantiated = false;
    public bool playerPositionChanged = false;
    private int numberOfGreenBoxes;
    private bool playerWon = false;
    

    void Update()
    {

        numberOfGreenBoxes = GameObject.FindGameObjectsWithTag("GreenBox").Length;

        if (numberOfGreenBoxes >= 70)
        {
            playerWon = true;
        }

        if (!playerWon)
        {

            Vector3 direction = Vector3.forward;
            PlayerMovement();

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(direction * range));
            Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));
            

            if (!isMoving && playerPositionChanged)
            {
                Instantiate(greenBoxPrefab, transform.position, Quaternion.identity);
                playerPositionChanged = false;

            }
        }
        else
        {
            Debug.Log("Player Won");
        }
           









    }

    public void PlayerMovement()
    {
        if (transform.position.x < 1f)
        {
            transform.position = new Vector3(1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 19f)
        {
            transform.position = new Vector3(19f, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 21f)
        {
            transform.position = new Vector3(transform.position.x, 21f, transform.position.z);
        }
        if (transform.position.y < 3f)
        {
            transform.position = new Vector3(transform.position.x, 3f, transform.position.z);
        }

        if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
        {
            
            StartCoroutine(MovePlayer(Vector3.up));
            
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
        if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction1)
    {
        isMoving = true;
        
        
        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + 2f * direction1;
        while(elapsedTime < timeToMove)
        {

            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            

            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        playerPositionChanged = true;
    }
}
