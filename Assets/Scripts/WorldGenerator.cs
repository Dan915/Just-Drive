using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WorldGenerator : MonoBehaviour
{
    [Header("UI Elements")]
    public int score;
    public Text scoreText;
    [Space(15)]
    [Header("World Pieces Settings")]
    public WorldPieceData[] myWorldPiecesData;
    private List<GameObject> myAvailablePieces;
    [SerializeField] int initialPiecesToGenerate;
    //public WorldPieceData firtsPiece;
    [Space]
    public WorldPieceData lastPiece;
    public GameObject nextPiece;
    public Vector3 spawnOrigin;
    public Vector3 spawnPos;
    [Space]
    [Tooltip("Every 10th piece created difficulty will increase. More obstacles, faster pace")] public int worldPiecesCreated = 0;
    [Tooltip("World movement speed")][Range(0,100)] public float playerSpeed;
    GameObject player;
    [SerializeField] GameObject background;
    Vector3 playerPos;
    public float currentSpeed;
    public float targetSpeed = 15;  
    [Space(10)]
    public PowerUpsData[] PowerUps;
    public bool gameStarted = false;

    void Awake() 
    {
        
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < initialPiecesToGenerate; i++)
        {
            PickAndGeneratePiece();
        }
    }

    // Update is called once per frame
    void Update()
    {      
        // for debuging, creates world piece
        if (Input.GetKeyDown(KeyCode.T))
            PickAndGeneratePiece();
        if (player.GetComponent<PlayerController>().crashed != true)
        background.transform.position += Vector3.forward * Time.deltaTime * playerSpeed;
        // Increase game difficulty every time 10th world piece was created 
        // when increasing difficulty change camera to CM cam2 (ortographic) for a few seconds
        // add some pop up animaterd message that will inform player about increased difficulty
        IncreaseDifficulty();

    }
    void PickNextPiece()
    {
        //List<WorldPieceData> allowedPiecesList = new List<WorldPieceData>();
        //WorldPieceData nextPiece = null;
        myAvailablePieces = new List<GameObject>();
        switch (lastPiece.pieceName)
        {
            case WorldPieceData.TrackName.Flats_01:

                foreach (GameObject item in myWorldPiecesData[0].allowedPieces)
                {
                    myAvailablePieces.Add(item);
                }
                break;


            case WorldPieceData.TrackName.Flats_02:

                foreach (GameObject item in myWorldPiecesData[1].allowedPieces)
                {
                    myAvailablePieces.Add(item);
                }
                break;


            case WorldPieceData.TrackName.Flats_03:

                foreach (GameObject item in myWorldPiecesData[2].allowedPieces)
                {
                    myAvailablePieces.Add(item);
                }
                break;
                

            case WorldPieceData.TrackName.Flats_04:

                foreach (GameObject item in myWorldPiecesData[3].allowedPieces)
                {
                    myAvailablePieces.Add(item);
                }
                break;


            case WorldPieceData.TrackName.Flats_Corner_01:

                foreach (GameObject item in myWorldPiecesData[4].allowedPieces)
                {
                    myAvailablePieces.Add(item);
                }
                break;



            default:
                break;
        }

        nextPiece = myAvailablePieces[Random.Range(0,myAvailablePieces.Count)];        
        
    }
    void ChangeLastPiece()
    {
        // changes names of last piece so next created piece will be different

        switch (nextPiece.name)
        {
            case "Flats_01":
            lastPiece = myWorldPiecesData[0];
            break;
            case "Flats_02":
            lastPiece = myWorldPiecesData[1];
            break;
            case "Flats_03":
            lastPiece = myWorldPiecesData[2];
            break;
            case "Flats_04":
            lastPiece = myWorldPiecesData[3];
            break;
            case "Flats_Corner_01":
            lastPiece = myWorldPiecesData[4];
            break;
            default:
            break;
        }

    }
    public void PickAndGeneratePiece()
    {
         PickNextPiece();
        spawnPos = spawnPos + lastPiece.piecePosition;
        // intantiate world piece with z offset. Offset depends on number of inital pieces created. Offset = world piece lenght * inital pieces 
        Instantiate(nextPiece, new Vector3(- 10.5f,spawnPos.y,spawnPos.z + 80 + spawnOrigin.z), Quaternion.identity);
        worldPiecesCreated++;
        ChangeLastPiece();
    }
    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin += originDelta;
    }
    public void IncreaseDifficulty()
    {
        currentSpeed = playerSpeed;
        if (worldPiecesCreated >=10)
        {
            worldPiecesCreated = 0;
            if (playerSpeed < 100)
            {
               targetSpeed = currentSpeed + 5;
               // increase motion blur in camera post production
            }
            SpawnPowerUp();
        }
        playerSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime*2);
       

        // spawn more Obstacles (optional)
    }

    public void SpawnPowerUp()
    { 
        int index = Random.Range(0, PowerUps.Length);
        GameObject RandomPowerUp = PowerUps[index].prefab;
        Debug.Log("power up to spawn " + index);
        playerPos = player.transform.position;
        int[] line = new int [] {-5,0,5,10};
        Instantiate(RandomPowerUp, new Vector3( Random.Range(-5, line.Length), playerPos.y, playerPos.z + 50), Quaternion.identity);
        Debug.Log("Spawn that power up");
    }

}
