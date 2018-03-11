using System;
using System.ComponentModel;
using System.Configuration;
using UnityEngine;

namespace CommonTools
{
    public enum SkinTone
    {
        Light = 1,
        Lightish,
        Medium,
        Darkish,
        Dark
    }

    [Serializable]
    public class VRHandConfiguration
    {
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


        [ConfigurationProperty("Hand To Animate", DefaultValue = DEFUALT_HAND_TO_ANIMATE)]
        public HandType HandToAnimate { get; set; }

        [Browsable(false)]
        [Validator(IsRequiered = true)]
        public Color32 HandColor { get; set; }

        private GenderType mHandGender;

        [ConfigurationProperty("Hand Gender", DefaultValue = DEFUALT_HAND_GENDER)]
        [Browsable(false)]
        public GenderType HandGender
        {
            get { return mHandGender; }
            set
            {
                mHandGender =value;
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

        private string mHandModelPath = DEFAULT_HAND_MODEL_PATH;

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

        public void UpdateContents(VRHandConfiguration other)
        {
            HandGender = other.HandGender;
            HandColor = other.HandColor;
            HandToAnimate = other.HandToAnimate;
        }
    }
}
