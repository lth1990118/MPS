using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom;
using MPS.Bussiness.U9Service;
using MPS.Custom;
using MPS.Model;
using UFIDA.U9.Cust.Kuka.MPS.MPSSV.RtGoods2;
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

            List<UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData> listRtGoodsDTO = new List<UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData>();
            UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient Client = new UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient();
                         
                UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData RtGoodsDTOData = new UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData();
                if (param.data == null)
                {
                    throw new Exception($"参数data对象不存在或不合规定！");
                }
                RtGoodsInfo rtGoodsInfo = param.data;
                RtGoodsDTOData.m_confirmDate = rtGoodsInfo.ConfirmDate;
                //RtGoodsDTOData.m_pODocNo = rtGoodsInfo.PODocNo;
                if (string.IsNullOrEmpty(rtGoodsInfo.DeliveryAddress))
                {
                    throw new Exception($"参数送货地址(DeliveryAddress)不能为空");
                }
                string AddressCode = "";
                switch (rtGoodsInfo.DeliveryAddress)
                {
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

                RtGoodsDTOData.m_isTMS = rtGoodsInfo.AbnormalBillType != 2 ? true : false;
                RtGoodsDTOData.m_carpoolNo = rtGoodsInfo.CarpoolNo;
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
                    RtGoodsLine.m_totalVolume = item.TotalVolume;
                    RtGoodsLine.m_totalWeight = item.TotalWeight;
                    RtGoodsLine.m_remark = item.Remark;
                    list.Add(RtGoodsLine);
                }
                RtGoodsDTOData.m_rtGoodsLines = list.ToArray();

             
            ThreadContext context = Common.CreateContextObj();
            List<RtGoodsResult> listResult = new List<RtGoodsResult>();
            //string docno = Client.Do(context, RtGoodsDTOData, out UFSoft.UBF.Exceptions1.MessageBase[] outMessages);
            //Result.data = docno;
            return Result;
        }
        public RetModel<List<RtGoodsResult>> CreateRtGoodsV2(RecModel<List<RtGoodsInfo>> param)
        {
            RetModel<List<RtGoodsResult>> Result = new RetModel<List<RtGoodsResult>>();
            Result.code = "0";
            Result.message = "0";

            List<UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData> listRtGoodsDTO = new List<UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData>();
            UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient Client = new UFIDAU9CustKukaMPSMPSSVICreateRtGoodsSVClient();
            foreach (var itemParam in param.data)
            {
                UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData RtGoodsDTOData = new UFIDAU9CustKukaMPSMPSSVRtGoodsDTOData();
                if (param.data == null)
                {
                    throw new Exception($"参数data对象不存在或不合规定！");
                }
                RtGoodsInfo rtGoodsInfo = itemParam;
                RtGoodsDTOData.m_confirmDate = rtGoodsInfo.ConfirmDate;
                //RtGoodsDTOData.m_pODocNo = rtGoodsInfo.PODocNo;
                if (string.IsNullOrEmpty(rtGoodsInfo.DeliveryAddress))
                {
                    throw new Exception($"参数送货地址(DeliveryAddress)不能为空");
                }
                string AddressCode = "";
                switch (rtGoodsInfo.DeliveryAddress)
                {
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

                RtGoodsDTOData.m_isTMS = rtGoodsInfo.AbnormalBillType != 2 ? true : false;
                RtGoodsDTOData.m_carpoolNo = rtGoodsInfo.CarpoolNo;
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
                    RtGoodsLine.m_totalVolume = item.TotalVolume;
                    RtGoodsLine.m_totalWeight = item.TotalWeight;
                    RtGoodsLine.m_remark = item.Remark;
                    list.Add(RtGoodsLine);
                }
                RtGoodsDTOData.m_rtGoodsLines = list.ToArray();

                listRtGoodsDTO.Add(RtGoodsDTOData);
            }
            ThreadContext context = Common.CreateContextObj();
            List<RtGoodsResult> listResult = new List<RtGoodsResult>();
            Client.Do(context, listRtGoodsDTO.ToArray(), out UFSoft.UBF.Exceptions1.MessageBase[] outMessages).ToList().ForEach(t => listResult.Add(new RtGoodsResult()
            {
                CarpoolNo = t.m_carpoolNo,
                LogisticsDocNo = t.m_logisticsDocNo,
                SupplierCode = t.m_supplierCode,
                RtGoodsDocNo = t.m_rtGoodsDocNo
            }));
            Result.data = listResult;
            return Result;
        }

        public RetModel<List<MPSRtGoodsDocInfo>> GetRtGoodsDocInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<MPSRtGoodsDocInfo>> result = new RetModel<List<MPSRtGoodsDocInfo>>();
            result.code = "0";
            result.message = "0";

            DataSet ds = DbHelperSQL.ExecuteDataSet("kuka_basedata.dbo.Kuka_MPS_GetRtGoodsDoc", new SqlParameter[] {
                new SqlParameter("startTime",param.data.startTime==null?"":param.data.startTime.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("endTime",param.data.endTime==null?"":param.data.endTime.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("pageIndex",param.data.pageIndex),
                new SqlParameter("pageSize",param.data.pageSize),
                new SqlParameter("keyValue",param.data.keyValue==null?"":param.data.keyValue)
            });
            //var dataSet2 = DbHelperSQL.QueryDataSet(sqlQuery.ToString(), listParam);
            result.message = ds.Tables[0].Rows[0][0].ToString();
            var dataHead = ExtendMethod.ToDataList<MPSRtGoodsDocInfo>(ds.Tables[1]);
            var dataLine = ExtendMethod.ToDataList<MPSRtGoodsDocLineInfo>(ds.Tables[2]);
            Dictionary<long, List<MPSRtGoodsDocLineInfo>> map = new Dictionary<long, List<MPSRtGoodsDocLineInfo>>();
            foreach (MPSRtGoodsDocLineInfo line in dataLine)
            {
                if (map.ContainsKey(line.RtGoodsDoc))
                {
                    map[line.RtGoodsDoc].Add(line);
                }
                else
                {
                    map.Add(line.RtGoodsDoc, new List<MPSRtGoodsDocLineInfo>() { line });
                }
            }
            foreach (MPSRtGoodsDocInfo head in dataHead)
            {
                if (map.ContainsKey(head.ID))
                {
                    head.RtGoodsDocLines = map[head.ID];
                }
                else
                {
                    head.RtGoodsDocLines = new List<MPSRtGoodsDocLineInfo>();
                }
            }
            result.data = dataHead;
            return result;
        }
    }
}
