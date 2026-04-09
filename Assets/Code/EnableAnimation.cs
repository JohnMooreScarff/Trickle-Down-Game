using UnityEngine;

public class EnableAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.enabled = true;
    }

    void Update()
    {
        if (animator.enabled)
        {
            Village village = gameObject.GetComponent<Village>();
            IornMine iornMine = gameObject.GetComponent<IornMine>();
            CarbonCapture carbonCapture = gameObject.GetComponent<CarbonCapture>();
            stonefactory stoneFactory = gameObject.GetComponent<stonefactory>();
            Farm farm = gameObject.GetComponent<Farm>();
            Tree tree = gameObject.GetComponent<Tree>();
            woodfactory woodFactory = gameObject.GetComponent<woodfactory>();
            CoalMine coalMine = gameObject.GetComponent<CoalMine>();
            WindTurbine windTurbine = gameObject.GetComponent<WindTurbine>();
            PowerStation powerStation = gameObject.GetComponent<PowerStation>();

            if (village != null)
            {
                animator.speed = ResourceData.Power_multiplier * village.TerrainMultiplier;
            }
            else if (woodFactory != null)
            {
                animator.speed = ResourceData.Power_multiplier * woodFactory.TerrainMultiplier;
            }
            else if (iornMine != null)
            {
                animator.speed = ResourceData.Power_multiplier * iornMine.TerrainMultiplier;
            }
            else if (tree != null)
            {
                animator.speed = ResourceData.Power_multiplier * tree.TerrainMultiplier;
            }
            else if (farm != null)
            {
                animator.speed = ResourceData.Power_multiplier * farm.TerrainMultiplier;
            }
            else if (windTurbine != null)
            {
                animator.speed = ResourceData.Power_multiplier * windTurbine.TerrainMultiplier;
            }
            else if (coalMine != null)
            {
                animator.speed = ResourceData.Power_multiplier * coalMine.TerrainMultiplier;
            }
            else if (stoneFactory != null)
            {
                animator.speed = ResourceData.Power_multiplier * stoneFactory.TerrainMultiplier;
            }
            else if (powerStation != null)
            {
                animator.speed = ResourceData.Power_multiplier * powerStation.TerrainMultiplier;
            }
            else if (carbonCapture != null)
            {
                animator.speed = ResourceData.Power_multiplier * carbonCapture.TerrainMultiplier;
            }
        }
    }
}
