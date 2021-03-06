﻿using MPS.Bussiness;
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
using www.ufida.org.EntityData;

namespace MPS.Controllers
{
    public class MPSController : ApiController
    {
        [HttpPost]
        public object AddressInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
        
            RetModel<List<AddressInfo>> retModel = new RetModel<List<AddressInfo>>();
            Bussiness.Address Address = new Bussiness.Address();
            retModel = Address.GetAddressInfo(param);
            return retModel;
        }
        [HttpPost]
        public object ItemInfo([FromBody]RecModel<ItemInfoQuery> param) {
            RetModel<List<ItemInfo>> retModel = new RetModel<List<ItemInfo>>();
            Bussiness.ItemMaster ItemMaster = new Bussiness.ItemMaster();
            retModel = ItemMaster.GetItemInfo(param);            
            return retModel;
        }
        [HttpPost]
        public object SupplierInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SupplierInfo>> retModel = new RetModel<List<SupplierInfo>>();
            Bussiness.Supplier Supplier = new Bussiness.Supplier();
            retModel = Supplier.GetSupplierInfo(param);
            return retModel;
        }

        [HttpPost]
        public object SupplySourceInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SupplySourceInfo>> retModel = new RetModel<List<SupplySourceInfo>>();
            Bussiness.SupplySource SupplySource = new Bussiness.SupplySource();
            retModel = SupplySource.GetSupplierInfo(param);
            return retModel;
        }
        [HttpPost]
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
        public object SOInfoV2([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SOInfo>> retModel = new RetModel<List<SOInfo>>();
            Bussiness.SO SO = new Bussiness.SO();
            retModel = SO.GetSOLineInfoV2(param);
            return retModel;
        }

        [HttpPost]
        public RetModel<object> CreatePO([FromBody]RecModel<CreatePODto> param)
        {
            RetModel<object> retModel = new RetModel<object>();
            //try
            //{
                Bussiness.PO PO = new Bussiness.PO();
                retModel = PO.CreatePOV2(param);
            //}
            //catch (Exception e){
            //    retModel.message = Common.GetExceptionMessage(e);
            //    retModel.code = "-1";
            //}
            return retModel;
        }
        [HttpPost]
        public object CreatePOV2([FromBody]RecModel<CreatePODto> param)
        {
            RetModel<object> retModel = new RetModel<object>();
            //try
            //{
            Bussiness.PO PO = new Bussiness.PO();
            retModel = PO.CreatePOV2(param);
            //}
            //catch (Exception e){
            //    retModel.message = Common.GetExceptionMessage(e);
            //    retModel.code = "-1";
            //}
            return retModel;
        }
        [HttpPost]
        public object POInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<POInfo>> retModel = new RetModel<List<POInfo>>();
            //try
            //{
                Bussiness.PO PO = new Bussiness.PO();
                retModel = PO.GetPOInfo(param);
            //}
            //catch (Exception e)
            //{
            //    retModel.message = Common.GetExceptionMessage(e);
            //    retModel.code = "-1";
            //}
            return retModel;
        }
        /// <summary>
        /// 集成工作PO信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object JCPOInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<JCPOInfo>> retModel = new RetModel<List<JCPOInfo>>();
            //try
            //{
                Bussiness.PO PO = new Bussiness.PO();
                retModel = PO.GetJCPOInfoV3(param);
            //}
            //catch (Exception e)
            //{
            //    retModel.message = Common.GetExceptionMessage(e);
            //    retModel.code = "-1";
            //}
            return retModel;
        }

        [HttpPost]
        public object JCPOInfo3([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<JCPOInfo>> retModel = new RetModel<List<JCPOInfo>>();
            Bussiness.PO PO = new Bussiness.PO();
            retModel = PO.GetJCPOInfoV3(param);          
            return retModel;
        }
        /// <summary>
        /// 创建回货计划
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object CreateRtGoods([FromBody]RecModel<List<RtGoodsInfo>> param)
        {
            RetModel<List<RtGoodsResult>> retModel = new RetModel<List<RtGoodsResult>>();
           
            foreach (var item in param.data)
            {
                if (string.IsNullOrEmpty(item.DeliveryAddress))
                {
                    throw new Exception("送货地址字段不能为空");
                }
                if (item.ConfirmDate == DateTime.MinValue)
                {
                    throw new Exception("计划发货日期字段不能为空");
                }
                if (string.IsNullOrEmpty(item.SupplierCode))
                {
                    throw new Exception("供应商编码字段不能为空");
                }
            }

            Bussiness.RtGoods RtGoods = new Bussiness.RtGoods();
            retModel = RtGoods.CreateRtGoodsV2(param);
         
            return retModel;
        }
        /// <summary>
        /// 创建回货计划
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object CreateRtGoodsV1([FromBody]RecModel<RtGoodsInfo> param)
        {
            RetModel<string> retModel = new RetModel<string>();


            if (string.IsNullOrEmpty(param.data.DeliveryAddress))
            {
                throw new Exception("送货地址字段不能为空");
            }
            if (param.data.ConfirmDate == DateTime.MinValue)
            {
                throw new Exception("计划发货日期字段不能为空");
            }
            if (string.IsNullOrEmpty(param.data.SupplierCode))
            {
                throw new Exception("供应商编码字段不能为空");
            }


            Bussiness.RtGoods RtGoods = new Bussiness.RtGoods();
            retModel = RtGoods.CreateRtGoods(param);

            return retModel;
        }

        /// <summary>
        /// 销售订单删除日志
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object SODeleteLog([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<SODeleteLogInfo>> retModel = new RetModel<List<SODeleteLogInfo>>();
            Bussiness.SO SO = new Bussiness.SO();
            retModel = SO.GetSODeleteLog(param);           
            return retModel;
        }

        /// <summary>
        /// 采购订单中间表信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object MPSPOInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<MPSPOInfo>> retModel = new RetModel<List<MPSPOInfo>>();
            Bussiness.PO PO = new Bussiness.PO();
            retModel = PO.GetMPSPOInfo(param);
            return retModel;
        }
        /// <summary>
        /// 库存
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetWhQoh()
        {
            RetModel<List<WhQohInfo>> retModel = new RetModel<List<WhQohInfo>>();
            Bussiness.WhQoh WhQoh = new Bussiness.WhQoh();
            retModel = WhQoh.GetWhQoh();
            return retModel;
        }

        /// <summary>
        /// 收货单数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetRcvInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<RcvInfo>> retModel = new RetModel<List<RcvInfo>>();
            Bussiness.Rcv Rcv = new Bussiness.Rcv();
            retModel = Rcv.GetRcvInfo(param);
            return retModel;
        }

        /// <summary>
        /// MPS获取回货计划
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetRtGoodsDocInfo([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<MPSRtGoodsDocInfo>> retModel = new RetModel<List<MPSRtGoodsDocInfo>>();
            Bussiness.RtGoods rtgoods = new Bussiness.RtGoods();
            retModel = rtgoods.GetRtGoodsDocInfo(param);
            return retModel;
        }

        /// <summary>
        /// 采购订单变更单
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object CreatePOModify([FromBody]RecModel<POModifyDTOInfo> param)
        {
            RetModel<object> retModel = new RetModel<object>();
            POModify pOModify = new POModify();
            retModel=pOModify.CreatePOModify(param);
            return retModel;
        }
        /// <summary>
        /// 采购订单变更单
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPOModify([FromBody]RecModel<ItemInfoQuery> param)
        {
            RetModel<List<MPSPOModifyInfo>> retModel = new RetModel<List<MPSPOModifyInfo>>();
            POModify pOModify = new POModify();
            retModel = pOModify.GetPOModify(param);
            return retModel;
        }
        /// <summary>
        /// 采购订单变更查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetPOInfoForModify([FromBody]RecModel<POInfoModifyQuery> param)
        {
            RetModel<List<POInfoModify>> retModel = new RetModel<List<POInfoModify>>();
            POInfoForModify pOModify = new POInfoForModify();
            retModel = pOModify.GetPOInfo(param);
            return retModel;
        }
    }
}
