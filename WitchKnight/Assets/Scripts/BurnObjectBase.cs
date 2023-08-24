using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class BurnObjectBase : MonoBehaviour,IBurning,IBurnUp,IStopBurning
{
    public UnityEvent BurningEvent,stopBurningEvent,burnUpEvent;
    public FloatData ObMaxHp,ObMinHp,ObCurrentHp,ObPassingHp;
    public IntData ObCurrentDamage;
    
    

    private void Start()
    {
        ObCurrentHp = ScriptableObject.CreateInstance<FloatData>();
    }


   

    public void Burning()
    {
        BurningEvent.Invoke();
        ObCurrentHp.value += ObCurrentDamage.value;
        ObPassingHp.value = ObCurrentHp.value;
        if (ObCurrentHp.value >= ObMaxHp.value)
        {
            BurnUp();
        }    
    }

    public void BurnUp()
    {
        burnUpEvent.Invoke();
    }

    public void StopBurning()
    {
        stopBurningEvent.Invoke();
        ObCurrentHp.value += ObMinHp.value;
        
    }
    
}
