﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Luna_interpreter.WoLaService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Field", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.CheckBoxField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.ComputedField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.DateField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.ImageField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.IntegerField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.LabelField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.PictureField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.RadioButtonField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.RealField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.SelectField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.TextField))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Luna_interpreter.WoLaService.TimeField))]
    public partial class Field : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CaptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DefaultValueAsStringField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SectionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueAsStringField;
        
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
        public string Caption {
            get {
                return this.CaptionField;
            }
            set {
                if ((object.ReferenceEquals(this.CaptionField, value) != true)) {
                    this.CaptionField = value;
                    this.RaisePropertyChanged("Caption");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DefaultValueAsString {
            get {
                return this.DefaultValueAsStringField;
            }
            set {
                if ((object.ReferenceEquals(this.DefaultValueAsStringField, value) != true)) {
                    this.DefaultValueAsStringField = value;
                    this.RaisePropertyChanged("DefaultValueAsString");
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Index {
            get {
                return this.IndexField;
            }
            set {
                if ((this.IndexField.Equals(value) != true)) {
                    this.IndexField = value;
                    this.RaisePropertyChanged("Index");
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
        public int SectionId {
            get {
                return this.SectionIdField;
            }
            set {
                if ((this.SectionIdField.Equals(value) != true)) {
                    this.SectionIdField = value;
                    this.RaisePropertyChanged("SectionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ValueAsString {
            get {
                return this.ValueAsStringField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueAsStringField, value) != true)) {
                    this.ValueAsStringField = value;
                    this.RaisePropertyChanged("ValueAsString");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CheckBoxField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class CheckBoxField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DefaultValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool DefaultValue {
            get {
                return this.DefaultValueField;
            }
            set {
                if ((this.DefaultValueField.Equals(value) != true)) {
                    this.DefaultValueField = value;
                    this.RaisePropertyChanged("DefaultValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ComputedField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class ComputedField : Luna_interpreter.WoLaService.Field {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DateField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class DateField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DefaultValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DefaultValue {
            get {
                return this.DefaultValueField;
            }
            set {
                if ((this.DefaultValueField.Equals(value) != true)) {
                    this.DefaultValueField = value;
                    this.RaisePropertyChanged("DefaultValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImageField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class ImageField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Value {
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="IntegerField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class IntegerField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DefaultValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DefaultValue {
            get {
                return this.DefaultValueField;
            }
            set {
                if ((this.DefaultValueField.Equals(value) != true)) {
                    this.DefaultValueField = value;
                    this.RaisePropertyChanged("DefaultValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LabelField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class LabelField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PictureField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class PictureField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Value {
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RadioButtonField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class RadioButtonField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DefaultValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DefaultValue {
            get {
                return this.DefaultValueField;
            }
            set {
                if ((object.ReferenceEquals(this.DefaultValueField, value) != true)) {
                    this.DefaultValueField = value;
                    this.RaisePropertyChanged("DefaultValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RealField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class RealField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double DefaultValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double DefaultValue {
            get {
                return this.DefaultValueField;
            }
            set {
                if ((this.DefaultValueField.Equals(value) != true)) {
                    this.DefaultValueField = value;
                    this.RaisePropertyChanged("DefaultValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SelectField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class SelectField : Luna_interpreter.WoLaService.Field {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TextField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class TextField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DefaultValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DefaultValue {
            get {
                return this.DefaultValueField;
            }
            set {
                if ((object.ReferenceEquals(this.DefaultValueField, value) != true)) {
                    this.DefaultValueField = value;
                    this.RaisePropertyChanged("DefaultValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TimeField", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa.Fields")]
    [System.SerializableAttribute()]
    public partial class TimeField : Luna_interpreter.WoLaService.Field {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DefaultValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DefaultValue {
            get {
                return this.DefaultValueField;
            }
            set {
                if ((this.DefaultValueField.Equals(value) != true)) {
                    this.DefaultValueField = value;
                    this.RaisePropertyChanged("DefaultValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BasicFault", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa")]
    [System.SerializableAttribute()]
    public partial class BasicFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://wfe.mik.uni-pannon.hu/", ConfigurationName="WoLaService.IWoLaService")]
    public interface IWoLaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldById", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Luna_interpreter.WoLaService.BasicFault), Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldByIdBasicFaultFault", Name="BasicFault", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa")]
        Luna_interpreter.WoLaService.Field GetFieldById(int id, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldById", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldByIdResponse")]
        System.Threading.Tasks.Task<Luna_interpreter.WoLaService.Field> GetFieldByIdAsync(int id, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/SetFieldValueById", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/SetFieldValueByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Luna_interpreter.WoLaService.BasicFault), Action="http://wfe.mik.uni-pannon.hu/IWoLaService/SetFieldValueByIdBasicFaultFault", Name="BasicFault", Namespace="http://schemas.datacontract.org/2004/07/FlowService.WoLa")]
        void SetFieldValueById(int id, string value, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/SetFieldValueById", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/SetFieldValueByIdResponse")]
        System.Threading.Tasks.Task SetFieldValueByIdAsync(int id, string value, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldValue", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldValueResponse")]
        string GetFieldValue(string documentName, string fieldName, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldValue", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldValueResponse")]
        System.Threading.Tasks.Task<string> GetFieldValueAsync(string documentName, string fieldName, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetDocumentId", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetDocumentIdResponse")]
        int GetDocumentId(string name, int processId, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetDocumentId", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetDocumentIdResponse")]
        System.Threading.Tasks.Task<int> GetDocumentIdAsync(string name, int processId, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetSectionId", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetSectionIdResponse")]
        int GetSectionId(string name, int documentId, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetSectionId", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetSectionIdResponse")]
        System.Threading.Tasks.Task<int> GetSectionIdAsync(string name, int documentId, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldId", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldIdResponse")]
        int GetFieldId(string name, int sectionId, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldId", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldIdResponse")]
        System.Threading.Tasks.Task<int> GetFieldIdAsync(string name, int sectionId, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldIdByNameAndDocumentId", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldIdByNameAndDocumentIdResponse")]
        int GetFieldIdByNameAndDocumentId(string name, int documentId, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldIdByNameAndDocumentId", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldIdByNameAndDocumentIdResponse")]
        System.Threading.Tasks.Task<int> GetFieldIdByNameAndDocumentIdAsync(string name, int documentId, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldValueByProccessInstace", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldValueByProccessInstaceResponse")]
        string GetFieldValueByProccessInstace(int processInstanceId, string documentName, string sectionName, string fieldName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldValueByProccessInstace", ReplyAction="http://wfe.mik.uni-pannon.hu/IWoLaService/GetFieldValueByProccessInstaceResponse")]
        System.Threading.Tasks.Task<string> GetFieldValueByProccessInstaceAsync(int processInstanceId, string documentName, string sectionName, string fieldName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWoLaServiceChannel : Luna_interpreter.WoLaService.IWoLaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WoLaServiceClient : System.ServiceModel.ClientBase<Luna_interpreter.WoLaService.IWoLaService>, Luna_interpreter.WoLaService.IWoLaService {
        
        public WoLaServiceClient() {
        }
        
        public WoLaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WoLaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WoLaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WoLaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Luna_interpreter.WoLaService.Field GetFieldById(int id, string guid) {
            return base.Channel.GetFieldById(id, guid);
        }
        
        public System.Threading.Tasks.Task<Luna_interpreter.WoLaService.Field> GetFieldByIdAsync(int id, string guid) {
            return base.Channel.GetFieldByIdAsync(id, guid);
        }
        
        public void SetFieldValueById(int id, string value, string guid) {
            base.Channel.SetFieldValueById(id, value, guid);
        }
        
        public System.Threading.Tasks.Task SetFieldValueByIdAsync(int id, string value, string guid) {
            return base.Channel.SetFieldValueByIdAsync(id, value, guid);
        }
        
        public string GetFieldValue(string documentName, string fieldName, string guid) {
            return base.Channel.GetFieldValue(documentName, fieldName, guid);
        }
        
        public System.Threading.Tasks.Task<string> GetFieldValueAsync(string documentName, string fieldName, string guid) {
            return base.Channel.GetFieldValueAsync(documentName, fieldName, guid);
        }
        
        public int GetDocumentId(string name, int processId, string guid) {
            return base.Channel.GetDocumentId(name, processId, guid);
        }
        
        public System.Threading.Tasks.Task<int> GetDocumentIdAsync(string name, int processId, string guid) {
            return base.Channel.GetDocumentIdAsync(name, processId, guid);
        }
        
        public int GetSectionId(string name, int documentId, string guid) {
            return base.Channel.GetSectionId(name, documentId, guid);
        }
        
        public System.Threading.Tasks.Task<int> GetSectionIdAsync(string name, int documentId, string guid) {
            return base.Channel.GetSectionIdAsync(name, documentId, guid);
        }
        
        public int GetFieldId(string name, int sectionId, string guid) {
            return base.Channel.GetFieldId(name, sectionId, guid);
        }
        
        public System.Threading.Tasks.Task<int> GetFieldIdAsync(string name, int sectionId, string guid) {
            return base.Channel.GetFieldIdAsync(name, sectionId, guid);
        }
        
        public int GetFieldIdByNameAndDocumentId(string name, int documentId, string guid) {
            return base.Channel.GetFieldIdByNameAndDocumentId(name, documentId, guid);
        }
        
        public System.Threading.Tasks.Task<int> GetFieldIdByNameAndDocumentIdAsync(string name, int documentId, string guid) {
            return base.Channel.GetFieldIdByNameAndDocumentIdAsync(name, documentId, guid);
        }
        
        public string GetFieldValueByProccessInstace(int processInstanceId, string documentName, string sectionName, string fieldName) {
            return base.Channel.GetFieldValueByProccessInstace(processInstanceId, documentName, sectionName, fieldName);
        }
        
        public System.Threading.Tasks.Task<string> GetFieldValueByProccessInstaceAsync(int processInstanceId, string documentName, string sectionName, string fieldName) {
            return base.Channel.GetFieldValueByProccessInstaceAsync(processInstanceId, documentName, sectionName, fieldName);
        }
    }
}
