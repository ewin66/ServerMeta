﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.269
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码由 wsdl 自动生成, Version=4.0.30319.1。
// 
namespace HPHGCtaService {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="HPHGCtaServiceSoap", Namespace="http://tempuri.org/")]
    public partial class HPHGCtaService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback UpdateEntryHeadStatusOperationCompleted;
        
        /// <remarks/>
        public HPHGCtaService() {
            this.Url = "http://10.56.215.145/cta/WebServices/HPHGCtaService.asmx";
        }
        
        /// <remarks/>
        public event UpdateEntryHeadStatusCompletedEventHandler UpdateEntryHeadStatusCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateEntryHeadStatus", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string UpdateEntryHeadStatus(string caseNumber) {
            object[] results = this.Invoke("UpdateEntryHeadStatus", new object[] {
                        caseNumber});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateEntryHeadStatus(string caseNumber, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateEntryHeadStatus", new object[] {
                        caseNumber}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndUpdateEntryHeadStatus(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateEntryHeadStatusAsync(string caseNumber) {
            this.UpdateEntryHeadStatusAsync(caseNumber, null);
        }
        
        /// <remarks/>
        public void UpdateEntryHeadStatusAsync(string caseNumber, object userState) {
            if ((this.UpdateEntryHeadStatusOperationCompleted == null)) {
                this.UpdateEntryHeadStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateEntryHeadStatusOperationCompleted);
            }
            this.InvokeAsync("UpdateEntryHeadStatus", new object[] {
                        caseNumber}, this.UpdateEntryHeadStatusOperationCompleted, userState);
        }
        
        private void OnUpdateEntryHeadStatusOperationCompleted(object arg) {
            if ((this.UpdateEntryHeadStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateEntryHeadStatusCompleted(this, new UpdateEntryHeadStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void UpdateEntryHeadStatusCompletedEventHandler(object sender, UpdateEntryHeadStatusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateEntryHeadStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateEntryHeadStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}