﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsultasERP.IWSDLPublish {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IWSDLPublish.IWSDLPublish")]
    public interface IWSDLPublish {
        
        // CODEGEN: Gerando contrato de mensagem porque o namespace do conteúdo (http://www.borland.com/namespaces/Types) da mensagem GetPortTypeListRequest não corresponde ao valor padrão (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.borland.com/namespaces/Types-IWSDLPublish", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        ConsultasERP.IWSDLPublish.GetPortTypeListResponse GetPortTypeList(ConsultasERP.IWSDLPublish.GetPortTypeListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.borland.com/namespaces/Types-IWSDLPublish", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetPortTypeListResponse> GetPortTypeListAsync(ConsultasERP.IWSDLPublish.GetPortTypeListRequest request);
        
        // CODEGEN: Gerando contrato de mensagem porque o namespace do conteúdo (http://www.borland.com/namespaces/Types) da mensagem GetWSDLForPortTypeRequest não corresponde ao valor padrão (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.borland.com/namespaces/Types-IWSDLPublish", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        ConsultasERP.IWSDLPublish.GetWSDLForPortTypeResponse GetWSDLForPortType(ConsultasERP.IWSDLPublish.GetWSDLForPortTypeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.borland.com/namespaces/Types-IWSDLPublish", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetWSDLForPortTypeResponse> GetWSDLForPortTypeAsync(ConsultasERP.IWSDLPublish.GetWSDLForPortTypeRequest request);
        
        // CODEGEN: Gerando contrato de mensagem porque o namespace do conteúdo (http://www.borland.com/namespaces/Types) da mensagem GetTypeSystemsListRequest não corresponde ao valor padrão (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.borland.com/namespaces/Types-IWSDLPublish", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        ConsultasERP.IWSDLPublish.GetTypeSystemsListResponse GetTypeSystemsList(ConsultasERP.IWSDLPublish.GetTypeSystemsListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.borland.com/namespaces/Types-IWSDLPublish", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetTypeSystemsListResponse> GetTypeSystemsListAsync(ConsultasERP.IWSDLPublish.GetTypeSystemsListRequest request);
        
        // CODEGEN: Gerando contrato de mensagem porque o namespace do conteúdo (http://www.borland.com/namespaces/Types) da mensagem GetXSDForTypeSystemRequest não corresponde ao valor padrão (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.borland.com/namespaces/Types-IWSDLPublish", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        ConsultasERP.IWSDLPublish.GetXSDForTypeSystemResponse GetXSDForTypeSystem(ConsultasERP.IWSDLPublish.GetXSDForTypeSystemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.borland.com/namespaces/Types-IWSDLPublish", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetXSDForTypeSystemResponse> GetXSDForTypeSystemAsync(ConsultasERP.IWSDLPublish.GetXSDForTypeSystemRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetPortTypeList", WrapperNamespace="http://www.borland.com/namespaces/Types", IsWrapped=true)]
    public partial class GetPortTypeListRequest {
        
        public GetPortTypeListRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetPortTypeListResponse", WrapperNamespace="http://www.borland.com/namespaces/Types", IsWrapped=true)]
    public partial class GetPortTypeListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string[] @return;
        
        public GetPortTypeListResponse() {
        }
        
        public GetPortTypeListResponse(string[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetWSDLForPortType", WrapperNamespace="http://www.borland.com/namespaces/Types", IsWrapped=true)]
    public partial class GetWSDLForPortTypeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string PortType;
        
        public GetWSDLForPortTypeRequest() {
        }
        
        public GetWSDLForPortTypeRequest(string PortType) {
            this.PortType = PortType;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetWSDLForPortTypeResponse", WrapperNamespace="http://www.borland.com/namespaces/Types", IsWrapped=true)]
    public partial class GetWSDLForPortTypeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string @return;
        
        public GetWSDLForPortTypeResponse() {
        }
        
        public GetWSDLForPortTypeResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTypeSystemsList", WrapperNamespace="http://www.borland.com/namespaces/Types", IsWrapped=true)]
    public partial class GetTypeSystemsListRequest {
        
        public GetTypeSystemsListRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTypeSystemsListResponse", WrapperNamespace="http://www.borland.com/namespaces/Types", IsWrapped=true)]
    public partial class GetTypeSystemsListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string[] @return;
        
        public GetTypeSystemsListResponse() {
        }
        
        public GetTypeSystemsListResponse(string[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetXSDForTypeSystem", WrapperNamespace="http://www.borland.com/namespaces/Types", IsWrapped=true)]
    public partial class GetXSDForTypeSystemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string TypeSystem;
        
        public GetXSDForTypeSystemRequest() {
        }
        
        public GetXSDForTypeSystemRequest(string TypeSystem) {
            this.TypeSystem = TypeSystem;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetXSDForTypeSystemResponse", WrapperNamespace="http://www.borland.com/namespaces/Types", IsWrapped=true)]
    public partial class GetXSDForTypeSystemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string @return;
        
        public GetXSDForTypeSystemResponse() {
        }
        
        public GetXSDForTypeSystemResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWSDLPublishChannel : ConsultasERP.IWSDLPublish.IWSDLPublish, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSDLPublishClient : System.ServiceModel.ClientBase<ConsultasERP.IWSDLPublish.IWSDLPublish>, ConsultasERP.IWSDLPublish.IWSDLPublish {
        
        public WSDLPublishClient() {
        }
        
        public WSDLPublishClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSDLPublishClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSDLPublishClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSDLPublishClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsultasERP.IWSDLPublish.GetPortTypeListResponse ConsultasERP.IWSDLPublish.IWSDLPublish.GetPortTypeList(ConsultasERP.IWSDLPublish.GetPortTypeListRequest request) {
            return base.Channel.GetPortTypeList(request);
        }
        
        public string[] GetPortTypeList() {
            ConsultasERP.IWSDLPublish.GetPortTypeListRequest inValue = new ConsultasERP.IWSDLPublish.GetPortTypeListRequest();
            ConsultasERP.IWSDLPublish.GetPortTypeListResponse retVal = ((ConsultasERP.IWSDLPublish.IWSDLPublish)(this)).GetPortTypeList(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetPortTypeListResponse> ConsultasERP.IWSDLPublish.IWSDLPublish.GetPortTypeListAsync(ConsultasERP.IWSDLPublish.GetPortTypeListRequest request) {
            return base.Channel.GetPortTypeListAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetPortTypeListResponse> GetPortTypeListAsync() {
            ConsultasERP.IWSDLPublish.GetPortTypeListRequest inValue = new ConsultasERP.IWSDLPublish.GetPortTypeListRequest();
            return ((ConsultasERP.IWSDLPublish.IWSDLPublish)(this)).GetPortTypeListAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsultasERP.IWSDLPublish.GetWSDLForPortTypeResponse ConsultasERP.IWSDLPublish.IWSDLPublish.GetWSDLForPortType(ConsultasERP.IWSDLPublish.GetWSDLForPortTypeRequest request) {
            return base.Channel.GetWSDLForPortType(request);
        }
        
        public string GetWSDLForPortType(string PortType) {
            ConsultasERP.IWSDLPublish.GetWSDLForPortTypeRequest inValue = new ConsultasERP.IWSDLPublish.GetWSDLForPortTypeRequest();
            inValue.PortType = PortType;
            ConsultasERP.IWSDLPublish.GetWSDLForPortTypeResponse retVal = ((ConsultasERP.IWSDLPublish.IWSDLPublish)(this)).GetWSDLForPortType(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetWSDLForPortTypeResponse> ConsultasERP.IWSDLPublish.IWSDLPublish.GetWSDLForPortTypeAsync(ConsultasERP.IWSDLPublish.GetWSDLForPortTypeRequest request) {
            return base.Channel.GetWSDLForPortTypeAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetWSDLForPortTypeResponse> GetWSDLForPortTypeAsync(string PortType) {
            ConsultasERP.IWSDLPublish.GetWSDLForPortTypeRequest inValue = new ConsultasERP.IWSDLPublish.GetWSDLForPortTypeRequest();
            inValue.PortType = PortType;
            return ((ConsultasERP.IWSDLPublish.IWSDLPublish)(this)).GetWSDLForPortTypeAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsultasERP.IWSDLPublish.GetTypeSystemsListResponse ConsultasERP.IWSDLPublish.IWSDLPublish.GetTypeSystemsList(ConsultasERP.IWSDLPublish.GetTypeSystemsListRequest request) {
            return base.Channel.GetTypeSystemsList(request);
        }
        
        public string[] GetTypeSystemsList() {
            ConsultasERP.IWSDLPublish.GetTypeSystemsListRequest inValue = new ConsultasERP.IWSDLPublish.GetTypeSystemsListRequest();
            ConsultasERP.IWSDLPublish.GetTypeSystemsListResponse retVal = ((ConsultasERP.IWSDLPublish.IWSDLPublish)(this)).GetTypeSystemsList(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetTypeSystemsListResponse> ConsultasERP.IWSDLPublish.IWSDLPublish.GetTypeSystemsListAsync(ConsultasERP.IWSDLPublish.GetTypeSystemsListRequest request) {
            return base.Channel.GetTypeSystemsListAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetTypeSystemsListResponse> GetTypeSystemsListAsync() {
            ConsultasERP.IWSDLPublish.GetTypeSystemsListRequest inValue = new ConsultasERP.IWSDLPublish.GetTypeSystemsListRequest();
            return ((ConsultasERP.IWSDLPublish.IWSDLPublish)(this)).GetTypeSystemsListAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsultasERP.IWSDLPublish.GetXSDForTypeSystemResponse ConsultasERP.IWSDLPublish.IWSDLPublish.GetXSDForTypeSystem(ConsultasERP.IWSDLPublish.GetXSDForTypeSystemRequest request) {
            return base.Channel.GetXSDForTypeSystem(request);
        }
        
        public string GetXSDForTypeSystem(string TypeSystem) {
            ConsultasERP.IWSDLPublish.GetXSDForTypeSystemRequest inValue = new ConsultasERP.IWSDLPublish.GetXSDForTypeSystemRequest();
            inValue.TypeSystem = TypeSystem;
            ConsultasERP.IWSDLPublish.GetXSDForTypeSystemResponse retVal = ((ConsultasERP.IWSDLPublish.IWSDLPublish)(this)).GetXSDForTypeSystem(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetXSDForTypeSystemResponse> ConsultasERP.IWSDLPublish.IWSDLPublish.GetXSDForTypeSystemAsync(ConsultasERP.IWSDLPublish.GetXSDForTypeSystemRequest request) {
            return base.Channel.GetXSDForTypeSystemAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsultasERP.IWSDLPublish.GetXSDForTypeSystemResponse> GetXSDForTypeSystemAsync(string TypeSystem) {
            ConsultasERP.IWSDLPublish.GetXSDForTypeSystemRequest inValue = new ConsultasERP.IWSDLPublish.GetXSDForTypeSystemRequest();
            inValue.TypeSystem = TypeSystem;
            return ((ConsultasERP.IWSDLPublish.IWSDLPublish)(this)).GetXSDForTypeSystemAsync(inValue);
        }
    }
}