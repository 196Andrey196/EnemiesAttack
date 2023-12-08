using System;
using UnityEngine;

public class AnimationSystem
{
    private Animator _animator;


    public AnimationSystem(Animator animator)
    {
        _animator = animator;
    }
    public void SetboolAnimation(string animationName, bool toggleAnimation)
    {
        _animator.SetBool(animationName, toggleAnimation);
    }
    public void SetTrigerAnimation(string animationName)
    {
        _animator.SetTrigger(animationName);
    }

    public void CrossFadeAnimation(string nameAnimation)
    {
        if (nameAnimation != "") _animator.CrossFade(nameAnimation, 0);
    }
    public bool CheckOverAnimation(string animationName)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }

}
