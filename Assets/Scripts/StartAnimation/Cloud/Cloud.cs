using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour, IDotWeenAnimation
{
    [SerializeField] private MeshRenderer[] clouds_blocks;
    [SerializeField] private BoxCollider cloud_collider;

    [SerializeField] private int min_duration;
    [SerializeField] private int max_duration;
    [SerializeField] private float min_scatterRange;
    [SerializeField] private float max_scatterRange;
    
    public void PlayAnimation()
    {
        cloud_collider.isTrigger = true;
        
        foreach(var cloud in clouds_blocks)
        {
            int duration = Random.Range(min_duration, max_duration);
            Vector3 moveTo = new Vector3(Random.Range(min_scatterRange, max_scatterRange), Random.Range(min_scatterRange, max_scatterRange), Random.Range(min_scatterRange, max_scatterRange));
            cloud.transform.DOMove(moveTo, duration).SetRelative();
            cloud.material.DOFade(0, duration).OnKill(DestroyParrent);
        }
    }
    private void DestroyParrent()
    {
        if (cloud_collider != null)
        {
            Destroy(cloud_collider.gameObject);
        }
    }
}
