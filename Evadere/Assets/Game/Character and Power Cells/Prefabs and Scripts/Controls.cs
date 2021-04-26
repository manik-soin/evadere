
/**
 * This script controls the character's animation, movement, and status.
 * @author Hong Ming, Wong
 */

using UnityEngine;
using UnityEngine.UI;
public class Controls : MonoBehaviour
{

    public static int currentHealth = 100;
    public static int cellsCollected = 0;
    public float rotationSpeed = 100.0F;
    public float walkingSpeed = 2.0f;
    public float runningSpeed = 7.0f;
    public float acceleration = 0.2f;
    public int addHealth = 20;
    public static int requiredCells = 5;
    public Text text;


    private Animator anim;
    private CharacterController characterController;
    private bool canPickUp = false;
    private float currentSpeed = 0;   
    private GameObject objectToPickUp;
    private GameObject spaceship;

    private bool canEnterSpaceship = false; 


    private Color32 originalColor = new Color32(0, 255, 255, 255);
    private byte g = 255;
    private byte b = 255;
    private bool flashingIn = true;
    private Vector3 direction = new Vector3();
    


    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }


    //onTriggerEnter requires the object to be detected to have isTrigger enabled.
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Item")
        {
            Debug.Log("Item Detected");
            canPickUp = true;
            objectToPickUp = other.gameObject.transform.parent.gameObject;
            text.text = "Press E to pick up Energy Cell";

        }
        else if  (other.gameObject.tag == "Spaceship")
        {
            Debug.Log("SpaceShip Detected");
            if (cellsCollected == requiredCells)
            {
                canEnterSpaceship = true;
                spaceship = other.gameObject;
                text.text = "Press E to enter Spaceship";
            }
        }
        else if (other.gameObject.tag == "Healthpack")
        {
            Debug.Log("HealthPack Detected!");
            Destroy(other);
            currentHealth += addHealth;
        }
    }


    //onTriggerExit requires the object to be detected to have isTrigger enabled.
    private void OnTriggerExit(Collider other)
    {
        
        g = 255;
        b = 255;

        if (other.gameObject.tag == "Item"){
            Debug.Log("Exit Item Pick Up Area");
            canPickUp = false;
            objectToPickUp.GetComponent<Renderer>().material.SetColor("_EmissionColor", originalColor);
        }
        else if (other.gameObject.tag == "Spaceship")
        {
            canEnterSpaceship = false;
            Debug.Log("Exit Space Ship Enter Area");
            
        }

        text.text = "";
    }
        


    //this method checks whether or not is dead or not.
    //if health is below zero, this method triggers the dying animation.
    //note that after the dying animation is played, it should not loop.
    bool CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            anim.SetTrigger("isDead");
            return true;
        }
        return false;
    }

    //This method controls the animation and changes the status while collecting energy cells.

    void PickUpItem()
    {
        if (canPickUp == true) //when the character is the detectino area of the energy cell
        {
            if (Input.GetKeyDown("e")) //and the player presses on e
            {

                objectToPickUp.GetComponent<Renderer>().material.SetColor("_EmissionColor", originalColor);
                transform.LookAt(objectToPickUp.transform.position); //the character faces the object to be picked up
                anim.SetTrigger("isCollecting"); //and then plays the animatino
                Destroy(objectToPickUp, 1.5f); //the item to be picked up will be destroyed after 1.5 seconds.
                cellsCollected++; //and then cells collected will be incremented
                canPickUp = false;
                objectToPickUp = null;
                text.text = "";

                //for debugging purposes
                Debug.Log("Picked Up!");
                Debug.Log("Number of cells collected: " +
                  cellsCollected.ToString());
                
            }
        }
    }

    void EnterSpaceship()
    {
        if (Input.GetKeyDown("e"))
        {
            Destroy(gameObject);
            //GameTransition.finishLevel = true;
        }
    }

    //Movement() uses the character controller to perform translation
    // it uses transform to perform rotation
    void Movement()
    {
        //if the character is currently picking up items, then movement is disabled
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("picking"))
        {
            return;
        }

        //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //rotation *= Time.deltaTime;
        //transform.Rotate(0, rotation, 0);

       

        float hor = 0;
        float ver = Input.GetAxis("Vertical");
        

        //if (Input.GetKey(KeyCode.W))
        //{
          //  newDirection = 1;
        //}

        Vector3 _ = new Vector3();
        characterController.SimpleMove(_); // this part is needed because simpleMove adds gravity to character.

        //controls animation
        if (ver > 0) 
        {
            //direction = newDirection;
            //transform.rotation = Quaternion.LookRotation(direction);
            anim.SetBool("isWalking", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("isRunning", true);
                if (currentSpeed < runningSpeed) currentSpeed += acceleration;

            }

            else
            {
                anim.SetBool("isRunning", false);
                currentSpeed = walkingSpeed;
            }



            Vector3 newDirection = new Vector3(hor, 0f, ver) * currentSpeed * Time.deltaTime;
            transform.Translate(newDirection, Space.Self);

            
            
        }

        else
        {
            currentSpeed = 0;
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }

       
    }


    void Flashing(GameObject gameobject)
    {
        gameobject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color32(0, g, b, 255));
        if (flashingIn)
        {
            if (g <= 0)
            {
                flashingIn = false;
            }
            else
            {
                g -= 3;
                b -= 3;
            }

        }
        else
        {
            if (g >= 255)
            {
                flashingIn = true;
            }
            else
            {
                g += 3;
                b += 3;
            }
        }
    }




    void Update()
    {
        //computing movement

        if (!CheckIfDead())
        {
            //you can only pick up items when character is not running, walking or dying.
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                if (canPickUp) PickUpItem();
                else if (canEnterSpaceship) EnterSpaceship();

            }
            Movement();
        }
        if (canPickUp)
        {
            Flashing(objectToPickUp);
        }
        else if (canEnterSpaceship)
        {
            Flashing(spaceship);
        }
    }
}
