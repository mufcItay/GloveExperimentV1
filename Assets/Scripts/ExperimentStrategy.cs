using CommonTools;
using JasHandExperiment.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JasHandExperiment
{
    /// <summary>
    /// Abstract class for an experiment strategy
    /// </summary>
    public abstract class BaseExperimentStrategy
    {
        #region Data Members
        /// <summary>
        /// list of fingers to activate. relevant for every experiment strategy
        /// </summary>
        protected List<Finger> mFingers;

        /// <summary>
        /// device to read from the hands movement coordinats
        /// </summary>
        protected IHandMovementDevice mDevice;

        /// <summary>
        /// holds the controller of the hand to associate with fingers
        /// </summary>
        protected MonoBehaviour mHandController;

        /// <summary>
        /// boolean indicating whether the strategy was initialized
        /// </summary>
        protected bool mIsInitialized;
        #endregion

        #region Properties
        /// <summary>
        /// getter for experiment type
        /// </summary>
        public abstract ExperimentType Type { get; }

        #endregion

        #region Fucntions

        /// <summary>
        /// The fucntion initializaes the experiment  members
        /// </summary>
        /// <param name="handController">the hand controller to apply experiment process to</param>
        public void Init(MonoBehaviour handController)
        {
            if (mIsInitialized)
            {
                return;
            }
            mIsInitialized = true;
            mFingers = new List<Finger>();
            mHandController = handController;
            mDevice = HandMovemventDeviceFactory.GetOrCreate(Type);
            var fingersArr = Enum.GetValues(typeof(FingerType));
            int numOfFingers = fingersArr.Length;
            // set fingers
            for (int i = 0; i < numOfFingers; i++)
            {
                mFingers.Add(new Finger(handController.transform, (FingerType)fingersArr.GetValue(i)));
            }


            InnerInit();

            // start reading from device
            mDevice.Open();
        }

        /// <summary>
        /// inner init for each specific initialization needs
        /// </summary>
        public virtual void InnerInit()
        {
            // not obligatory
        }
        
        /// <summary>
        /// The function is responsible for hand movement. can be overriten
        /// </summary>
        public virtual void MoveHand()
        {
            // roteate each finger
            foreach (var finger in mFingers)
            {
                finger.Rotate(mDevice.GetHandData() as HandCoordinatesData);
            }
        }

        /// <summary>
        /// the function closes the experiment. can be overriten
        /// </summary>
        public virtual void Close()
        {
            mIsInitialized = false;
            mFingers.Clear();
            mDevice.Close();
        } 
        #endregion

    }

    /// <summary>
    /// class for Active gloves experiments
    /// </summary>
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

    /// <summary>
    /// class for passive replay from old active experiemnt
    /// </summary>
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

    /// <summary>
    /// class for simulation, reading from a file a sqeuence of simulated key presses and applying relevant animations
    /// </summary>
    public class PassiveSimulationExperimentStrategy : BaseExperimentStrategy
    {
        #region Data Members
        // manages animation of the hand for simulation experiment type
        private AnimationManager mAnimationManager;

        string mLastDTUpdated;
        #endregion

        #region Properties
        public override ExperimentType Type
        {
            get
            {
                return ExperimentType.PassiveSimulation;
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// The functions applies init for simulation
        /// </summary>
        public override void InnerInit()
        {
            mLastDTUpdated = DateTime.MinValue.ToLongTimeString();
            InitHandAnimator();
        }

        /// <summary>
        /// the fucntino applies anumation manager reactins accordign to device's output
        /// </summary>
        public override void MoveHand()
        {
            var keyPressedData = mDevice.GetHandData() as KeyPressedData;
            if (keyPressedData.TimeStamp.Equals(mLastDTUpdated))
            {
                mAnimationManager.SetFalseToAllProps();
                return;
            }
            mLastDTUpdated = keyPressedData.TimeStamp;
            mAnimationManager.RespondExclusivleyToTrigger(keyPressedData.KeyPressed);
        }

        /// <summary>
        /// the functino initialzied the animation manager to be later used
        /// </summary>
        private void InitHandAnimator()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add(CommonConstants.INDEX_KEY_PRESS_STRING, CommonConstants.INDEX_KEY_PRESS_PARAM);
            map.Add(CommonConstants.MIDDLE_KEY_PRESS_STRING, CommonConstants.MIDDLE_KEY_PRESS_PARAM);
            map.Add(CommonConstants.RING_KEY_PRESS_STRING, CommonConstants.RING_KEY_PRESS_PARAM);
            map.Add(CommonConstants.PINKY_KEY_PRESS_STRING, CommonConstants.PINKY_KEY_PRESS_PARAM);
            mAnimationManager = new AnimationManager(mHandController, map);
        } 
        #endregion

    }
}
