using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening.Plugins.Core.PathCore;

public class Train : MonoBehaviour
{
    public List<Transform> roadPoints;
    public Stash stash;
    public float speed;
    private void OnEnable()
    {
        Movement();
    }
    private void Movement()
    {

        var roadPositions = new List<Vector3>();
        roadPoints.ForEach(r => roadPositions.Add(r.position));
        Path path = new (PathType.CatmullRom, roadPositions.ToArray(), 2);

        transform.DOPath(path, speed).SetLoops(-1).SetLookAt(0).SetOptions(true).OnWaypointChange(p =>
        {
            if (p != 0) return;
            stash.DropAllStash();
        });
    }
    
}
