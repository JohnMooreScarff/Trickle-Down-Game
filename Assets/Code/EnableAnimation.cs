using UnityEngine;

public class EnableAnimation : MonoBehaviour
{
    Animator animator;
  
    
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
            stonefactory Stonefactory = gameObject.GetComponent<stonefactory>();
            Farm farm = gameObject.GetComponent<Farm>();
            Tree tree = gameObject.GetComponent<Tree>();
            woodfactory Woodfactory = gameObject.GetComponent<woodfactory>();
            CoalMine coalMine = gameObject.GetComponent<CoalMine>();
            WindTurbine windTurbine = gameObject.GetComponent<WindTurbine>();
            PowerStation powerStation = gameObject.GetComponent<PowerStation>();
            
            if(village != null)
            {
                animator.speed = ResourceData.Power_multiplier * Village.TerrainMultiplier;
            }
            else if(Woodfactory != null)
            {
                animator.speed = ResourceData.Power_multiplier * woodfactory.TerrainMultiplier;
            }
            else if(iornMine != null)
            {
                animator.speed = ResourceData.Power_multiplier * IornMine.TerrainMultiplier;
            }
            else if(tree != null)
            {
                animator.speed = ResourceData.Power_multiplier * Tree.TerrainMultiplier;
            }
            else if(farm != null)
            {
                animator.speed = ResourceData.Power_multiplier * Farm.TerrainMultiplier;
            }
            else if(windTurbine != null)
            {
                animator.speed = ResourceData.Power_multiplier * WindTurbine.TerrainMultiplier;
            }
            else if(coalMine != null)
            {
                animator.speed = ResourceData.Power_multiplier * CoalMine.TerrainMultiplier;
            }
            else if(Stonefactory != null)
            {
                animator.speed = ResourceData.Power_multiplier * stonefactory.TerrainMultiplier;
            }
            else if(powerStation != null)
            {
                animator.speed = ResourceData.Power_multiplier * PowerStation.TerrainMultiplier;
            }
            else if(carbonCapture != null)
            {
                animator.speed = ResourceData.Power_multiplier * CarbonCapture.TerrainMultiplier;
            }
        }                   
    }
}
