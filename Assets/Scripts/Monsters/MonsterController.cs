using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] DimensionalSymbol dimSym;
    [SerializeField] MoveType moveType;
}

enum MoveType
{
    Normal,
    Stationary,
    Fast,
    Unique,
    Flying
}
public enum DimensionalSymbol 
{
    Square,
    Circle,
    Diamond,
    Moon,
    Slash,
    Plus,
    Hexagon,
    Star,
    Triangle
}
