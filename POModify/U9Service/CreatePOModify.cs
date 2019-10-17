
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv", Namespace = "http://www.UFIDA.org", ConfigurationName = "UFIDAU9CustKukaMPSMPSSVICreatePOModifySv")]
public interface UFIDAU9CustKukaMPSMPSSVICreatePOModifySv
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/DoResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/DoServiceLost" +
        "ExceptionFault", Name = "ServiceLostException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/DoServiceExce" +
        "ptionFault", Name = "ServiceException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/DoServiceExce" +
        "ptionDetailFault", Name = "ServiceExceptionDetail", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/DoExceptionBa" +
        "seFault", Name = "ExceptionBase", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
    [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/DoExceptionFa" +
        "ult", Name = "Exception", Namespace = "http://schemas.datacontract.org/2004/07/System")]
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
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase.FormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorDescriptor))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorLevel))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.UnknownException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyDTOData))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVIDCodeNameData))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.DataRowState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.PL.Engine.ObjectState))]
    DoResponse Do(DoRequest request);

    // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
    [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOModifySv/DoResponse")]
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
    public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyDTOData createPOModifyDTO;

    public DoRequest()
    {
    }

    public DoRequest(object context, www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyDTOData createPOModifyDTO)
    {
        this.context = context;
        this.createPOModifyDTO = createPOModifyDTO;
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
public interface UFIDAU9CustKukaMPSMPSSVICreatePOModifySvChannel : UFIDAU9CustKukaMPSMPSSVICreatePOModifySv, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class UFIDAU9CustKukaMPSMPSSVICreatePOModifySvClient : System.ServiceModel.ClientBase<UFIDAU9CustKukaMPSMPSSVICreatePOModifySv>, UFIDAU9CustKukaMPSMPSSVICreatePOModifySv
{

    public UFIDAU9CustKukaMPSMPSSVICreatePOModifySvClient()
    {
    }

    public UFIDAU9CustKukaMPSMPSSVICreatePOModifySvClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public UFIDAU9CustKukaMPSMPSSVICreatePOModifySvClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public UFIDAU9CustKukaMPSMPSSVICreatePOModifySvClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public UFIDAU9CustKukaMPSMPSSVICreatePOModifySvClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {
    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DoResponse UFIDAU9CustKukaMPSMPSSVICreatePOModifySv.Do(DoRequest request)
    {
        return base.Channel.Do(request);
    }

    public string Do(object context, www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyDTOData createPOModifyDTO, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages)
    {
        DoRequest inValue = new DoRequest();
        inValue.context = context;
        inValue.createPOModifyDTO = createPOModifyDTO;
        DoResponse retVal = ((UFIDAU9CustKukaMPSMPSSVICreatePOModifySv)(this)).Do(inValue);
        outMessages = retVal.outMessages;
        return retVal.DoResult;
    }

    public System.Threading.Tasks.Task<DoResponse> DoAsync(DoRequest request)
    {
        return base.Channel.DoAsync(request);
    }
}
