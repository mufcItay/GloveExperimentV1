using System;
using System.Windows.Forms;
using System.Windows.Media;
using CommonTools;
using JasHandExperiment.Configuration;

namespace JasHandExperiment.UI
{
    public partial class VRHandEditorControl : UserControl, IDisposable
    {

        #region Data Members

        /// <summary>
        /// the control presenting the actua hand model
        /// </summary>
        private ModelPresentorControl mModelPresentorControl;

        /// <summary>
        /// the configuratino object being edited by this control
        /// </summary>
        private VRHandConfiguration mConfigurationObject;
        
        /// <summary>
        /// property to react to configuration object sets by changing inner state directly
        /// </summary>
        public VRHandConfiguration ConfigurationObject
        {
            get
            {
                if (mConfigurationObject == null)
                {
                    return mConfigurationObject;
                }

                // initialization of hand to animate
                mConfigurationObject.HandToAnimate = HandType.None;
                if (radioButtonRightHand.Checked)
                {
                    mConfigurationObject.HandToAnimate = HandType.Right;
                }
                else if (radioButtonLeftHand.Checked)
                {
                    mConfigurationObject.HandToAnimate = HandType.Left;
                }

                return mConfigurationObject;
            }
            set
            {
                mConfigurationObject = value;
                // avoid null exceptions irelevant for designer functions
                if (value == null)
                {
                    return;
                }

                // update controls hand inner state
                radioButtonNone.Checked = mConfigurationObject.HandToAnimate == HandType.None;
                radioButtonLeftHand.Checked = mConfigurationObject.HandToAnimate == HandType.Left;
                radioButtonRightHand.Checked = mConfigurationObject.HandToAnimate == HandType.Right;
                System.Windows.Media.Color winCol = ConvertUnityColor(mConfigurationObject.HandColor);
                SetHandColorScroll(mConfigurationObject.HandColor);
                mModelPresentorControl.LoadModel(mConfigurationObject.HandModel, winCol);
                button_ColorDialog.BackColor = System.Drawing.Color.FromArgb(winCol.R, winCol.G, winCol.B);
            }
        }

        #endregion

        #region Life Cycle
        public VRHandEditorControl()
        {
            InitializeComponent();
            mModelPresentorControl = new ModelPresentorControl();
            // set the model presentor of the hand
            elementHost_Hands.Child = mModelPresentorControl;
        }

        ~VRHandEditorControl()
        {
            // free model presentor resources
            elementHost_Hands.Dispose();
        } 
        #endregion


        /// <summary>
        /// The function compares two unity colors
        /// </summary>
        /// <param name="color">some color</param>
        /// <param name="other">color to compate 'color' with</param>
        /// <returns>true for equal, false otherwise</returns>
        private bool CompareColor32(UnityEngine.Color32 color, UnityEngine.Color32 other)
        {
            if (color.r == other.r && color.g == other.g && color.b == other.b)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// the functino sets hand color scroll according to configurated hand color
        /// </summary>
        /// <param name="color">the configurated hand color</param>
        private void SetHandColorScroll(UnityEngine.Color32 color)
        {
            // default
            trackBarTone.Value = (int)SkinTone.Light;

            if (CompareColor32(color, VRHandConfiguration.SKIN_TONE_LIGHTISH))
            {
                trackBarTone.Value = (int)SkinTone.Lightish;
                return;
            }
            if (CompareColor32(color, VRHandConfiguration.SKIN_TONE_MEDIUM))
            {
                trackBarTone.Value = (int)SkinTone.Medium;
                return;
            }
            if (CompareColor32(color, VRHandConfiguration.SKIN_TONE_DARKISH))
            {
                trackBarTone.Value = (int)SkinTone.Darkish;
                return;
            }
            if (CompareColor32(color, VRHandConfiguration.SKIN_TONE_DARK))
            {
                trackBarTone.Value = (int)SkinTone.Dark;
                return;
            }
        }


        private void button_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SetNewHandColor(colorDialog.Color);
            }
        }

        /// <summary>
        /// the function sets hand color according to Windows color, need to convert color to fit model.
        /// </summary>
        /// <param name="c">color to set</param>
        private void SetNewHandColor(System.Drawing.Color c)
        {
            // update controls
            button_ColorDialog.BackColor = c;
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromRgb(c.R, c.G, c.B);
            mConfigurationObject.HandColor = ConvertWinColor(newColor);
            mModelPresentorControl.ChangeModelColor(newColor);
        }

        /// <summary>
        /// the functino sets the path to the hand model being presented
        /// </summary>
        /// <param name="modelPath"></param>
        public void SetModelPath(string modelPath)
        {
            mModelPresentorControl.LoadModel(modelPath, ConvertUnityColor(mConfigurationObject.HandColor));
            mConfigurationObject.HandModel = modelPath;
        }

        private void linkLabelChangeModel_Click(object sender, EventArgs e)
        {
            try
            {
                // set new model path with a file dialog
                if (openFileDialogModel.ShowDialog() == DialogResult.OK)
                {
                    mConfigurationObject.HandModel = openFileDialogModel.FileName;
                    SetModelPath(mConfigurationObject.HandModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void trackBarTone_Scroll(object sender, EventArgs e)
        {
            // react to hand color scroll change by changing hand color
            SkinTone selectedTone = (SkinTone) trackBarTone.Value;
            UnityEngine.Color32 unitySelectedColor = VRHandConfiguration.SKIN_TONE_MEDIUM;
            switch (selectedTone)
            {   
                case SkinTone.Light:
                    unitySelectedColor = VRHandConfiguration.SKIN_TONE_LIGHT;
                    break;
                case SkinTone.Lightish:
                    unitySelectedColor = VRHandConfiguration.SKIN_TONE_LIGHTISH;
                    break;
                case SkinTone.Medium:
                    unitySelectedColor = VRHandConfiguration.SKIN_TONE_MEDIUM;
                    break;
                case SkinTone.Darkish:
                    unitySelectedColor = VRHandConfiguration.SKIN_TONE_DARKISH;
                    break;
                case SkinTone.Dark:
                    unitySelectedColor = VRHandConfiguration.SKIN_TONE_DARK;
                    break;
                default:
                    break;
            }
            // change hand color
            mConfigurationObject.HandColor = unitySelectedColor;
            System.Windows.Media.Color selectedColor = ConvertUnityColor(unitySelectedColor);
            SetNewHandColor(System.Drawing.Color.FromArgb(255, selectedColor.R, selectedColor.G, selectedColor.B));
        }

        /// <summary>
        /// the function converts from unity color to windows color
        /// </summary>
        /// <param name="unityColor">color to convert</param>
        /// <returns>windows color equivalent to unity color</returns>
        public static System.Windows.Media.Color ConvertUnityColor(UnityEngine.Color32 unityColor)
        {
            return System.Windows.Media.Color.FromRgb(unityColor.r, unityColor.g, unityColor.b);
        }

        /// <summary>
        /// the function converts from windows color to unity color
        /// </summary>
        /// <param name="unityColor">color to convert</param>
        /// <returns>unity color equivalent to windows color</returns>
        public static UnityEngine.Color32 ConvertWinColor(System.Windows.Media.Color winColor)
        {
            return new UnityEngine.Color32(winColor.R, winColor.G, winColor.B,byte.MaxValue);
        }

    }
}
