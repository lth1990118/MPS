namespace UFIDA.U9.Cust.Kuka.MPS.MPSSV.RtGoods2
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV", Namespace = "http://www.UFIDA.org", ConfigurationName = "UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV")]
    public interface UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoServiceLostE" +
            "xceptionFault", Name = "ServiceLostException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoServiceExcep" +
            "tionFault", Name = "ServiceException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoServiceExcep" +
            "tionDetailFault", Name = "ServiceExceptionDetail", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoExceptionBas" +
            "eFault", Name = "ExceptionBase", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoExceptionFau" +
            "lt", Name = "Exception", Namespace = "http://schemas.datacontract.org/2004/07/System")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase.FormatState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorDescriptor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorLevel))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.UnknownException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDocResultData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDocResultData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.DataRowState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.PL.Engine.ObjectState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangDataDict))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ApplicationContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.PlatformContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ThreadContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.BusinessException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttrsContainerException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttributeInValidException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.EntityNotExistException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
        DoResponse Do(DoRequest request);

        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoResponse")]
        System.Threading.Tasks.Task<DoResponse> DoAsync(DoRequest request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "Do", WrapperNamespace = "http://www.UFIDA.org", IsWrapped = true)]
    public partial class DoRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.UFIDA.org", Order = 0)]
        public object context;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.UFIDA.org", Order = 1)]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData[] createObj;

        public DoRequest()
        {
        }

        public DoRequest(object context, www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData[] createObj)
        {
            this.context = context;
            this.createObj = createObj;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DoResponse", WrapperNamespace = "http://www.UFIDA.org", IsWrapped = true)]
    public partial class DoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.UFIDA.org", Order = 0)]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDocResultData[] DoResult;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.UFIDA.org", Order = 1)]
        public UFSoft.UBF.Exceptions1.MessageBase[] outMessages;

        public DoResponse()
        {
        }

        public DoResponse(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDocResultData[] DoResult, UFSoft.UBF.Exceptions1.MessageBase[] outMessages)
        {
            this.DoResult = DoResult;
            this.outMessages = outMessages;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVChannel : UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient : System.ServiceModel.ClientBase<UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV>, UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV
    {

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient()
        {
        }

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DoResponse UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV.Do(DoRequest request)
        {
            return base.Channel.Do(request);
        }

        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDocResultData[] Do(object context, www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData[] createObj, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages)
        {
            DoRequest inValue = new DoRequest();
            inValue.context = context;
            inValue.createObj = createObj;
            DoResponse retVal = ((UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV)(this)).Do(inValue);
            outMessages = retVal.outMessages;
            return retVal.DoResult;
        }

        public System.Threading.Tasks.Task<DoResponse> DoAsync(DoRequest request)
        {
            return base.Channel.DoAsync(request);
        }
    }

}

namespace UFIDA.U9.Cust.Kuka.MPS.MPSSV.RtGoods1 {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV", Namespace = "http://www.UFIDA.org", ConfigurationName = "UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV")]
    public interface UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoServiceLostE" +
            "xceptionFault", Name = "ServiceLostException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoServiceExcep" +
            "tionFault", Name = "ServiceException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoExceptionFau" +
            "lt", Name = "Exception", Namespace = "http://schemas.datacontract.org/2004/07/System")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoServiceExcep" +
            "tionDetailFault", Name = "ServiceExceptionDetail", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoExceptionBas" +
            "eFault", Name = "ExceptionBase", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttrsContainerException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.BusinessException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttributeInValidException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.EntityNotExistException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangDataDict))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ApplicationContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ThreadContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.PlatformContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.DataRowState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.PL.Engine.ObjectState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase.FormatState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorDescriptor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorLevel))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.UnknownException))]
        DoResponse Do(DoRequest request);

        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreateRtGoodsSV/DoResponse")]
        System.Threading.Tasks.Task<DoResponse> DoAsync(DoRequest request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "Do", WrapperNamespace = "http://www.UFIDA.org", IsWrapped = true)]
    public partial class DoRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.UFIDA.org", Order = 0)]
        public object context;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.UFIDA.org", Order = 1)]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData createObj;

        public DoRequest()
        {
        }

        public DoRequest(object context, www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData createObj)
        {
            this.context = context;
            this.createObj = createObj;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DoResponse", WrapperNamespace = "http://www.UFIDA.org", IsWrapped = true)]
    public partial class DoResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.UFIDA.org", Order = 0)]
        public string DoResult;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.UFIDA.org", Order = 1)]
        public UFSoft.UBF.Exceptions1.MessageBase[] outMessages;

        public DoResponse()
        {
        }

        public DoResponse(string DoResult, UFSoft.UBF.Exceptions1.MessageBase[] outMessages)
        {
            this.DoResult = DoResult;
            this.outMessages = outMessages;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVChannel : UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient : System.ServiceModel.ClientBase<UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV>, UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV
    {

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient()
        {
        }

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DoResponse UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV.Do(DoRequest request)
        {
            return base.Channel.Do(request);
        }

        public string Do(object context, www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData createObj, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages)
        {
            DoRequest inValue = new DoRequest();
            inValue.context = context;
            inValue.createObj = createObj;
            DoResponse retVal = ((UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSV)(this)).Do(inValue);
            outMessages = retVal.outMessages;
            return retVal.DoResult;
        }

        public System.Threading.Tasks.Task<DoResponse> DoAsync(DoRequest request)
        {
            return base.Channel.DoAsync(request);
        }
    }

}