using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator characterAnimator;
    // Start is called before the first frame update
    
    public void onPlayerGoBack(bool walk_back){
        characterAnimator.SetBool("walk_back", walk_back);
    }

    public void onPlayerGoForward(bool walk_forward){
        characterAnimator.SetBool("walk_front", walk_forward);
    }

    public void onPlayerGoSide(bool walk_side){
        characterAnimator.SetBool("walk_horizontal", walk_side);
    }
}
