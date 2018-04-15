using System.Collections.Generic;
using System.IO;
using System.Text;
using CommonTools;
using JasHandExperiment.Configuration;
using UnityEngine;

namespace JasHandExperiment
{
    #region Enums
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
        Inter = 1,
        Far = 2
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
    #endregion

    /// <summary>
    /// The class contains constant members that are relevant across the application
    /// </summary>
    public static class CommonConstants
    {
        public static int TrialNumber = 1;
        public static bool FirstRun = true;
        public static bool EndOfExperement = false;

        // file relevant consts
        public const char CSV_SEPERATOR = ',';
        public const int SCALED_SESORS_ARRAY_LENGTH = 20;
        public const int TIME_COL_INDEX = 0;
        public const int KEY_PRESS_COL_INDEX = 1;
        public const char SESSION_TRIAL_SEPERATOR = '-';
        
        // hand prefab names
        internal const string MALE_HAND_RENDERER_CONTAINING_OBJECT_NAME = "fp_male_hand";
        internal  const string FEMALE_HAND_RENDERER_CONTAINING_OBJECT_NAME = "fp_female_hand";
        internal const string FEMALE_HAND_PREFAB = "FemaleHand";
        internal const string MALE_HAND_PREFAB = "MaleHand";

        // animation consts
        internal const string INDEX_KEY_PRESS_PARAM = "IndexPress";
        internal const string MIDDLE_KEY_PRESS_PARAM = "MiddlePress";
        internal const string RING_KEY_PRESS_PARAM = "RingPress";
        internal const string PINKY_KEY_PRESS_PARAM = "PinkyPress";

        // animation triggers consts
        internal const string INDEX_KEY_PRESS_STRING = "1";
        internal const string MIDDLE_KEY_PRESS_STRING = "2";
        internal const string RING_KEY_PRESS_STRING = "3";
        internal const string PINKY_KEY_PRESS_STRING = "4";

        // glove consts
        internal const string USB_PORT_NAME_PREFIX = "USB";
        internal const string DT_GLOVE_MANUFACTURER = "5DT";
        internal const string DT_RIGHT_GLOVE_INSTANCE_ID_PREFIX = "DG14UR";
        internal const string DT_LEFT_GLOVE_INSTANCE_ID_PREFIX = "DG14UL";

        // csv file extension
        internal const string CSV_EXTENSION = ".csv";
    }


    /// <summary>
    /// The clas contains common functions being used accross the application
    /// </summary>
    public static class CommonUtilities
    {
        private const string HAND_JOINT_OBJECT_NAME = "hand_joint";

        /// <summary>
        /// The function returns the relevant hand prefab according to gender
        /// </summary>
        /// <param name="gender">the relevant gender</param>
        /// <returns>name of the relevant prefab</returns>
        public static string GetHandPrefabName(GenderType gender)
        {
            if (gender == GenderType.Female)
            {
                return CommonConstants.FEMALE_HAND_PREFAB;
            }

            return CommonConstants.MALE_HAND_PREFAB;
        }

