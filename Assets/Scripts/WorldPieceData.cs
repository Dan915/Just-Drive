using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World Piece Data 0", menuName = "Custom/World Piece", order = 1)]
public class WorldPieceData : ScriptableObject
{
    public enum TrackName
    {
        Flats_01, Flats_02, Flats_03, Flats_04, Flats_Corner_01,
        Skyscrappers_01
    }
    //public GameObject worldPiece;
    [SerializeField]
    public GameObject[] allowedPieces;
    public Vector3 piecePosition = new Vector3(0,0,80);
    public TrackName pieceName;
}

