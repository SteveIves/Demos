﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CsTestClient.MyService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PersonIdField;
        
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
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PersonId {
            get {
                return this.PersonIdField;
            }
            set {
                if ((this.PersonIdField.Equals(value) != true)) {
                    this.PersonIdField = value;
                    this.RaisePropertyChanged("PersonId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyService.IMyService")]
    public interface IMyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddTwoNumbers", ReplyAction="http://tempuri.org/IMyService/AddTwoNumbersResponse")]
        int AddTwoNumbers(int firstNumber, int secondNumber);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMyService/AddTwoNumbers", ReplyAction="http://tempuri.org/IMyService/AddTwoNumbersResponse")]
        System.IAsyncResult BeginAddTwoNumbers(int firstNumber, int secondNumber, System.AsyncCallback callback, object asyncState);
        
        int EndAddTwoNumbers(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetPerson", ReplyAction="http://tempuri.org/IMyService/GetPersonResponse")]
        CsTestClient.MyService.Person GetPerson(int aPersonId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMyService/GetPerson", ReplyAction="http://tempuri.org/IMyService/GetPersonResponse")]
        System.IAsyncResult BeginGetPerson(int aPersonId, System.AsyncCallback callback, object asyncState);
        
        CsTestClient.MyService.Person EndGetPerson(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyServiceChannel : CsTestClient.MyService.IMyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddTwoNumbersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public AddTwoNumbersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetPersonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetPersonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public CsTestClient.MyService.Person Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((CsTestClient.MyService.Person)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyServiceClient : System.ServiceModel.ClientBase<CsTestClient.MyService.IMyService>, CsTestClient.MyService.IMyService {
        
        private BeginOperationDelegate onBeginAddTwoNumbersDelegate;
        
        private EndOperationDelegate onEndAddTwoNumbersDelegate;
        
        private System.Threading.SendOrPostCallback onAddTwoNumbersCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetPersonDelegate;
        
        private EndOperationDelegate onEndGetPersonDelegate;
        
        private System.Threading.SendOrPostCallback onGetPersonCompletedDelegate;
        
        public MyServiceClient() {
        }
        
        public MyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<AddTwoNumbersCompletedEventArgs> AddTwoNumbersCompleted;
        
        public event System.EventHandler<GetPersonCompletedEventArgs> GetPersonCompleted;
        
        public int AddTwoNumbers(int firstNumber, int secondNumber) {
            return base.Channel.AddTwoNumbers(firstNumber, secondNumber);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginAddTwoNumbers(int firstNumber, int secondNumber, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginAddTwoNumbers(firstNumber, secondNumber, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public int EndAddTwoNumbers(System.IAsyncResult result) {
            return base.Channel.EndAddTwoNumbers(result);
        }
        
        private System.IAsyncResult OnBeginAddTwoNumbers(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int firstNumber = ((int)(inValues[0]));
            int secondNumber = ((int)(inValues[1]));
            return this.BeginAddTwoNumbers(firstNumber, secondNumber, callback, asyncState);
        }
        
        private object[] OnEndAddTwoNumbers(System.IAsyncResult result) {
            int retVal = this.EndAddTwoNumbers(result);
            return new object[] {
                    retVal};
        }
        
        private void OnAddTwoNumbersCompleted(object state) {
            if ((this.AddTwoNumbersCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddTwoNumbersCompleted(this, new AddTwoNumbersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void AddTwoNumbersAsync(int firstNumber, int secondNumber) {
            this.AddTwoNumbersAsync(firstNumber, secondNumber, null);
        }
        
        public void AddTwoNumbersAsync(int firstNumber, int secondNumber, object userState) {
            if ((this.onBeginAddTwoNumbersDelegate == null)) {
                this.onBeginAddTwoNumbersDelegate = new BeginOperationDelegate(this.OnBeginAddTwoNumbers);
            }
            if ((this.onEndAddTwoNumbersDelegate == null)) {
                this.onEndAddTwoNumbersDelegate = new EndOperationDelegate(this.OnEndAddTwoNumbers);
            }
            if ((this.onAddTwoNumbersCompletedDelegate == null)) {
                this.onAddTwoNumbersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddTwoNumbersCompleted);
            }
            base.InvokeAsync(this.onBeginAddTwoNumbersDelegate, new object[] {
                        firstNumber,
                        secondNumber}, this.onEndAddTwoNumbersDelegate, this.onAddTwoNumbersCompletedDelegate, userState);
        }
        
        public CsTestClient.MyService.Person GetPerson(int aPersonId) {
            return base.Channel.GetPerson(aPersonId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetPerson(int aPersonId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetPerson(aPersonId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public CsTestClient.MyService.Person EndGetPerson(System.IAsyncResult result) {
            return base.Channel.EndGetPerson(result);
        }
        
        private System.IAsyncResult OnBeginGetPerson(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int aPersonId = ((int)(inValues[0]));
            return this.BeginGetPerson(aPersonId, callback, asyncState);
        }
        
        private object[] OnEndGetPerson(System.IAsyncResult result) {
            CsTestClient.MyService.Person retVal = this.EndGetPerson(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetPersonCompleted(object state) {
            if ((this.GetPersonCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetPersonCompleted(this, new GetPersonCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetPersonAsync(int aPersonId) {
            this.GetPersonAsync(aPersonId, null);
        }
        
        public void GetPersonAsync(int aPersonId, object userState) {
            if ((this.onBeginGetPersonDelegate == null)) {
                this.onBeginGetPersonDelegate = new BeginOperationDelegate(this.OnBeginGetPerson);
            }
            if ((this.onEndGetPersonDelegate == null)) {
                this.onEndGetPersonDelegate = new EndOperationDelegate(this.OnEndGetPerson);
            }
            if ((this.onGetPersonCompletedDelegate == null)) {
                this.onGetPersonCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetPersonCompleted);
            }
            base.InvokeAsync(this.onBeginGetPersonDelegate, new object[] {
                        aPersonId}, this.onEndGetPersonDelegate, this.onGetPersonCompletedDelegate, userState);
        }
    }
}