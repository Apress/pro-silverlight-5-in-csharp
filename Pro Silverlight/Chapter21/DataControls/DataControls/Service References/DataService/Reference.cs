﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.60818.0
// 
namespace DataControls.DataService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="DataService.StoreDb")]
    public interface StoreDb {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:StoreDb/GetProduct", ReplyAction="urn:StoreDb/GetProductResponse")]
        System.IAsyncResult BeginGetProduct(int ID, System.AsyncCallback callback, object asyncState);
        
        StoreDbDataClasses.Product EndGetProduct(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:StoreDb/GetProducts", ReplyAction="urn:StoreDb/GetProductsResponse")]
        System.IAsyncResult BeginGetProducts(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Product> EndGetProducts(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:StoreDb/GetCategoriesWithProducts", ReplyAction="urn:StoreDb/GetCategoriesWithProductsResponse")]
        System.IAsyncResult BeginGetCategoriesWithProducts(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Category> EndGetCategoriesWithProducts(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface StoreDbChannel : DataControls.DataService.StoreDb, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetProductCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetProductCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public StoreDbDataClasses.Product Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((StoreDbDataClasses.Product)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetProductsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetProductsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Product> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Product>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetCategoriesWithProductsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetCategoriesWithProductsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Category> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Category>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StoreDbClient : System.ServiceModel.ClientBase<DataControls.DataService.StoreDb>, DataControls.DataService.StoreDb {
        
        private BeginOperationDelegate onBeginGetProductDelegate;
        
        private EndOperationDelegate onEndGetProductDelegate;
        
        private System.Threading.SendOrPostCallback onGetProductCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetProductsDelegate;
        
        private EndOperationDelegate onEndGetProductsDelegate;
        
        private System.Threading.SendOrPostCallback onGetProductsCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetCategoriesWithProductsDelegate;
        
        private EndOperationDelegate onEndGetCategoriesWithProductsDelegate;
        
        private System.Threading.SendOrPostCallback onGetCategoriesWithProductsCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public StoreDbClient() {
        }
        
        public StoreDbClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StoreDbClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StoreDbClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StoreDbClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetProductCompletedEventArgs> GetProductCompleted;
        
        public event System.EventHandler<GetProductsCompletedEventArgs> GetProductsCompleted;
        
        public event System.EventHandler<GetCategoriesWithProductsCompletedEventArgs> GetCategoriesWithProductsCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult DataControls.DataService.StoreDb.BeginGetProduct(int ID, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetProduct(ID, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        StoreDbDataClasses.Product DataControls.DataService.StoreDb.EndGetProduct(System.IAsyncResult result) {
            return base.Channel.EndGetProduct(result);
        }
        
        private System.IAsyncResult OnBeginGetProduct(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int ID = ((int)(inValues[0]));
            return ((DataControls.DataService.StoreDb)(this)).BeginGetProduct(ID, callback, asyncState);
        }
        
        private object[] OnEndGetProduct(System.IAsyncResult result) {
            StoreDbDataClasses.Product retVal = ((DataControls.DataService.StoreDb)(this)).EndGetProduct(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetProductCompleted(object state) {
            if ((this.GetProductCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetProductCompleted(this, new GetProductCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetProductAsync(int ID) {
            this.GetProductAsync(ID, null);
        }
        
        public void GetProductAsync(int ID, object userState) {
            if ((this.onBeginGetProductDelegate == null)) {
                this.onBeginGetProductDelegate = new BeginOperationDelegate(this.OnBeginGetProduct);
            }
            if ((this.onEndGetProductDelegate == null)) {
                this.onEndGetProductDelegate = new EndOperationDelegate(this.OnEndGetProduct);
            }
            if ((this.onGetProductCompletedDelegate == null)) {
                this.onGetProductCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetProductCompleted);
            }
            base.InvokeAsync(this.onBeginGetProductDelegate, new object[] {
                        ID}, this.onEndGetProductDelegate, this.onGetProductCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult DataControls.DataService.StoreDb.BeginGetProducts(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetProducts(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Product> DataControls.DataService.StoreDb.EndGetProducts(System.IAsyncResult result) {
            return base.Channel.EndGetProducts(result);
        }
        
        private System.IAsyncResult OnBeginGetProducts(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((DataControls.DataService.StoreDb)(this)).BeginGetProducts(callback, asyncState);
        }
        
        private object[] OnEndGetProducts(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Product> retVal = ((DataControls.DataService.StoreDb)(this)).EndGetProducts(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetProductsCompleted(object state) {
            if ((this.GetProductsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetProductsCompleted(this, new GetProductsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetProductsAsync() {
            this.GetProductsAsync(null);
        }
        
        public void GetProductsAsync(object userState) {
            if ((this.onBeginGetProductsDelegate == null)) {
                this.onBeginGetProductsDelegate = new BeginOperationDelegate(this.OnBeginGetProducts);
            }
            if ((this.onEndGetProductsDelegate == null)) {
                this.onEndGetProductsDelegate = new EndOperationDelegate(this.OnEndGetProducts);
            }
            if ((this.onGetProductsCompletedDelegate == null)) {
                this.onGetProductsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetProductsCompleted);
            }
            base.InvokeAsync(this.onBeginGetProductsDelegate, null, this.onEndGetProductsDelegate, this.onGetProductsCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult DataControls.DataService.StoreDb.BeginGetCategoriesWithProducts(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetCategoriesWithProducts(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Category> DataControls.DataService.StoreDb.EndGetCategoriesWithProducts(System.IAsyncResult result) {
            return base.Channel.EndGetCategoriesWithProducts(result);
        }
        
        private System.IAsyncResult OnBeginGetCategoriesWithProducts(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((DataControls.DataService.StoreDb)(this)).BeginGetCategoriesWithProducts(callback, asyncState);
        }
        
        private object[] OnEndGetCategoriesWithProducts(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Category> retVal = ((DataControls.DataService.StoreDb)(this)).EndGetCategoriesWithProducts(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetCategoriesWithProductsCompleted(object state) {
            if ((this.GetCategoriesWithProductsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetCategoriesWithProductsCompleted(this, new GetCategoriesWithProductsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetCategoriesWithProductsAsync() {
            this.GetCategoriesWithProductsAsync(null);
        }
        
        public void GetCategoriesWithProductsAsync(object userState) {
            if ((this.onBeginGetCategoriesWithProductsDelegate == null)) {
                this.onBeginGetCategoriesWithProductsDelegate = new BeginOperationDelegate(this.OnBeginGetCategoriesWithProducts);
            }
            if ((this.onEndGetCategoriesWithProductsDelegate == null)) {
                this.onEndGetCategoriesWithProductsDelegate = new EndOperationDelegate(this.OnEndGetCategoriesWithProducts);
            }
            if ((this.onGetCategoriesWithProductsCompletedDelegate == null)) {
                this.onGetCategoriesWithProductsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCategoriesWithProductsCompleted);
            }
            base.InvokeAsync(this.onBeginGetCategoriesWithProductsDelegate, null, this.onEndGetCategoriesWithProductsDelegate, this.onGetCategoriesWithProductsCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override DataControls.DataService.StoreDb CreateChannel() {
            return new StoreDbClientChannel(this);
        }
        
        private class StoreDbClientChannel : ChannelBase<DataControls.DataService.StoreDb>, DataControls.DataService.StoreDb {
            
            public StoreDbClientChannel(System.ServiceModel.ClientBase<DataControls.DataService.StoreDb> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetProduct(int ID, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = ID;
                System.IAsyncResult _result = base.BeginInvoke("GetProduct", _args, callback, asyncState);
                return _result;
            }
            
            public StoreDbDataClasses.Product EndGetProduct(System.IAsyncResult result) {
                object[] _args = new object[0];
                StoreDbDataClasses.Product _result = ((StoreDbDataClasses.Product)(base.EndInvoke("GetProduct", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetProducts(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("GetProducts", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Product> EndGetProducts(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Product> _result = ((System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Product>)(base.EndInvoke("GetProducts", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetCategoriesWithProducts(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("GetCategoriesWithProducts", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Category> EndGetCategoriesWithProducts(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Category> _result = ((System.Collections.ObjectModel.ObservableCollection<StoreDbDataClasses.Category>)(base.EndInvoke("GetCategoriesWithProducts", _args, result)));
                return _result;
            }
        }
    }
}