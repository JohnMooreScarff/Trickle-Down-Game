using UnityEngine;
using System.Collections;

public class RandomParticleActivator : MonoBehaviour
{
    public ParticleSystem[] particleSystems;

    void Start()
    {
        StartCoroutine(ActivateRandomParticle());
    }

    IEnumerator ActivateRandomParticle()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, particleSystems.Length);
            particleSystems[randomIndex].Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
}