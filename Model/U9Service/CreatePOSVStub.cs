

namespace www.ufida.org.EntityData
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.CreatePODTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVCreatePODTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData[] m_pOLinesField;

        private string m_supplier_CodeField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOLineDTOData[] m_pOLines
        {
            get
            {
                return this.m_pOLinesField;
            }
            set
            {
                this.m_pOLinesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_supplier_Code
        {
            get
            {
                return this.m_supplier_CodeField;
            }
            set
            {
                this.m_supplier_CodeField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.POLineDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVPOLineDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData m_createPODTOField;

        private System.DateTime m_deliveryDateField;

        private string m_itemCodeField;

        private decimal m_orderQtyField;

        private string m_remarkField;

        private long m_srcDocField;

        private long m_srcDocLineField;

        private int m_srcDocLineNoField;

        private string m_srcDocNoField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVCreatePODTOData m_createPODTO
        {
            get
            {
                return this.m_createPODTOField;
            }
            set
            {
                this.m_createPODTOField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime m_deliveryDate
        {
            get
            {
                return this.m_deliveryDateField;
            }
            set
            {
                this.m_deliveryDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_itemCode
        {
            get
            {
                return this.m_itemCodeField;
            }
            set
            {
                this.m_itemCodeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal m_orderQty
        {
            get
            {
                return this.m_orderQtyField;
            }
            set
            {
                this.m_orderQtyField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_remark
        {
            get
            {
                return this.m_remarkField;
            }
            set
            {
                this.m_remarkField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long m_srcDoc
        {
            get
            {
                return this.m_srcDocField;
            }
            set
            {
                this.m_srcDocField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long m_srcDocLine
        {
            get
            {
                return this.m_srcDocLineField;
            }
            set
            {
                this.m_srcDocLineField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int m_srcDocLineNo
        {
            get
            {
                return this.m_srcDocLineNoField;
            }
            set
            {
                this.m_srcDocLineNoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_srcDocNo
        {
            get
            {
                return this.m_srcDocNoField;
            }
            set
            {
                this.m_srcDocNoField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.PODataData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVPODataData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private System.DateTime m_deliverDateField;

        private string m_docNoField;

        private string m_supplierField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime m_deliverDate
        {
            get
            {
                return this.m_deliverDateField;
            }
            set
            {
                this.m_deliverDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_docNo
        {
            get
            {
                return this.m_docNoField;
            }
            set
            {
                this.m_docNoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_supplier
        {
            get
            {
                return this.m_supplierField;
            }
            set
            {
                this.m_supplierField = value;
            }
        }
    }
}
