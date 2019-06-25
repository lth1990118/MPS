

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV", Namespace = "http://www.UFIDA.org", ConfigurationName = "UFIDAU9CustKukaMPSMPSSVICreatePOSV")]
public interface UFIDAU9CustKukaMPSMPSSVICreatePOSV
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/DoResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/DoServiceLostExcept" +
        "ionFault", Name = "ServiceLostException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/DoServiceExceptionF" +
        "ault", Name = "ServiceException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/DoServiceExceptionD" +
        "etailFault", Name = "ServiceExceptionDetail", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/DoExceptionBaseFaul" +
        "t", Name = "ExceptionBase", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
    [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/DoExceptionFault", Name = "Exception", Namespace = "http://schemas.datacontract.org/2004/07/System")]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.BusinessException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttrsContainerException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttributeInValidException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.EntityNotExistException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.PL.Engine.ObjectState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase.FormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorDescriptor))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorLevel))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.UnknownException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangDataDict))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangData[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangData))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ApplicationContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.PlatformContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ThreadContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.DataRowState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPODataData))]
    DoResponse Do(DoRequest request);

    // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
    [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.MPS.MPSSV.ICreatePOSV/DoResponse")]
    System.Threading.Tasks.Task<DoResponse> DoAsync(DoRequest request);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface UFIDAU9CustKukaMPSMPSSVICreatePOSVChannel : UFIDAU9CustKukaMPSMPSSVICreatePOSV, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class UFIDAU9CustKukaMPSMPSSVICreatePOSVClient : System.ServiceModel.ClientBase<UFIDAU9CustKukaMPSMPSSVICreatePOSV>, UFIDAU9CustKukaMPSMPSSVICreatePOSV
{

    public UFIDAU9CustKukaMPSMPSSVICreatePOSVClient()
    {
    }

    public UFIDAU9CustKukaMPSMPSSVICreatePOSVClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public UFIDAU9CustKukaMPSMPSSVICreatePOSVClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public UFIDAU9CustKukaMPSMPSSVICreatePOSVClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public UFIDAU9CustKukaMPSMPSSVICreatePOSVClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {
    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DoResponse UFIDAU9CustKukaMPSMPSSVICreatePOSV.Do(DoRequest request)
    {
        return base.Channel.Do(request);
    }

    public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPODataData Do(object context, www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData createPOSVDTO, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages)
    {
        DoRequest inValue = new DoRequest();
        inValue.context = context;
        inValue.createPOSVDTO = createPOSVDTO;
        DoResponse retVal = ((UFIDAU9CustKukaMPSMPSSVICreatePOSV)(this)).Do(inValue);
        outMessages = retVal.outMessages;
        return retVal.DoResult;
    }

    public System.Threading.Tasks.Task<DoResponse> DoAsync(DoRequest request)
    {
        return base.Channel.DoAsync(request);
    }
}