using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Bussiness.U9Service
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Name = "UFIDA.U9.Cust.Kuka.BS.BSSV.IPubSPOperateionSV", Namespace = "http://www.UFIDA.org", ConfigurationName = "UFIDAU9CustKukaBSBSSVIPubSPOperateionSV")]
    public interface UFIDAU9CustKukaBSBSSVIPubSPOperateionSV
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.BS.BSSV.IPubSPOperateionSV/Do", ReplyAction = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.BS.BSSV.IPubSPOperateionSV/DoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.BS.BSSV.IPubSPOperateionSV/DoServiceLostE" +
            "xceptionFault", Name = "ServiceLostException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.BS.BSSV.IPubSPOperateionSV/DoServiceExcep" +
            "tionFault", Name = "ServiceException", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.BS.BSSV.IPubSPOperateionSV/DoServiceExcep" +
            "tionDetailFault", Name = "ServiceExceptionDetail", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
        [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.BS.BSSV.IPubSPOperateionSV/DoExceptionBas" +
            "eFault", Name = "ExceptionBase", Namespace = "http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action = "http://www.UFIDA.org/UFIDA.U9.Cust.Kuka.BS.BSSV.IPubSPOperateionSV/DoExceptionFau" +
            "lt", Name = "Exception", Namespace = "http://schemas.datacontract.org/2004/07/System")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.DataRowState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase.FormatState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorDescriptor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorLevel))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.UnknownException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ThreadContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.PlatformContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ApplicationContext))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.BusinessException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttrsContainerException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttributeInValidException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.EntityNotExistException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions1.MessageBase[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaBSBSSVParamsDTOData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaBSBSSVParamsDTOData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(www.ufida.org.EntityData.UFIDAU9CustKukaBSBSSVSPResultDTOData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangDataDict))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Data.MultiLangData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.PL.Engine.ObjectState))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
        www.ufida.org.EntityData.UFIDAU9CustKukaBSBSSVSPResultDTOData Do(out UFSoft.UBF.Exceptions1.MessageBase[] outMessages, object context, string sPName, www.ufida.org.EntityData.UFIDAU9CustKukaBSBSSVParamsDTOData[] sPParams, string fromSys, string operatedBy);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UFIDAU9CustKukaBSBSSVIPubSPOperateionSVChannel : UFIDAU9CustKukaBSBSSVIPubSPOperateionSV, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UFIDAU9CustKukaBSBSSVIPubSPOperateionSVClient : System.ServiceModel.ClientBase<UFIDAU9CustKukaBSBSSVIPubSPOperateionSV>, UFIDAU9CustKukaBSBSSVIPubSPOperateionSV
    {

        public UFIDAU9CustKukaBSBSSVIPubSPOperateionSVClient()
        {
        }

        public UFIDAU9CustKukaBSBSSVIPubSPOperateionSVClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public UFIDAU9CustKukaBSBSSVIPubSPOperateionSVClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public UFIDAU9CustKukaBSBSSVIPubSPOperateionSVClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public UFIDAU9CustKukaBSBSSVIPubSPOperateionSVClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public www.ufida.org.EntityData.UFIDAU9CustKukaBSBSSVSPResultDTOData Do(out UFSoft.UBF.Exceptions1.MessageBase[] outMessages, object context, string sPName, www.ufida.org.EntityData.UFIDAU9CustKukaBSBSSVParamsDTOData[] sPParams, string fromSys, string operatedBy)
        {
            return base.Channel.Do(out outMessages, context, sPName, sPParams, fromSys, operatedBy);
        }
    }

}
