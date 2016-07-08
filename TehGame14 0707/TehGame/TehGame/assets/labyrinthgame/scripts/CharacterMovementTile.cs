using System.Collections;
using UnityEngine;

class CharacterMovementTile : MonoBehaviour
{
    Vector3 pos;                                // For movement
    float speed = 3.2f;                         // Speed of movement
    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;
    RaycastHit2D hitUp;
    RaycastHit2D hitDown;
    public int layerMask = 1 << 14;
    Animator anim;

    bool MoveDown = false;
    bool MoveUp = false;
    bool MoveLeft = false;
    bool MoveRight = false;


    void Start()
    {
        anim = GetComponent<Animator>();
        pos = transform.position;          // Take the initial position
    }

    void Update()
    {
        Debug.DrawRay(pos, Vector3.left, Color.green);
        Debug.DrawRay(pos, Vector3.right, Color.green);
        Debug.DrawRay(pos, Vector3.up, Color.green);
        Debug.DrawRay(pos, Vector3.down, Color.green);

        hitLeft = Physics2D.Raycast(pos, Vector2.left, 1f, layerMask);
        hitRight = Physics2D.Raycast(pos, Vector2.right, 1f, layerMask);
        hitUp = Physics2D.Raycast(pos, Vector2.up, 1f, layerMask);
        hitDown = Physics2D.Raycast(pos, Vector2.down, 1f, layerMask);

        AnimationControl();

    }

    void FixedUpdate()
    {
        MovePlayer();
        
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position == pos)
        {        // Left
            if (hitLeft.collider != null)
            {
                print("Hit: " + hitLeft.collider.gameObject.name);
            }

            else
            {
                pos += Vector3.left;
            }
        }


        if (Input.GetKey(KeyCode.RightArrow) && transform.position == pos)
        {        // Right
            if (hitRight.collider != null)
            {

                print("Hit: " + hitRight.collider.gameObject.name);

            }
            else
            {
                pos += Vector3.right;
            }

        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position == pos)
        {        // Up
            if (hitUp.collider != null)
            {

                print("Hit: " + hitUp.collider.gameObject.name);

            }
            else
            {
                pos += Vector3.up;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position == pos)
        {        // Down
            if (hitDown.collider != null)
            {

                print("Hit: " + hitDown.collider.gameObject.name);

            }
            else
            {
                pos += Vector3.down;

            }
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
    }

    public void MovePlayerRight()
    {
        if (hitRight.collider != null)
        {

            print("Hit: " + hitRight.collider.gameObject.name);

        }
        else
        {
            MoveRight = true;
            pos += Vector3.right;

        }

    }

    public void MovePlayerLeft()
    {
        if (hitLeft.collider != null)
            {

            print("Hit: " + hitLeft.collider.gameObject.name);

        }
        else
        {
            MoveLeft = true;
            pos += Vector3.left;

        }

    }

    public void MovePlayerUp()
    {
        if (hitUp.collider != null)

        {

            print("Hit: " + hitUp.collider.gameObject.name);

        }
        else
        {
            MoveUp = true;
            pos += Vector3.up;
        }
    }

    public void MovePlayerDown()
    {
        if (hitDown.collider != null)
        {

            print("Hit: " + hitDown.collider.gameObject.name);

        }
        else
        {
            MoveDown = true;
            pos += Vector3.down;


        }
    }


    public void AnimationControl()
    {
        if (MoveUp == true)
        {
            anim.SetBool("GoUp", true);
            anim.SetBool("GoDown", false);
            anim.SetBool("GoRight", false);
            anim.SetBool("GoLeft", false);
            MoveUp = false;

        }

        else if (MoveLeft == true)
        {
            anim.SetBool("GoUp", false);
            anim.SetBool("GoDown", false);
            anim.SetBool("GoRight", false);
            anim.SetBool("GoLeft", true);
            MoveLeft = false;

        }

        else if (MoveRight == true)
        {
            anim.SetBool("GoUp", false);
            anim.SetBool("GoDown", false);
            anim.SetBool("GoRight", true);
            anim.SetBool("GoLeft", false);
            MoveRight = false;

        }

        else if (MoveDown == true)
        {
            anim.SetBool("GoUp", false);
            anim.SetBool("GoDown", true);
            anim.SetBool("GoRight", false);
            anim.SetBool("GoLeft", false);
            MoveDown = false;

        }
    } 


}