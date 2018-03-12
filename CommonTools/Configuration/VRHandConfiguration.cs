using System;
using System.ComponentModel;
using System.Configuration;
using UnityEngine;

namespace CommonTools
{
    #region Enum
    public enum SkinTone
    {
        Light = 1,
        Lightish,
        Medium,
        Darkish,
        Dark
    } 
    #endregion

    /// <summary>
    /// the class contains configuration of how the hand in the experiment should apear
    /// </summary>
    [Serializable]
    public class VRHandConfiguration
    {
        #region Consts
        private const GenderType DEFUALT_HAND_GENDER = GenderType.Male;
        private const HandType DEFUALT_HAND_TO_ANIMATE = HandType.Right;
        
        public static readonly Color32 SKIN_TONE_DARK = new Color32(141, 85, 36,255);
        public static readonly Color32 SKIN_TONE_DARKISH = new Color32(198, 134, 66,255);
        public static readonly Color32 SKIN_TONE_MEDIUM = new Color32(224, 172, 105,255);
        public static readonly Color32 SKIN_TONE_LIGHTISH = new Color32(241, 194, 125,255);
        public static readonly Color32 SKIN_TONE_LIGHT = new Color32(255, 219, 172,255);

        public const char MALE_HANDMODEL_TAG = 'M';
        public const char FEMALE_HANDMODEL_TAG = 'W';

        private static readonly string DEFAULT_HAND_MODEL_PATH = "hand_Model" + MALE_HANDMODEL_TAG+ ".obj";
        #endregion

        #region Data Members
        /// <summary>
        /// member which hods data about the gender of the subject, the hand will be updated accordingly
        /// </summary>
        private GenderType mHandGender;

        /// <summary>
        /// The path to the model of the hand
        /// </summary>
        private string mHandModelPath = DEFAULT_HAND_MODEL_PATH;

        #endregion

        #region Properties
        /// <summary>
        /// The hand to animate in the experiment
        /// </summary>
        [ConfigurationProperty("Hand To Animate", DefaultValue = DEFUALT_HAND_TO_ANIMATE)]
        public HandType HandToAnimate { get; set; }

        /// <summary>
        /// the color of the hand
        /// </summary>
        [Browsable(false)]
        [Validator(IsRequiered = true)]
        public Color32 HandColor { get; set; }
        
        /// <summary>
        /// the gender of the subject, relevant to choose hand model
        /// </summary>
        [ConfigurationProperty("Hand Gender", DefaultValue = DEFUALT_HAND_GENDER)]
        [Browsable(false)]
        public GenderType HandGender
        {
            get { return mHandGender; }
            set
            {
                // if we switch gender of subject we need to change hnad model accordingly
                mHandGender = value;
                var modelPathCArr = mHandModelPath.ToCharArray();
                if (mHandGender == GenderType.Male)
                {
                    modelPathCArr[mHandModelPath.IndexOf('.') - 1] = MALE_HANDMODEL_TAG;
                }
                else
                {
                    modelPathCArr[mHandModelPath.IndexOf('.') - 1] = FEMALE_HANDMODEL_TAG;
                }
                mHandModelPath = new String(modelPathCArr);
            }
        }

        /// <summary>
        /// the hand model to be presented
        /// </summary>
        [Browsable(false)]
        public string HandModel
        {
            get { return mHandModelPath; }
            set
            {
                var modelPathCArr = mHandModelPath.ToCharArray();
                if ((HandGender == GenderType.Male && modelPathCArr[mHandModelPath.IndexOf('.') - 1] == VRHandConfiguration.MALE_HANDMODEL_TAG) ||
                    (HandGender == GenderType.Female && modelPathCArr[mHandModelPath.IndexOf('.') - 1] == VRHandConfiguration.FEMALE_HANDMODEL_TAG))
                {
                    mHandModelPath = value;
                }
                else
                {
                    string message = "Incompatible file name, should end with M if it is a male hand and W if it's a female hand. choose M for default";
                    throw new ArgumentException(message);
                }
            }
        }

        #endregion

        #region Ctors
        public VRHandConfiguration()
        {
            HandColor = SKIN_TONE_MEDIUM;
            HandGender = GenderType.Male;
            ConfiguartionUtilities.SetDefaultValues(this);
        }

        public VRHandConfiguration(VRHandConfiguration other)
        {
            UpdateContents(other);
        }

        #endregion

        /// <summary>
        /// The function updates the contents of the instance according to an other VRHandConfiguration object.
        /// </summary>
        /// <param name="other"></param>
        public void UpdateContents(VRHandConfiguration other)
        {
            HandGender = other.HandGender;
            HandColor = other.HandColor;
            HandToAnimate = other.HandToAnimate;
        }
    }
}
