using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parallax", menuName = "ScriptableObjects/Parallax")]
public class Parallax : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}
