using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestGame
{
    public class AnimationManager
    {
        private MonoBehaviour mHand;
        private Animator mAnimator;

        // map string of key pressed to string property name
        private Dictionary<string, string> mKeyPressToPropertyDict;
        private IEnumerable<string> mProperties;

        public AnimationManager(MonoBehaviour hand, IEnumerable<string> properties = null)
        {
            mHand = hand;
            mAnimator = mHand.GetComponent<Animator>();
            mProperties = properties;
        }

        public AnimationManager(MonoBehaviour hand, Dictionary<string, string> keyToPropMap = null)
        {
            mHand = hand;
            mAnimator = mHand.GetComponent<Animator>();
            mKeyPressToPropertyDict = keyToPropMap;
            mProperties = mKeyPressToPropertyDict.Values;
        }

        public void SetBoolProperty(string propName, bool value)
        {
            mAnimator.SetBool(propName, value);
        }

        public void SetExclusivleyBoolPropery(string propName, bool value)
        {
            if (mProperties == null)
            {
                // error
            }
            foreach (var prop in mProperties)
            {
                if (prop.Equals(propName))
                {
                    SetBoolProperty(prop, value);
                }
                else
                {
                    SetBoolProperty(prop, !value);
                }
            }
        }

        public void SetFalseToAllProps()
        {
            if (mProperties == null)
            {
                // error
            }
            foreach (var prop in mProperties)
            {
                SetBoolProperty(prop, false);    
            }
        }

        public void RespondExclusivleyToKey(string key)
        {
            if (mKeyPressToPropertyDict == null)
            {
                // error
            }

            if (mKeyPressToPropertyDict.ContainsKey(key))
            {
                string propToSet = mKeyPressToPropertyDict[key];
                SetExclusivleyBoolPropery(propToSet, true);
            }
            else
            {
                SetFalseToAllProps();
            }
        }

    }
}
