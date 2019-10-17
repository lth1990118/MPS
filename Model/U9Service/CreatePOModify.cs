namespace www.ufida.org.EntityData
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.POModifyDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVPOModifyDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData[] m_pOShipLinesField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVIDCodeNameData m_purchaseOrderField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData[] m_pOShipLines
        {
            get
            {
                return this.m_pOShipLinesField;
            }
            set
            {
                this.m_pOShipLinesField = value;
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
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.POShipLineDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVPOShipLineDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private int m_changeTypeField;

        private System.DateTime m_deliveryDateField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVIDCodeNameData m_itemInfoField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVPOModifyDTOData m_pOModifyDTOField;

        private long m_pOShipLineIDField;

        private decimal m_qtyField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int m_changeType
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
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVIDCodeNameData m_itemInfo
        {
            get
            {
                return this.m_itemInfoField;
            }
            set
            {
                this.m_itemInfoField = value;
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
        public long m_pOShipLineID
        {
            get
            {
                return this.m_pOShipLineIDField;
            }
            set
            {
                this.m_pOShipLineIDField = value;
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
}