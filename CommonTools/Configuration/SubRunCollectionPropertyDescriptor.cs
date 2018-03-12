using System;
using System.Text;
using System.ComponentModel;

namespace CommonTools
{
	/// <summary>
	/// property descriptor for sub runs - for property grid.
	/// </summary>
	public class SubRunCollectionPropertyDescriptor : PropertyDescriptor
	{
        #region Data Members
        /// <summary>
        /// collection of sub runs
        /// </summary>
        private SubRunCollection collection = null;
        
        /// <summary>
        /// the index of the current subrun
        /// </summary>
        private int index = -1;
        #endregion

        
        #region Ctor
        public SubRunCollectionPropertyDescriptor(SubRunCollection coll, int idx) :
            base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        }
        #endregion

        #region Property Descriptor Implementation
        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
                return "Sub Run #" + index;
            }
        }

        public override string Description
        {
            get
            {
                SubRunConfiguration subRun = this.collection[index];
                StringBuilder sb = new StringBuilder();
                sb.Append("Blocks Amount: ");
                sb.Append(subRun.BlocksAmount);
                sb.Append(",");
                sb.Append("InterBlockTimeout: ");
                sb.Append(subRun.InterBlockTimeout);

                return sb.ToString();
            }
        }

        public override object GetValue(object component)
        {
            return this.collection[index];
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override string Name
        {
            get { return "#" + index.ToString(); }
        }

        public override Type PropertyType
        {
            get { return this.collection[index].GetType(); }
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        } 
        #endregion
    }
}
