using System;
using System.Collections;
using System.ComponentModel;

namespace JasHandExperiment.Configuration
{
	/// <summary>
	/// Type safe collection class for SubRun objects. Extends the base class 
	/// CollectionBase to inherit base collection functionality.
	/// Implementation of ICustomTypeDescvriptor to provide customized type description.
	/// </summary>
	public class SubRunCollection : CollectionBase, ICustomTypeDescriptor
	{

        #region Ctor
        public SubRunCollection(SubRunCollection other)
        {
            UpdateContents(other);
        }

        public SubRunCollection()
        {

        }
        #endregion

        #region Functions

        public void UpdateContents(SubRunCollection other)
        {
            this.List.Clear();
            foreach (var subRun in other)
            {
                Add(subRun as SubRunConfiguration);
            }
        }
        #region collection impl

        /// <summary>
        /// Adds an subRunobject to the collection
        /// </summary>
        /// <param name="subRun"></param>
        public void Add(SubRunConfiguration subRun)
        {
            this.List.Add(subRun);
        }

        /// <summary>
        /// Removes an sub Run object from the collection
        /// </summary>
        /// <param name="subRun"></param>
        public void Remove(SubRunConfiguration subRun)
        {
            this.List.Remove(subRun);
        }

        public int GetIndex(SubRunConfiguration subRun)
        {
            return List.IndexOf(subRun);
        }

        public void InsertAt(SubRunConfiguration subRun, int ind)
        {
            List.Insert(ind, subRun);
        }

        /// <summary>
        /// Returns an employee object at index position.
        /// </summary>
        public SubRunConfiguration this[int index]
        {
            get
            {
                return (SubRunConfiguration)this.List[index];
            }
        }

        #endregion

        // Implementation of interface ICustomTypeDescriptor 
        #region ICustomTypeDescriptor impl 

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }


        /// <summary>
        /// Called to get the properties of this type. Returns properties with certain
        /// attributes. this restriction is not implemented here.
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        /// <summary>
        /// Called to get the properties of this type.
        /// </summary>
        /// <returns></returns>
        public PropertyDescriptorCollection GetProperties()
        {
            // Create a collection object to hold property descriptors
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);

            // Iterate the list of employees
            for (int i = 0; i < this.List.Count; i++)
            {
                // Create a property descriptor for the employee item and add to the property descriptor collection
                SubRunCollectionPropertyDescriptor pd = new SubRunCollectionPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            // return the property descriptor collection
            return pds;
        }

        #endregion 
        #endregion
    }
}