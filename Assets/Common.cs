using System.Collections.Generic;
using System.Text;
using CommonTools;
using UnityEngine;

namespace TestGame
{
    public enum FingerType
    {
        Index = 0,
        Little = 1,
        Middle = 2,
        Ring = 3,
        Thumb = 4
    }

    public enum FingerBone
    {
        IndexNear = 1,
        IndexFar = 2,
        LittleNear = 3,
        LittleFar = 4,
        MiddleNear = 5,
        MiddleFar = 6,
        RingNear = 7,
        RingFar = 8,
        ThumbNear = 9,
        ThumbFar = 10,
    }

    public enum BoneSection
    {
        Near = 0,
        Far = 1
    }

    public enum EfdSensors
    {
        FD_THUMBNEAR = 0,
        FD_THUMBFAR = 1,
        FD_THUMBINDEX = 2,
        FD_INDEXNEAR = 3,
        FD_INDEXFAR = 4,
        FD_INDEXMIDDLE = 5,
        FD_MIDDLENEAR = 6,
        FD_MIDDLEFAR = 7,
        FD_MIDDLERING = 8,
        FD_RINGNEAR = 9,
        FD_RINGFAR = 10,
        FD_RINGLITTLE = 11,
        FD_LITTLENEAR = 12,
        FD_LITTLEFAR = 13,
        FD_THUMBPALM = 14,
        FD_WRISTBEND = 15,
        FD_PITCH = 16,
        FD_ROLL = 17
    }

    public enum KeyPressedColumn
    {
        Time = 0,
        Key = 1
    }

    public static class CommonConstants
    {
        public const char CSV_SEPERATOR = ',';
        public const int SCALED_SESORS_ARRAY_LENGTH = 20;
        public const int TIME_COL_INDEX = 0;
        public const int KEY_PRESS_COL_INDEX = 1;

        internal const string MALE_HAND_RENDERER_CONTAINING_OBJECT_NAME = "fp_male_hand";
        internal  const string FEMALE_HAND_RENDERER_CONTAINING_OBJECT_NAME = "fp_female_hand";
        
        internal const string FEMALE_HAND_PREFAB = "FemaleHand";
        internal const string MALE_HAND_PREFAB = "MaleHand";

        internal const string INDEX_KEY_PRESS_PARAM = "RIndexPress";
        internal const string MIDDLE_KEY_PRESS_PARAM = "RMiddlePress";
        internal const string RING_KEY_PRESS_PARAM = "RRingPress";
        internal const string PINKY_KEY_PRESS_PARAM = "RPinkyPress";

        internal const string INDEX_KEY_PRESS_STRING = "1";
        internal const string MIDDLE_KEY_PRESS_STRING = "2";
        internal const string RING_KEY_PRESS_STRING = "3";
        internal const string PINKY_KEY_PRESS_STRING = "4";

        internal const string USB_PORT_NAME_PREFIX = "USB";
        internal const string DT_GLOVE_PRODUCT = "5DT Glove";
        internal const string DT_GLOVE_INSTANCE_ID_PREFIX = "DG14U";
    }

    public static class CommonUtilities
    {
        private const string HAND_JOINT_OBJECT_NAME = "hand_joint";

        public static string GetHandPrefabName(GenderType gender)
        {
            if (gender == GenderType.Female)
            {
                return CommonConstants.FEMALE_HAND_PREFAB;
            }

            return CommonConstants.MALE_HAND_PREFAB;
        }

        public static string GetRendererParentObjectName(GenderType gender)
        {
            if (gender == GenderType.Female)
            {
                return CommonConstants.FEMALE_HAND_RENDERER_CONTAINING_OBJECT_NAME;
            }

            return CommonConstants.MALE_HAND_RENDERER_CONTAINING_OBJECT_NAME;
        }

        public static IEnumerable<string> CreateGlovesDataFileColumns(ExperimentType type)
        {
            IEnumerable<string> cols;
            switch (type)
            {
                case ExperimentType.Active:
                case ExperimentType.PassiveWatchingReplay:
                    cols = new string[] { "Thumb Near", "Thumb Far", "Thumb/Index", "Index Near ", "Index Far", "Index/Middle", " Middle Near", "Middle Far", "Middle/Ring", "Ring Near", "Ring Far", " Ring/Little", "Little Near", "Little Far" };
                    break;
                case ExperimentType.PassiveSimulation:
                    cols = new string[] { KeyPressedColumn.Time.ToString(), KeyPressedColumn.Key.ToString() };
                    break;
                default:
                    return null;
            }

            return cols;
        }

        public static string GetGloveUSBPort()
        {
            // get reqiuered usb dev id
            string portNumber = string.Empty;
            var usbDevs = USBUtilities.GetConnectedDevices();
            for (int i=0; i< usbDevs.Count; i++)
            {
                // search for glove device
                if (usbDevs[i].Product.Equals(CommonConstants.DT_GLOVE_PRODUCT))
                {
                    if (usbDevs[i].InstanceID.StartsWith(CommonConstants.DT_GLOVE_INSTANCE_ID_PREFIX))
                    {
                        portNumber = i.ToString();
                        break;
                    }
                }
            }
            
            StringBuilder sb = new StringBuilder();
            sb.Append(CommonConstants.USB_PORT_NAME_PREFIX);
            sb.Append(portNumber);

            return sb.ToString();
        }

        public static Transform GetFingerObject(Transform handController, FingerType type)
        {
            var handJoint = FindObjectWithName(handController, HAND_JOINT_OBJECT_NAME);
            return handJoint.GetChild((int)type);
        }

        public static Transform FindObjectWithName(this Transform parent, string nameToSearch)
        {
            return GetChildObject(parent, nameToSearch);
        }

        private static Transform GetChildObject(Transform parent, string nameToSearch)
        {
            if (parent == null)
            {
                return null;
            }

            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (string.Equals(child.name, nameToSearch))
                {
                    return child;
                }
                if (child.childCount > 0)
                {
                    var suitableChild = GetChildObject(child, nameToSearch);
                    if (suitableChild != null)
                    {
                        return suitableChild;
                    }
                }
            }

            return null;
        }

        public static KeyCode FetchKey()
        {
            var e = System.Enum.GetNames(typeof(KeyCode)).Length;
            for (int i = 0; i < e; i++)
            {
                if (Input.GetKey((KeyCode)i))
                {
                    return (KeyCode)i;
                }
            }

            return KeyCode.None;
        }
    }
}
