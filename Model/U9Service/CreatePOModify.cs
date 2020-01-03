namespace www.ufida.org.EntityData
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.POModifyDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVPOModifyDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private string m_jsonStrField;

        private string m_messageIDField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData[] m_pOLinesField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVIDCodeNameData m_purchaseOrderField;

        private int m_versionField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_jsonStr
        {
            get
            {
                return this.m_jsonStrField;
            }
            set
            {
                this.m_jsonStrField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_messageID
        {
            get
            {
                return this.m_messageIDField;
            }
            set
            {
                this.m_messageIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData[] m_pOLines
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
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVIDCodeNameData m_purchaseOrder
        {
            get
            {
                return this.m_purchaseOrderField;
            }
            set
            {
                this.m_purchaseOrderField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int m_version
        {
            get
            {
                return this.m_versionField;
            }
            set
            {
                this.m_versionField = value;
            }
        }
    }


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.POShipLineDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private short m_changeTypeField;

        private System.DateTime m_deliveryDateField;

        private string m_memoField;

        private long m_pOLineField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyDTOData m_pOModifyDTOField;

        private decimal m_qtyField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVIDCodeNameData m_supplierField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public short m_changeType
        {
            get
            {
                return this.m_changeTypeField;
            }
            set
            {
                this.m_changeTypeField = value;
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
        public string m_memo
        {
            get
            {
                return this.m_memoField;
            }
            set
            {
                this.m_memoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long m_pOLine
        {
            get
            {
                return this.m_pOLineField;
            }
            set
            {
                this.m_pOLineField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyDTOData m_pOModifyDTO
        {
            get
            {
                return this.m_pOModifyDTOField;
            }
            set
            {
                this.m_pOModifyDTOField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal m_qty
        {
            get
            {
                return this.m_qtyField;
            }
            set
            {
                this.m_qtyField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVIDCodeNameData m_supplier
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

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.IDCodeNameData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVIDCodeNameData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private string m_codeField;

        private long m_iDField;

        private string m_nameField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_code
        {
            get
            {
                return this.m_codeField;
            }
            set
            {
                this.m_codeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long m_iD
        {
            get
            {
                return this.m_iDField;
            }
            set
            {
                this.m_iDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_name
        {
            get
            {
                return this.m_nameField;
            }
            set
            {
                this.m_nameField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.POModifyResultData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVPOModifyResultData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private long m_pOModifyField;

        private string m_pOModifyDocNoField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPurchaseOrderDTOData[] m_purchaseOrdersField;

        private string m_statusField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long m_pOModify
        {
            get
            {
                return this.m_pOModifyField;
            }
            set
            {
                this.m_pOModifyField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_pOModifyDocNo
        {
            get
            {
                return this.m_pOModifyDocNoField;
            }
            set
            {
                this.m_pOModifyDocNoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPurchaseOrderDTOData[] m_purchaseOrders
        {
            get
            {
                return this.m_purchaseOrdersField;
            }
            set
            {
                this.m_purchaseOrdersField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_status
        {
            get
            {
                return this.m_statusField;
            }
            set
            {
                this.m_statusField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.PurchaseOrderDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVPurchaseOrderDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private string m_docNoField;

        private long m_iDField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyResultData m_pOModifyResultField;

        private string m_statusField;

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
        public long m_iD
        {
            get
            {
                return this.m_iDField;
            }
            set
            {
                this.m_iDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyResultData m_pOModifyResult
        {
            get
            {
                return this.m_pOModifyResultField;
            }
            set
            {
                this.m_pOModifyResultField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_status
        {
            get
            {
                return this.m_statusField;
            }
            set
            {
                this.m_statusField = value;
            }
        }
    }
}
