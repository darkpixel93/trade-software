﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wsTest.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Meta", Namespace="http://schemas.datacontract.org/2004/07/Strategy")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.InternalCache))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.InternalCacheItem[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.InternalCacheItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.CacheObjType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(double[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.CompositeType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(application.AppTypes.StrategyTypes))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Reflection.MemberInfo))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Type))]
    public partial class Meta : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Type ClassTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Type FormTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ParameterDescriptionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private common.DictionaryList ParameterListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ParameterPrecisionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[] ParametersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private application.AppTypes.StrategyTypes TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string URLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Authors {
            get {
                return this.AuthorsField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorsField, value) != true)) {
                    this.AuthorsField = value;
                    this.RaisePropertyChanged("Authors");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Type ClassType {
            get {
                return this.ClassTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ClassTypeField, value) != true)) {
                    this.ClassTypeField = value;
                    this.RaisePropertyChanged("ClassType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Type FormType {
            get {
                return this.FormTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.FormTypeField, value) != true)) {
                    this.FormTypeField = value;
                    this.RaisePropertyChanged("FormType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] ParameterDescriptions {
            get {
                return this.ParameterDescriptionsField;
            }
            set {
                if ((object.ReferenceEquals(this.ParameterDescriptionsField, value) != true)) {
                    this.ParameterDescriptionsField = value;
                    this.RaisePropertyChanged("ParameterDescriptions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public common.DictionaryList ParameterList {
            get {
                return this.ParameterListField;
            }
            set {
                if ((object.ReferenceEquals(this.ParameterListField, value) != true)) {
                    this.ParameterListField = value;
                    this.RaisePropertyChanged("ParameterList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ParameterPrecision {
            get {
                return this.ParameterPrecisionField;
            }
            set {
                if ((this.ParameterPrecisionField.Equals(value) != true)) {
                    this.ParameterPrecisionField = value;
                    this.RaisePropertyChanged("ParameterPrecision");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[] Parameters {
            get {
                return this.ParametersField;
            }
            set {
                if ((object.ReferenceEquals(this.ParametersField, value) != true)) {
                    this.ParametersField = value;
                    this.RaisePropertyChanged("Parameters");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public application.AppTypes.StrategyTypes Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string URL {
            get {
                return this.URLField;
            }
            set {
                if ((object.ReferenceEquals(this.URLField, value) != true)) {
                    this.URLField = value;
                    this.RaisePropertyChanged("URL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Version {
            get {
                return this.VersionField;
            }
            set {
                if ((object.ReferenceEquals(this.VersionField, value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InternalCache", Namespace="http://schemas.datacontract.org/2004/07/System.Reflection.Cache")]
    [System.SerializableAttribute()]
    public partial class InternalCache : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private wsTest.ServiceReference2.InternalCacheItem[] m_cacheField;
        
        private int m_numItemsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public wsTest.ServiceReference2.InternalCacheItem[] m_cache {
            get {
                return this.m_cacheField;
            }
            set {
                if ((object.ReferenceEquals(this.m_cacheField, value) != true)) {
                    this.m_cacheField = value;
                    this.RaisePropertyChanged("m_cache");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int m_numItems {
            get {
                return this.m_numItemsField;
            }
            set {
                if ((this.m_numItemsField.Equals(value) != true)) {
                    this.m_numItemsField = value;
                    this.RaisePropertyChanged("m_numItems");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InternalCacheItem", Namespace="http://schemas.datacontract.org/2004/07/System.Reflection.Cache")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.InternalCache))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.InternalCacheItem[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.CacheObjType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(double[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.CompositeType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(common.DictionaryList))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(application.AppTypes.StrategyTypes))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Reflection.MemberInfo))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(wsTest.ServiceReference2.Meta))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Type))]
    public partial struct InternalCacheItem : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private wsTest.ServiceReference2.CacheObjType KeyField;
        
        private object ValueField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public wsTest.ServiceReference2.CacheObjType Key {
            get {
                return this.KeyField;
            }
            set {
                if ((this.KeyField.Equals(value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public object Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CacheObjType", Namespace="http://schemas.datacontract.org/2004/07/System.Reflection.Cache")]
    public enum CacheObjType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        EmptyElement = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ParameterInfo = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TypeName = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RemotingData = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SerializableAttribute = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AssemblyName = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ConstructorInfo = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FieldType = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FieldName = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DefaultMember = 9,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary1")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/test", ReplyAction="http://tempuri.org/IService1/testResponse")]
        wsTest.ServiceReference2.Meta test();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        wsTest.ServiceReference2.CompositeType GetDataUsingDataContract(wsTest.ServiceReference2.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IService1Channel : wsTest.ServiceReference2.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<wsTest.ServiceReference2.IService1>, wsTest.ServiceReference2.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public wsTest.ServiceReference2.Meta test() {
            return base.Channel.test();
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public wsTest.ServiceReference2.CompositeType GetDataUsingDataContract(wsTest.ServiceReference2.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
    }
}
