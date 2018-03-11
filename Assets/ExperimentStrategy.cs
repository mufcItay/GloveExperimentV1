using CommonTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestGame
{
    public abstract class BaseExperimentStrategy
    {
        protected List<Finger> mFingers;

        // device to read from the hands movement coordinats
        protected IHandMovementDevice mDevice;

        public abstract ExperimentType Type { get; }

        protected MonoBehaviour mHandController;

        public void Init(MonoBehaviour handController)
        {
            mFingers = new List<Finger>();
            mHandController = handController;
            mDevice = HandMovemventDeviceFactory.GetOrCreate(Type);
            var fingersArr = Enum.GetValues(typeof(FingerType));
            int numOfFingers = fingersArr.Length;
            for (int i = 0; i < numOfFingers; i++)
            {
                mFingers.Add(new Finger(handController.transform, (FingerType)fingersArr.GetValue(i)));
            }

            mDevice.Open();
        }

        public virtual void InnerInit()
        {
            // not obligatory
        }

        public virtual void MoveHand()
        {
            foreach (var finger in mFingers)
            {
                finger.Rotate(mDevice.GetHandData() as HandCoordinates);
            }
        }

        public virtual void Close()
        {
            mDevice.Close();
        }
    }

    public class ActiveExperimentStrategy : BaseExperimentStrategy
    {
        public override ExperimentType Type
        {
            get
            {
                return ExperimentType.Active;
            }
        }
    }

    public class PassiveReplayExperimentStrategy : BaseExperimentStrategy
    {
        public override ExperimentType Type
        {
            get
            {
                return ExperimentType.PassiveWatchingReplay;
            }
        }
    }

    public class PassiveSimulationExperimentStrategy : BaseExperimentStrategy
    {
        // manages animation of the hand for simulation experiment type
        private AnimationManager mAnimationManager;


        public override ExperimentType Type
        {
            get
            {
                return ExperimentType.PassiveSimulation;
            }
        }
        
        public override void InnerInit()
        {
            InitHandAnimator();
        }

        public override void MoveHand()
        {
            var keyPressedData = mDevice.GetHandData() as KeyPressedData;
            mAnimationManager.RespondExclusivleyToKey(keyPressedData.KeyPressed);
        }

        private void InitHandAnimator()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add(CommonConstants.INDEX_KEY_PRESS_STRING, CommonConstants.INDEX_KEY_PRESS_PARAM);
            map.Add(CommonConstants.MIDDLE_KEY_PRESS_STRING, CommonConstants.MIDDLE_KEY_PRESS_PARAM);
            map.Add(CommonConstants.RING_KEY_PRESS_STRING, CommonConstants.RING_KEY_PRESS_PARAM);
            map.Add(CommonConstants.PINKY_KEY_PRESS_STRING, CommonConstants.PINKY_KEY_PRESS_PARAM);
            mAnimationManager = new AnimationManager(mHandController, map);
        }

    }
}
