﻿namespace www.ufida.org.EntityData
{
    using System.Runtime.Serialization;

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.RtGoodsLineDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private decimal m_confirmQtyField;

        private string m_itemCodeField;

        private string m_pODocNoField;

        private long m_pOLineIDField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData m_rtGoodsDTOField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal m_confirmQty
        {
            get
            {
                return this.m_confirmQtyField;
            }
            set
            {
                this.m_confirmQtyField = value;
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
        public string m_pODocNo
        {
            get
            {
                return this.m_pODocNoField;
            }
            set
            {
                this.m_pODocNoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public long m_pOLineID
        {
            get
            {
                return this.m_pOLineIDField;
            }
            set
            {
                this.m_pOLineIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData m_rtGoodsDTO
        {
            get
            {
                return this.m_rtGoodsDTOField;
            }
            set
            {
                this.m_rtGoodsDTOField = value;
            }
        }
    }


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UFIDA.U9.Cust.Kuka.MPS.MPSSV.RtGoodsDTOData", Namespace = "http://www.UFIDA.org/EntityData", IsReference = true)]
    public partial class UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData : www.ufida.org.EntityData.UFSoftUBFBusinessDataTransObjectBase
    {

        private string m_carCodeField;

        private string m_carpoolNoField;

        private System.DateTime m_confirmDateField;

        private string m_deliveryAddressField;

        private string m_logisticsDocNoField;

        private string m_pODocNoField;

        private www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData[] m_rtGoodsLinesField;

        private string m_supplierCodeField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_carCode
        {
            get
            {
                return this.m_carCodeField;
            }
            set
            {
                this.m_carCodeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_carpoolNo
        {
            get
            {
                return this.m_carpoolNoField;
            }
            set
            {
                this.m_carpoolNoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime m_confirmDate
        {
            get
            {
                return this.m_confirmDateField;
            }
            set
            {
                this.m_confirmDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_deliveryAddress
        {
            get
            {
                return this.m_deliveryAddressField;
            }
            set
            {
                this.m_deliveryAddressField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_logisticsDocNo
        {
            get
            {
                return this.m_logisticsDocNoField;
            }
            set
            {
                this.m_logisticsDocNoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_pODocNo
        {
            get
            {
                return this.m_pODocNoField;
            }
            set
            {
                this.m_pODocNoField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public www.ufida.org.EntityData.UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData[] m_rtGoodsLines
        {
            get
            {
                return this.m_rtGoodsLinesField;
            }
            set
            {
                this.m_rtGoodsLinesField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string m_supplierCode
        {
            get
            {
                return this.m_supplierCodeField;
            }
            set
            {
                this.m_supplierCodeField = value;
            }
        }
    }
}