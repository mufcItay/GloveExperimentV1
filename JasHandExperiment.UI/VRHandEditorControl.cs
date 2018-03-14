using System;
using System.Windows.Forms;
using System.Windows.Media;
using CommonTools;
using JasHandExperiment.Configuration;

namespace JasHandExperiment.UI
{
    public partial class VRHandEditorControl : UserControl, IDisposable
    {
        private VRHandConfiguration mConfigurationObject;
        public VRHandConfiguration ConfigurationObject
        {
            get
            {
                if(mConfigurationObject == null)
                {
                    return mConfigurationObject;
                }
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
                if (value == null)
                {
                    return;
                }
                
                radioButtonNone.Checked = mConfigurationObject.HandToAnimate == HandType.None;
                radioButtonLeftHand.Checked = mConfigurationObject.HandToAnimate == HandType.Left;
                radioButtonRightHand.Checked = mConfigurationObject.HandToAnimate == HandType.Right;
                System.Windows.Media.Color winCol = ConvertUnityColor(mConfigurationObject.HandColor);
                SetHandColorScroll(mConfigurationObject.HandColor);
                mModelPresentorControl.LoadModel(mConfigurationObject.HandModel, winCol);
                button_ColorDialog.BackColor = System.Drawing.Color.FromArgb(winCol.R, winCol.G, winCol.B);
            }
        }

        private bool CompareColor32(UnityEngine.Color32 color, UnityEngine.Color32 other)
        {
            if (color.r == other.r && color.g == other.g && color.b == other.b)
            {
                return true;
            }
            return false;
        }
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

        public VRHandEditorControl()
        {
            InitializeComponent();
            mModelPresentorControl = new ModelPresentorControl();
            elementHost_Hands.Child = mModelPresentorControl;
        }

        ~VRHandEditorControl()
        {
            elementHost_Hands.Dispose();
        }
        
        private ModelPresentorControl mModelPresentorControl;
        
        private void button_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SetNewHandColor(colorDialog.Color);
            }
        }

        private void SetNewHandColor(System.Drawing.Color c)
        {
            button_ColorDialog.BackColor = c;
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromRgb(c.R, c.G, c.B);
            mConfigurationObject.HandColor = ConvertWinColor(newColor);
            mModelPresentorControl.ChangeModelColor(newColor);
        }

        public void SetModelPath(string modelPath)
        {
            mModelPresentorControl.LoadModel(modelPath, ConvertUnityColor(mConfigurationObject.HandColor));
            mConfigurationObject.HandModel = modelPath;
        }

        private void linkLabelChangeModel_Click(object sender, EventArgs e)
        {
            try
            {
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
            mConfigurationObject.HandColor = unitySelectedColor;
            System.Windows.Media.Color selectedColor = ConvertUnityColor(unitySelectedColor);
            SetNewHandColor(System.Drawing.Color.FromArgb(255, selectedColor.R, selectedColor.G, selectedColor.B));
        }

        public static System.Windows.Media.Color ConvertUnityColor(UnityEngine.Color32 unityColor)
        {
            return System.Windows.Media.Color.FromRgb(unityColor.r, unityColor.g, unityColor.b);
        }

        public static UnityEngine.Color32 ConvertWinColor(System.Windows.Media.Color winColor)
        {
            return new UnityEngine.Color32(winColor.R, winColor.G, winColor.B,byte.MaxValue);
        }

    }
}
