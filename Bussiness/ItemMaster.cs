using Custom;
using MPS.Custom;
using MPS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Bussiness
{
    public class ItemMaster
    {
        //private string sql = "select ROW_NUMBER() over(order by mts.ItemCode)as rownum,mts.ItemID as ID ,mts.ItemCode as Code,mts.ItemName as Name,im.SPECS,mts.业绩归属 as Dept,mts.货号 as NameSegment1,itemed.DescFlexField_PrivateDescSeg21 as Serious ,mts.计划模式 as PlanMode,hz.计划模式 as HZPlanMode,hb.计划模式 as HBPlanMode,(case when mts.是否电商=1 then '是' else '否' end) as IsOnline ,mts.安全库存 as SafeQty,mts.最高库存 as MaxQty,hz.安全库存 as HZSafeQty,hz.最高库存 as HZMaxQty,hb.安全库存 as HBSafeQty,hb.最高库存 as HBMaxQty,itemed.DescFlexField_PrivateDescSeg23 as OnMarketTime ,itemed.DescFlexField_PrivateDescSeg24 as OffMarketTime,itemed.DescFlexField_PrivateDescSeg25 as Type ,mts.采购周期 as POCycle,mts.最小起订量 as MinOrder,case ist.name when '内销可下单' then '在市' when '限款(限消耗库存)' then '预下市' else ist.name end as OnMarketStatus ,'' as Activity,im.InventorySecondUOM as InventorySecondUOM,uom.code as InventorySecondUOM_Code ,uomt.Name as InventorySecondUOM_Name,mts.ABC分级 as ABC ,orderQty.出样客户数 as CustomQty,OrderQty.返单客户数 as RetCustomNum,0.5 as ActiveCOE ,'' as OffMarket,mts.ModifyOn,im.DescFlexField_PrivateDescSeg3 as ItemBulk,im.DescFlexField_PrivateDescSeg1 as Weight,tempCategory.SaleName as PurchaseCategory,mts.公司安全库存 as ComSafeQty,hz.公司安全库存 as HZComSafeQty,hb.公司安全库存 as HBComSafeQty,mts.供方安全库存 as SuppSafeQty from kuka_basedata.dbo.Kuka_Tb_GetMTS mts left join kuka_basedata.dbo.[Kuka_Tb_GetHZMTS] hz on hz.[ItemID]=mts.[ItemID] left join kuka_basedata.dbo.[Kuka_Tb_GetHBMTS] hb on HB.[ItemID]=mts.[ItemID] left join dbo.CBO_ItemMaster im on im.id=mts.ItemID left join CBO_ItemStatus_Trl ist on ist.id=im.Status left join ( select ct.Name as SaleName,c.id from dbo.CBO_Category c left join dbo.[CBO_Category_Trl] as ct on (c.[ID] = ct.[ID])) tempCategory on tempCategory.id=im.PurchaseCategory left join dbo.Kuka_BS_ItemEd itemed on itemed.Item= mts.ItemID left join dbo.Base_UOM uom on uom.id= im.InventorySecondUOM left join dbo.Base_UOM_trl uomt on uomt.id= im.InventorySecondUOM left join kuka_basedata.dbo.Kuka_Tb_GetOrderQty orderQty on orderQty.ItemID= mts.ItemID where  (im.Code like '91.A%' or im.Code like '91.K%' 	 or im.Code like '91.W%' or im.Code like '91.ZZ%' or im.Code like '07.%')    and im.Code not like '07.01%'  and len(im.Code)<=12";
        private string sql = "select ROW_NUMBER() over(order by im.code)as rownum,im.id as ID ,im.Code as Code,im.Name as Name,im.SPECS,ct.name as Dept,im.NameSegment1 as NameSegment1,itemed.DescFlexField_PrivateDescSeg21 as Serious ,mts.计划模式 as PlanMode,hz.计划模式 as HZPlanMode,hb.计划模式 as HBPlanMode,(case when itemed.DescFlexField_PrivateDescSeg22='线上' then '是' else '否' end) as IsOnline ,mts.安全库存 as SafeQty,mts.最高库存 as MaxQty,hz.安全库存 as HZSafeQty,hz.最高库存 as HZMaxQty,hb.安全库存 as HBSafeQty,hb.最高库存 as HBMaxQty,itemed.DescFlexField_PrivateDescSeg23 as OnMarketTime ,itemed.DescFlexField_PrivateDescSeg24 as OffMarketTime,itemed.DescFlexField_PrivateDescSeg25 as Type ,cast((case Isnull(mrpInfo.PurProcessLT,0) when 0 then 60 else mrpInfo.PurProcessLT end) as int) as POCycle,(case when (im.CatalogNO='' or isnumeric(im.CatalogNO)=0) and im.NameSegment2 like '%餐椅%' then 50 when (im.CatalogNO='' or isnumeric(im.CatalogNO)=0) then 30 else cast (im.CatalogNO as decimal(38,2)) end) as MinOrder,case ist.name when '内销可下单' then '在市' when '限款(限消耗库存)' then '预下市' else ist.name end as OnMarketStatus ,'' as Activity,im.InventorySecondUOM as InventorySecondUOM,uom.code as InventorySecondUOM_Code ,uomt.Name as InventorySecondUOM_Name,mts.ABC分级 as ABC ,orderQty.出样客户数 as CustomQty,OrderQty.返单客户数 as RetCustomNum,0.5 as ActiveCOE ,'' as OffMarket,case when (mts.ModifyOn is null) or (mts.ModifyOn>im.ModifiedOn) then im.ModifiedOn   else mts. ModifyOn end as ModifiedOn,im.DescFlexField_PrivateDescSeg3 as ItemBulk,im.DescFlexField_PrivateDescSeg1 as Weight,ct.Name as PurchaseCategory,mts.公司安全库存 as ComSafeQty,hz.公司安全库存 as HZComSafeQty,hb.公司安全库存 as HBComSafeQty,mts.供方安全库存 as SuppSafeQty ,case when hbitem.id is not null then 1 else 0 end as IsHBItem,case when hgitem.id is not null then 1 else 0 end as IsHGItem from dbo.CBO_ItemMaster im left join kuka_hbitem hbitem on hbitem.Item= im.id and hbitem.IsEffective= 1 and hbitem.BaseAddress= 1001301070000075 left join kuka_hbitem hgitem on hgitem.Item= im.id and hgitem.IsEffective= 1 and hgitem.BaseAddress= 1004509235877512 left join kuka_basedata.dbo.Kuka_Tb_GetMTS mts  on im.id= mts.ItemID left join kuka_basedata.dbo.[Kuka_Tb_GetHZMTS] hz on hz.[ItemID]= mts.[ItemID] left join kuka_basedata.dbo.[Kuka_Tb_GetHBMTS] hb on HB.[ItemID]= mts.[ItemID] left join CBO_ItemStatus_Trl ist on ist.id= im.Status left join dbo.CBO_MrpInfo mrpInfo on mrpInfo.ItemMaster= im.ID left join dbo.[CBO_Category_Trl] ct on ct.id= im.SaleCategory left join dbo.Kuka_BS_ItemEd itemed on itemed.Item= im.ID left join dbo.Base_UOM uom on uom.id= im.InventorySecondUOM left join dbo.Base_UOM_trl uomt on uomt.id= im.InventorySecondUOM left join kuka_basedata.dbo.Kuka_Tb_GetOrderQty orderQty on orderQty.ItemID= mts.ItemID where (im.Code like '91.%' or im.Code like '07.%') ";
            //(im.Code like '91.A%' or im.Code like '91.K%' 	 or im.Code like '91.W%' or im.Code like '91.ZZ%' or im.Code like '07.%')    and im.Code not like '07.01%'  and len(im.Code)<=12 ";
        public RetModel<List<ItemInfo>> GetItemInfo(RecModel<ItemInfoQuery> param)
        {
            RetModel<List<ItemInfo>> result = new RetModel<List<ItemInfo>>();
            result.code = "0";
            result.message = "0";
            
            List<SqlParameter> listParam = new List<SqlParameter>();
            StringBuilder sqlQuery = new StringBuilder();
            StringBuilder sqlExcute = new StringBuilder(this.sql);
            if (param.data != null)
            {
                if (param.data.startTime.HasValue)
                {
                    sqlExcute.Append(" and ((mts.ModifyOn is not null and (mts.ModifyOn>im.ModifiedOn) and mts.ModifyOn>=@startTime) or (mts.ModifyOn is null and im.ModifiedOn>=@startTime))");
                    listParam.Add(new SqlParameter("startTime", param.data.startTime));
                }
                if (param.data.endTime.HasValue)
                {
                    sqlExcute.Append(" and ((mts.ModifyOn is not null and (mts.ModifyOn>im.ModifiedOn) and mts.ModifyOn<@endTime) or (mts.ModifyOn is null and im.ModifiedOn<@endTime))");
                    listParam.Add(new SqlParameter("endTime", param.data.endTime));
                }
                sqlQuery.Append("select * from (");
                sqlQuery.Append(sqlExcute);
                sqlQuery.Append(") t");

                if (param.data.pageSize != 0)
                {
                    sqlQuery.Append(" where rownum>@skip and rownum<=@Take");
                    listParam.Add(new SqlParameter("skip", param.data.pageIndex * param.data.pageSize));
                    listParam.Add(new SqlParameter("Take", (param.data.pageIndex + 1) * param.data.pageSize));
                }
            }
            else {
                sqlQuery = sqlExcute;
            }
            result.message = DbHelperSQL.QueryCount(sqlExcute.ToString(), listParam).ToString();
            var dataTable = DbHelperSQL.Query(sqlQuery.ToString(), listParam);
            var data = ExtendMethod.ToDataList<ItemInfo>(dataTable);

            string strCapacity = "select c.Supplier,c.Item as ItemMaster,c.CapacityQty,'' as Remark from kuka_capacity c";
            var dtCapacity = DbHelperSQL.Query(strCapacity.ToString(), new List<SqlParameter>());
            var dataCapacty = ExtendMethod.ToDataList<Capacity>(dtCapacity);

            foreach (var item in data)
            {
                long itemID = item.ID;
                item.Capacity = dataCapacty.Where(p=>p.ItemMaster == itemID).ToList();
            }

            result.data = data;// ConvertDtToDatable.TableToResult<ItemInfo>(dataTable);
            return result;
        }
    }
}