        /// <summary>
        /// The functino returns path 
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static string GetParticipantCSVFileName(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(directoryPath);
            sb.Append(ConfigurationManager.Instance.Configuration.ParticipantConfiguration.Number + @"\");
            sb.Append(ConfigurationManager.Instance.Configuration.SessionsConfiguration[ConfigurationManager.Instance.Configuration.SessionsConfiguration.Count -1].Number);
            sb.Append(CommonConstants.SESSION_TRIAL_SEPERATOR);
            sb.Append(CommonConstants.TrialNumber);
            sb.Append(CommonConstants.CSV_EXTENSION);
            return sb.ToString();
        }

        /// <summary>
        /// The function returns the renderer name of the hand according to gender
        /// </summary>
        /// <param name="gender">the relevant gender</param>
        /// <returns>name of the relevant prefab</returns>
        public static string GetRendererParentObjectName(GenderType gender)
        {
            if (gender == GenderType.Female)
            {
                return CommonConstants.FEMALE_HAND_RENDERER_CONTAINING_OBJECT_NAME;
            }

            return CommonConstants.MALE_HAND_RENDERER_CONTAINING_OBJECT_NAME;
        }
        
        /// <summary>
        /// The function returns relevant columns for CSV file for each experiment type
        /// </summary>
        /// <param name="type">relevant experiment type</param>
        /// <returns>columns IEnumerable of all of the columns of the CSVFile relevant to the experiment type</returns>
        public static IEnumerable<string> CreateGlovesDataFileColumns(ExperimentType type)
        {
            IEnumerable<string> cols;
            switch (type)
            {
                case ExperimentType.Active:
                case ExperimentType.PassiveWatchingReplay:
                    cols = new string[] { "Time","Thumb Near", "Thumb Far", "Thumb/Index", "Index Near ", "Index Far", "Index/Middle", " Middle Near", "Middle Far", "Middle/Ring", "Ring Near", "Ring Far", " Ring/Little", "Little Near", "Little Far" };
                    break;
                case ExperimentType.PassiveSimulation:
                    cols = new string[] { KeyPressedColumn.Time.ToString(), KeyPressedColumn.Key.ToString() };
                    break;
                default:
                    return null;
            }

            return cols;
        }

        /// <summary>
        /// The function wrapps usb utilities use to get glove side
        /// </summary>
        /// <returns>the side of the glove that is connected None if no glove is connected</returns>
        public static HandType GetGloveSide()
        {
            // get reqiuered usb dev id
            HandType gloveSide = HandType.None;
            var usbDevs = USBUtilities.GetConnectedDevices();
            for (int i=0; i< usbDevs.Count; i++)
            {
                // search for glove device
                if (usbDevs[i].Manufacturer.Equals(CommonConstants.DT_GLOVE_MANUFACTURER))
                {
                    if (usbDevs[i].InstanceID.Contains(CommonConstants.DT_RIGHT_GLOVE_INSTANCE_ID_PREFIX))
                    {
                        gloveSide = HandType.Right;
                    }
                    else if (usbDevs[i].InstanceID.Contains(CommonConstants.DT_LEFT_GLOVE_INSTANCE_ID_PREFIX))
                    {
                        gloveSide = HandType.Left;
                    }

                   break;
                }
            }
            
            return gloveSide;
        }

        /// <summary>
        /// The function seached for a specific finger object and returns it's Transform
        /// </summary>
        /// <param name="handController">the hand controller so search from</param>
        /// <param name="type">the finger we search for</param>
        /// <returns>Transform object of the finger we were searching</returns>
        public static Transform GetFingerObject(Transform handController, FingerType type)
        {
            var handJoint = FindObjectWithName(handController, HAND_JOINT_OBJECT_NAME);
            return handJoint.GetChild((int)type);
        }

        /// <summary>
        /// extension method for a Transform object, the fucntino searches for a given game object below given parent game object.
        /// </summary>
        /// <param name="parent">from where to search</param>
        /// <param name="nameToSearch">nae of the game pbject we are searching</param>
        /// <returns>The transform of the game object we are searching. the function will return the first occurence of this name</returns>
        public static Transform FindObjectWithName(this Transform parent, string nameToSearch)
        {
            return GetChildObject(parent, nameToSearch);
        }

        /// <summary>
        /// the fucntino searches for a given game object below given parent game object.
        /// </summary>
        /// <param name="parent">from where to search</param>
        /// <param name="nameToSearch">nae of the game pbject we are searching</param>
        /// <returns>nul if we didn't find suitable game object, or otherwise, The transform of the game object we are searching. the function will return the first occurence of this name</returns>
        private static Transform GetChildObject(Transform parent, string nameToSearch)
        {
            // end of search
            if (parent == null)
            {
                return null;
            }

            // run on all child and continue searching
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (string.Equals(child.name, nameToSearch))
                {

                    // spread seach t children
                    return child;
                }
                if (child.childCount > 0)
                {
                    var suitableChild = GetChildObject(child, nameToSearch);
                    if (suitableChild != null)
                    {
                        // suitable match
                        return suitableChild;
                    }
                }
            }
            
            // out of luck
            return null;
        }

        /// <summary>
        /// the function figures out which key was pressed.
        /// </summary>
        /// <returns>the that was pressed, if no key was pressed KeyCode.None is returned</returns>
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
