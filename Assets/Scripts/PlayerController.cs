using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject[] CM_camera;
    [SerializeField] Camera myCam;
    public int cameraSwitch = 0;
    public bool useAccelerometer = false;
    public float speed;
    Rigidbody myRb;
    public int Xincrement;
    public int maxX, minX;
    public int currentLane = 1;
    public float turnSpeed = 2;
    public Vector3 Position;
    public bool isTurningLeft, isTurningRight;
  [SerializeField] [Range(1,20)] float LerpTime;
  [SerializeField] [Range(0,2)] float rotationTime;
  [SerializeField] Vector3[] turnAngle;
  [Space][SerializeField][Header("Wheels Settings")] Vector3[] wheelsTurnAngle;

  [SerializeField] GameObject[] Wheels;
  private Touch theTouch;
  private Vector2 touchStartPosition, touchEndPosition;
  GameObject worldGenerator;
  public bool crashed;

    // Start is called before the first frame update
    void Start()
    {
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
        //Position = transform.position;
        myCam = Camera.main;
        myRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // private void FixedUpdate() 
    // {
    //    myRb.AddForce(transform.forward * speed);
    // }
    private void Update() 
    {
        speed = worldGenerator.GetComponent<WorldGenerator>().playerSpeed;
        if (!crashed)
        {
            ChangeLane();
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        
        Position.y = transform.position.y;
        Position.z = transform.position.z;
        

        // Touch Swipe Input
        if (Input.touchCount > 0)
{
	theTouch = Input.GetTouch(0);

	if (theTouch.phase == TouchPhase.Began)
	{
		touchStartPosition = theTouch.position;
	}

	else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
	{
		touchEndPosition = theTouch.position;

		float x = touchEndPosition.x - touchStartPosition.x;
		float y = touchEndPosition.y - touchStartPosition.y;

		if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
		{
			Debug.Log("Tapped");
		}

		else if (Mathf.Abs(x) > Mathf.Abs(y))
		{
            if (x > 0)
            {
                Debug.Log("Right");
            }
            else
            {
                Debug.Log("Right");
            }
			
		}

		// else
		// {
		// 	direction = y > 0 ? “Up” : “Down”;
		// }
	}
}
       
       TurnCar();
  
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)  
        {
            CM_camera[0].SetActive(false);
            CM_camera[1].SetActive (true);
            CM_camera[2].SetActive (true);
            myCam.orthographic = true;
        }
        else 
        {
            CM_camera[0].SetActive  (true);
            CM_camera[1].SetActive (true);
            CM_camera[2].SetActive (true);
            myCam.orthographic = false;
        }
       if (Input.GetKeyUp(KeyCode.P))
       {
           
            if (cameraSwitch >= 3)
            cameraSwitch = 0;

            cameraSwitch++;

           switch (cameraSwitch)
           {
               case 1:
               CM_camera[0].SetActive  (true);
               CM_camera[1].SetActive (true);
               CM_camera[2].SetActive (true);
               myCam.orthographic = false;
               break;
               case 2:
               CM_camera[0].SetActive  (false);
               CM_camera[1].SetActive (true);
               CM_camera[2].SetActive (true);
               myCam.orthographic = true;
               break;
               case 3:
               CM_camera[0].SetActive  (false);
               CM_camera[1].SetActive (false);
               CM_camera[2].SetActive (true);
               myCam.orthographic = false;
               break;
               default:
               break;
           }

       }
    }
    void ChangeLane()
    {
        Vector3 laneOne = new Vector3 (-5, transform.position.y, transform.position.z);
        Vector3 laneTwo = new Vector3 (0, transform.position.y, transform.position.z);
        Vector3 laneThree = new Vector3 ( 5, transform.position.y, transform.position.z);
        Vector3 laneFour = new Vector3 (10,transform.position.y, transform.position.z);

 
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                isTurningRight = true;
                TurnCar();

                switch (currentLane)
                {
                    case 1:
                    Position = laneTwo;
                    currentLane ++;
                    break;
                    case 2:
                    Position = laneThree;
                    currentLane ++;
                    break;
                    case 3:
                    Position = laneFour;
                    currentLane ++;
                    break;
                    // case 1:
                    // Position = laneOne;
                    // break;
                    default:
                    break;
                }
            }
        
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                isTurningLeft = true;
                TurnCar();

                switch (currentLane)
                {
                    case 4:
                    Position = laneThree;
                    currentLane --;
                    break;
                    case 3:
                    Position = laneTwo;
                    currentLane --;
                    break;
                    case 2:
                    Position = laneOne;
                    currentLane --;
                    break;
                    // case 1:
                    // Position = laneOne;
                    // break;
                    default:
                    break;
                }
            }
        
        
                    transform.position = Vector3.MoveTowards(transform.position, Position, Time.deltaTime * turnSpeed);

        


        // if (Input.GetKeyDown(KeyCode.D) && transform.position.x < maxX)
        // {
        //     Position = new Vector3(transform.position.x + Xincrement, transform.position.y, transform.position.z);
        // }

        // if (Input.GetKeyDown(KeyCode.A) && transform.position.x > minX)
        // {
        //     Position = new Vector3(transform.position.x - Xincrement, transform.position.y, transform.position.z);
        // }
        //     transform.position = Vector3.MoveTowards(transform.position, Position, turnSpeed * Time.deltaTime);

    }

    void TurnCar()
    {
        // Rotates car and wheels
        
        if (isTurningLeft)
       {
            transform.rotation = Quaternion.Slerp ( transform.rotation, Quaternion.Euler (turnAngle[0]), LerpTime*Time.deltaTime);
            foreach (GameObject item in Wheels)
            {
                item.transform.transform.rotation = Quaternion.Slerp ( item.transform.rotation, Quaternion.Euler (wheelsTurnAngle[0] ), LerpTime*Time.deltaTime);
            }
       }
       else if (isTurningRight)
       {
            transform.rotation = Quaternion.Slerp ( transform.rotation, Quaternion.Euler (turnAngle[2]), LerpTime*Time.deltaTime);
            foreach (GameObject item in Wheels)
            {
                item.transform.rotation = Quaternion.Slerp ( item.transform.rotation, Quaternion.Euler (wheelsTurnAngle[2]), LerpTime*Time.deltaTime);
            }
       }
       else
       {
            transform.rotation = Quaternion.Slerp ( transform.rotation, Quaternion.Euler (turnAngle[1]), LerpTime*Time.deltaTime);
            foreach (GameObject item in Wheels)
            {
                item.transform.rotation = Quaternion.Slerp ( item.transform.rotation, Quaternion.Euler (wheelsTurnAngle[1]), LerpTime*Time.deltaTime);
            }

       }
       StartCoroutine(delay());
    }
 
    IEnumerator delay()
    {
        yield return new WaitForSeconds(rotationTime);
        isTurningRight = false;
        isTurningLeft = false;
    }
    
 

}
