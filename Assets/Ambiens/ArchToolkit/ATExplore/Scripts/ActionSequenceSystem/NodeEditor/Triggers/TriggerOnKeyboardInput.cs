using System.Collections;
using System.Collections.Generic;
using ambiens.archtoolkit.atexplore.XNode;
using UnityEngine;

namespace ambiens.archtoolkit.atexplore.actionSystem
{
    
    [CreateNodeMenuAttribute("Triggers/Trigger On Keyboard Input")]

    public class TriggerOnKeyboardInput : ATriggerBase
    {
        public enum InputType{
            GetKeyUp,
            GetKeyDown,
            GetKey
        }
        public InputType type;
        public KeyCode keycode;
        public bool onlyOnce;
        private bool alreadyDone=false;
        protected override void _RuntimeInit()
        {
            alreadyDone=false;
            this.GetSequenceHolder().ManagedUpdate -= this.ManagedUpdate;
            this.GetSequenceHolder().ManagedUpdate += this.ManagedUpdate;
        }

        public override void ManagedUpdate(float deltaTime)
        {
            
            if( onlyOnce ){
                if(alreadyDone) return;
                alreadyDone=true;
            }
            
            switch(type){
                case InputType.GetKey:
                    if(Input.GetKey(keycode)){
                        this.CallNext();
                    }
                break;
                case InputType.GetKeyDown:
                    if(Input.GetKeyDown(keycode)){
                        this.CallNext();
                    }
                break;
                case InputType.GetKeyUp:
                    if(Input.GetKeyUp(keycode)){
                        this.CallNext();
                    }
                break;
            }
           
        }

        private void CallNext(){
            //On Complete will also remove the managed update callback
            if(onlyOnce) this.OnComplete();
            else this.StartNext();
        }
    }
    
}
