using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPS.Bussiness.U9Service;
using MPS.Model;
using UFIDA.U9.Cust.Kuka.MPS.MPSSV.RtGoods;
using UFSoft.UBF.Util.Context;
using www.ufida.org.EntityData;

namespace MPS.Bussiness
{
    public class RtGoods
    {
        public RetModel<string> CreateRtGoods(RecModel<RtGoodsInfo> param)
        {
            RetModel<string> Result = new RetModel<string>();
            Result.code = "0";
            Result.message = "0";

            UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient Client = new UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient();
            UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData RtGoodsDTOData = new UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData();
            if (param.data == null) {
                throw new Exception($"参数data对象不存在或不合规定！");
            }
            RtGoodsInfo rtGoodsInfo = param.data;            
            RtGoodsDTOData.m_confirmDate = rtGoodsInfo.ConfirmDate;
            //RtGoodsDTOData.m_pODocNo = rtGoodsInfo.PODocNo;
            if (string.IsNullOrEmpty(rtGoodsInfo.DeliveryAddress)) {
                throw new Exception($"参数送货地址(DeliveryAddress)不能为空");
            }
            string AddressCode = "";
            switch (rtGoodsInfo.DeliveryAddress) {
                case "杭州":
                case "01":
                    AddressCode = "01";
                    break;
                case "河北":
                case "03":
                    AddressCode = "03";
                    break;
                default:
                    throw new Exception("无效的送货地址");
            }
            RtGoodsDTOData.m_deliveryAddress = AddressCode;
            RtGoodsDTOData.m_supplierCode = rtGoodsInfo.SupplierCode;

            RtGoodsDTOData.m_carCode = rtGoodsInfo.CarCode;
            RtGoodsDTOData.m_logisticsDocNo = rtGoodsInfo.LogisticsDocNo;
            List<UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData> list = new List<UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData>();
            foreach (var item in rtGoodsInfo.RtGoodsLines)
            {
                UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData RtGoodsLine = new UFIDAU9CustKukaMPSMPSSVRtGoodsLineDTOData();
                
                RtGoodsLine.m_confirmQty = item.ConfirmQty;
                RtGoodsLine.m_itemCode = item.ItemCode;
                RtGoodsLine.m_pOShipLineID = item.POShipLineID;
                RtGoodsLine.m_pOLineID = item.POLineID;
                RtGoodsLine.m_pODocNo = item.PODocNo;
                RtGoodsLine.m_rtGoodsDTO = RtGoodsDTOData;
                list.Add(RtGoodsLine);
            }
            RtGoodsDTOData.m_rtGoodsLines = list.ToArray();

            ThreadContext context = Common.CreateContextObj();
            Result.data = Client.Do(context, RtGoodsDTOData, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages);
            return Result;
        }
    }
}
