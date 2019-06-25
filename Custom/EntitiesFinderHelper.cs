using MPS.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace UFIDA.U9.Cust.Kuka.MPS.MPSSV.Custom
{
   public  class EntitiesFinderHelper
    {
        public static SupplierInfoData FinderSupplier(string code) {
            string sql = "Select ID,Code from production.dbo.CBO_Supplier s where s.Code=@Code";
            List<SqlParameter> listParam = new List<SqlParameter>()
            {
                new SqlParameter("Code",code)
            };
            DataSet ds = DbHelperSQL.QueryDataSet(sql, listParam);
            if (ds.Tables.Count == 0)
            {
                throw new Exception($"没有找到供应商{code}");
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception($"没有找到供应商{code}");
            }
            long supplierID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
            string supplierCode = ds.Tables[0].Rows[0]["Code"].ToString();
            return new SupplierInfoData()
            {
                ID = supplierID,
                Code = supplierCode
            };
        }

        public static OrganizationInfoData FinderOrganization(string code) {
            string sql = "Select ID,Code from production.dbo.Base_Organization o where o.Code=@Code";
            List<SqlParameter> listParam = new List<SqlParameter>()
            {
                new SqlParameter("Code",code)
            };
            DataSet ds = DbHelperSQL.QueryDataSet(sql, listParam);
            if (ds.Tables.Count == 0)
            {
                throw new Exception($"没有找到组织{code}");
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception($"没有找到组织{code}");
            }
            long OrganizationID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
            string OrganizationCode = ds.Tables[0].Rows[0]["Code"].ToString();
            return new OrganizationInfoData()
            {
                ID = OrganizationID,
                Code = OrganizationCode
            };
        }
        public static ItemMasterInfoData FinderItemMaster(string code)
        {
            string sql = "Select ID,Code,PurchaseUOM,Org from production.dbo.CBO_ItemMaster o where o.Code=@Code";
            List<SqlParameter> listParam = new List<SqlParameter>()
            {
                new SqlParameter("Code",code)
            };
            DataSet ds = DbHelperSQL.QueryDataSet(sql, listParam);
            if (ds.Tables.Count == 0)
            {
                throw new Exception($"没有找到料品{code}");
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception($"没有找到料品{code}");
            }
            long ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
            string Code = ds.Tables[0].Rows[0]["Code"].ToString();
            long PurchaseUOM = Convert.ToInt64(ds.Tables[0].Rows[0]["PurchaseUOM"]);
            long Org = Convert.ToInt64(ds.Tables[0].Rows[0]["Org"]);
            return new ItemMasterInfoData()
            {
                ID = ID,
                Code = Code,
                PurchaseUOM = PurchaseUOM,
                Org = Org
            };
        }

        public static BOMMasterInfoData FinderBOMMaster(string code)
        {
            string sql = "Select o.ID,ItemMaster from production.dbo.CBO_BOMMaster o left join  production.dbo.CBO_ItemMaster im on im.id=o.ItemMaster where im.Code=@Code";
            List<SqlParameter> listParam = new List<SqlParameter>()
            {
                new SqlParameter("Code",code)
            };
            DataSet ds = DbHelperSQL.QueryDataSet(sql, listParam);
            if (ds.Tables.Count == 0)
            {
                throw new Exception($"没有找到料品{code}");
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception($"没有找到料品{code}");
            }
            long ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
            long ItemMaster = Convert.ToInt64(ds.Tables[0].Rows[0]["ItemMaster"]);
            return new BOMMasterInfoData()
            {
                ID = ID,
                ItemMaster = ItemMaster
            };
        }
    }

    public class BOMMasterInfoData
    {
        public long ID { get; set; }
        public long ItemMaster { get; set; }
    }

    public class ItemMasterInfoData
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public long PurchaseUOM { get; set; }
        public long Org { get; set; }

    }

    public class OrganizationInfoData
    {

        public long ID { get; set; }
        public string Code { get; set; }
    }

    /// <summary>
    /// 供应商信息
    /// </summary>
    public class SupplierInfoData
    {
        public long ID { get; set; }
        public string Code { get; set; }
    }
}
