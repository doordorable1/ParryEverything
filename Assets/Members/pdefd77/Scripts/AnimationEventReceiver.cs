using System;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    public Action OnAnimationDone { get { return onAnimationDone; } set { onAnimationDone = value; } }
    private Action onAnimationDone;

    private void Awake() // 모든 애니메이션에 애니메이션 이벤트 추가
    {
        Animator animator = GetComponent<Animator>();

        foreach(AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            AnimationEvent animationEndEvent = new();
            animationEndEvent.time = clip.length;
            animationEndEvent.functionName = "OnAnimationComplete"; // 아래 함수명

            clip.AddEvent(animationEndEvent);

        }
    }

    public void OnAnimationComplete()
    {
        onAnimationDone?.Invoke();
    }
}
