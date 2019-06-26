
namespace www.ufida.org.EntityData
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.BS.BSSV.ParamsDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaBSBSSVParamsDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private string m_pNameField;

        private string m_pTypeField;

        private string m_pVTypeField;

        private string m_pValueField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_pName
        {
            get
            {
                return this.m_pNameField;
            }
            set
            {
                this.m_pNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_pType
        {
            get
            {
                return this.m_pTypeField;
            }
            set
            {
                this.m_pTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_pVType
        {
            get
            {
                return this.m_pVTypeField;
            }
            set
            {
                this.m_pVTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_pValue
        {
            get
            {
                return this.m_pValueField;
            }
            set
            {
                this.m_pValueField = value;
            }
        }
    }

   
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.BS.BSSV.SPResultDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaBSBSSVSPResultDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private string m_resultField;

        private string m_statuesField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_result
        {
            get
            {
                return this.m_resultField;
            }
            set
            {
                this.m_resultField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_statues
        {
            get
            {
                return this.m_statuesField;
            }
            set
            {
                this.m_statuesField = value;
            }
        }
    }
}
