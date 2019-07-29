using MPS.Bussiness.U9Service;
using MPS.Custom;
using MPS.Model;
using MPS.Model.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MPS.Controllers
{
    public class MPSController : ApiController
    {
        [HttpPost]
        [ActionFilter]
        public object AddressInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
        
            RetModel<List<AddressInfo>> retModel = new RetModel<List<AddressInfo>>();
            Bussiness.Address Address = new Bussiness.Address();
            retModel = Address.GetAddressInfo(param);
            return retModel;
        }
        [HttpPost]
        [ActionFilter]
        public object ItemInfo([FromBody]RecModel<ItemInfoQuery> param) {
            RetModel<List<ItemInfo>> retModel = new RetModel<List<ItemInfo>>();
            Bussiness.ItemMaster ItemMaster = new Bussiness.ItemMaster();
            retModel = ItemMaster.GetItemInfo(param);            
            return retModel;
        }
        [HttpPost]
        [ActionFilter]
        public object SupplierInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SupplierInfo>> retModel = new RetModel<List<SupplierInfo>>();
            Bussiness.Supplier Supplier = new Bussiness.Supplier();
            retModel = Supplier.GetSupplierInfo(param);
            return retModel;
        }

        [HttpPost]
        [ActionFilter]
        public object SupplySourceInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SupplySourceInfo>> retModel = new RetModel<List<SupplySourceInfo>>();
            Bussiness.SupplySource SupplySource = new Bussiness.SupplySource();
            retModel = SupplySource.GetSupplierInfo(param);
            return retModel;
        }
        [HttpPost]
        [ActionFilter]
        public object ASNInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<ASNInfo>> retModel = new RetModel<List<ASNInfo>>();
            Bussiness.ASN ASN = new Bussiness.ASN();
            retModel = ASN.GetASNInfo(param);
            return retModel;
        }
        [HttpPost]
        [ActionFilter]
        public object SOInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SOInfo>> retModel = new RetModel<List<SOInfo>>();
            Bussiness.SO SO = new Bussiness.SO();
            retModel = SO.GetSOLineInfo(param);
            return retModel;
        }
        [HttpPost]
        [ActionFilter]
        public object SOInfoV2([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SOInfo>> retModel = new RetModel<List<SOInfo>>();
            Bussiness.SO SO = new Bussiness.SO();
            retModel = SO.GetSOLineInfoV2(param);
            return retModel;
        }

        [HttpPost]
        [ActionFilter]
        public object CreatePO([FromBody]RecModel<CreatePODto> param)
        {
            RetModel<PODto> retModel = new RetModel<PODto>();
            try
            {
                Bussiness.PO PO = new Bussiness.PO();
                retModel = PO.CreatePO(param);
            }
            catch (Exception e){
                retModel.message = Common.GetExceptionMessage(e);
                retModel.code = "-1";
            }
            return retModel;
        }
        [ActionFilter]
        [HttpPost]
        public object POInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<POInfo>> retModel = new RetModel<List<POInfo>>();
            try
            {
                Bussiness.PO PO = new Bussiness.PO();
                retModel = PO.GetPOInfo(param);
            }
            catch (Exception e)
            {
                retModel.message = Common.GetExceptionMessage(e);
                retModel.code = "-1";
            }
            return retModel;
        }
        /// <summary>
        /// 集成工作PO信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionFilter]
        public object JCPOInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<JCPOInfo>> retModel = new RetModel<List<JCPOInfo>>();
            try
            {
                Bussiness.PO PO = new Bussiness.PO();
                retModel = PO.GetJCPOInfo(param);
            }
            catch (Exception e)
            {
                retModel.message = Common.GetExceptionMessage(e);
                retModel.code = "-1";
            }
            return retModel;
        }
        /// <summary>
        /// 创建回货计划
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionFilter]
        public object CreateRtGoods([FromBody]RecModel<RtGoodsInfo> param)
        {
            RetModel<string> retModel = new RetModel<string>();
            try
            {
                if (string.IsNullOrEmpty(param.data.DeliveryAddress)) {
                    throw new Exception("送货地址字段不能为空");
                }
                if (param.data.ConfirmDate==DateTime.MinValue)
                {
                    throw new Exception("计划发货日期字段不能为空");
                }
                if (string.IsNullOrEmpty(param.data.SupplierCode))
                {
                    throw new Exception("供应商编码字段不能为空");
                }
                Bussiness.RtGoods RtGoods = new Bussiness.RtGoods();
                retModel = RtGoods.CreateRtGoods(param);
            }
            catch (Exception e)
            {
                retModel.message = Common.GetExceptionMessage(e);
                retModel.code = "-1";
            }
            return retModel;
        }
    }
}
