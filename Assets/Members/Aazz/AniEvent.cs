using UnityEngine;
using UnityEngine.Events;

public class AniEvent : MonoBehaviour
{
    public UnityEvent OnTiming;
    void OnAttack1() { OnTiming.Invoke(); }
    void OnAttack2() {  }
}
