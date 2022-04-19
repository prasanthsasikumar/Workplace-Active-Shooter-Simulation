using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ambiens.archtoolkit.atexplore.actionSystem
{
    [CreateNodeMenuAttribute("Actions/Play Animation")]
    public class PlayAnimation : AAction
    {

        public AnimationClip Clip;
        protected override void _RuntimeInit()
        {
            if (!this.InitSceneReferences())
            {
                return;
            }

            foreach (var go in this.SceneReferences)
            {
                var anim = go.GetComponent<Animator>();
                if(anim!=null){
                    anim.enabled=false;
                }
            }
        }

        protected override bool _StartAction()
        {



            foreach (var go in this.SceneReferences)
            {
                var animation = go.GetComponent<Animation>();
                /*if (anim == null)
                {
                    anim = go.AddComponent<Animation>();
                }*/
                if (animation != null)
                {
                    animation.clip = this.Clip;
                    animation.Play();
                }
                else{
                    var animator = go.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.enabled=true;
                        animator.Play(this.Clip.name,0);

                    }

                }
            }


            return true;
        }

    }
}
