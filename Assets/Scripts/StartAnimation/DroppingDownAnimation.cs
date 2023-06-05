using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingDownAnimation : MonoBehaviour, IDotWeenAnimation
{
    [SerializeField] private MeshRenderer[] objectsToAnimate;
    [SerializeField] private Vector3 endRandom—oefficient;
    [SerializeField] private int duration;

    public void PlayAnimation()
    {
        foreach (var obj in objectsToAnimate)
        {
            var oldPos = obj.transform.position;
            var newPos = oldPos;

            newPos.x += Random.Range(newPos.x, newPos.x + endRandom—oefficient.x);
            newPos.y += Random.Range(newPos.y, newPos.y + endRandom—oefficient.y);
            newPos.z += Random.Range(newPos.z, newPos.z + endRandom—oefficient.z);

            obj.transform.position = newPos;

            DroppingDown(obj.transform, duration, obj.transform.position, oldPos);
        }
    }
    private void DroppingDown(Transform transform, int duration, Vector3 startPos, Vector3 endPos)
    {
        transform.position = startPos;
        transform.DOMove(endPos, duration);
    }
}

