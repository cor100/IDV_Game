using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [SerializeField] float speed = 1;
    private Rigidbody2D characterRB2D;
    private SpriteRenderer characterSprite;
    private bool walk_horizontal = false;
    private bool walk_back = false;
    private bool walk_front = false;
    private Vector2 velChange = Vector2.zero;

    private PlayerAnimation playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        characterRB2D = GetComponent<Rigidbody2D>();
        characterSprite = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<PlayerAnimation>();

    }

    // Update is called once per frame
    void Update()
    {
        velChange = Vector2.zero;
        CheckWalking();
        UpdateAnimator();
    }

    private void CheckWalking(){

        if (Input.GetKey(KeyCode.RightArrow)){
            characterSprite.flipX = true;
            velChange.x = speed;
            walk_horizontal = true;
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            characterSprite.flipX = false;
            velChange.x = -speed;
            walk_horizontal = true;
        }else{
            walk_horizontal = false;
        }

        if(Input.GetKey(KeyCode.UpArrow)){
            velChange.y = speed;
            walk_back = true;
        }else{
            walk_back = false;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            velChange.y = -speed;
            walk_front = true;
        }else{
            walk_front = false;
        }
        characterRB2D.velocity = velChange;
    }
    private void UpdateAnimator()
    {
        playerAnimation.onPlayerGoSide(walk_horizontal);
        playerAnimation.onPlayerGoBack(walk_back);
        playerAnimation.onPlayerGoForward(walk_front);
    }
    public bool returnWalkFront(){
        return walk_front;
    }
    public bool returnWalkBack(){
        return walk_back;
    }
    public bool returnWalkSide(){
        return walk_horizontal;
    }
}
