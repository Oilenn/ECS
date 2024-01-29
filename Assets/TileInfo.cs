using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    public Vector3 GetTransform { get { return new Vector3(_transform.position.x, _transform.position.y); } }
    public TileType Type;
}
