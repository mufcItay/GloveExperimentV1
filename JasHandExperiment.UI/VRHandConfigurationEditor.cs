using System;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel.Design;
using CommonTools;
using JasHandExperiment.Configuration;

namespace JasHandExperiment.UI
{
    /// <summary>
    /// the class enables default editor for VRHandConfiguration
    /// </summary>
    [ConfigurationEditor(typeof(VRHandConfiguration))]
	public class VRHandConfigrationEditor: System.Drawing.Design.UITypeEditor 
	{
		private ITypeDescriptorContext _context;
		
		private IWindowsFormsEditorService edSvc = null;

		public VRHandConfigrationEditor()
		{}

		
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if (context != null	&& context.Instance != null	&& provider != null) 
			{
				object originalValue=value;
				_context=context;
				edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

				if (edSvc != null) 
				{
                    VRHandConfigurationEditorForm vrHandForm = new VRHandConfigurationEditorForm();

                    vrHandForm.ConfigurationObject =(VRHandConfiguration)value;
						
			
					if(edSvc.ShowDialog(vrHandForm) ==DialogResult.OK)
					{
						//
					}					
                    
				}
			}

			return value;
		}

		
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if (context != null && context.Instance != null) 
			{
				return UITypeEditorEditStyle.Modal;
			}
			return base.GetEditStyle(context);
		}
	}
}
