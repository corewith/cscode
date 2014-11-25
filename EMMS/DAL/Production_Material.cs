using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EMMS.DbHelper;
using System.Windows.Forms;
using System.Collections.Generic;//Please add references
namespace EMMS.DAL
{
    /// <summary>
    /// 数据访问类:Production_Material
    /// </summary>
    public class Production_Material
    {
        public Production_Material()
        { }
        #region  BasicMethod

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(string no)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from tb_production_material");
        //    strSql.Append(" where no=@no ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@no", SqlDbType.VarChar,8)			};
        //    parameters[0].Value = no;

        //    return DbHelperSql.Exists(strSql.ToString(), parameters);
        //}


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddList(List<EMMS.Model.Production_MaterialSet> modelList)
        {
            int rows = 0;
            foreach (EMMS.Model.Production_MaterialSet model in modelList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into tb_production_material(");
                strSql.Append("no,production_no,material_no,proporation) ");
                strSql.Append(" values (");
                strSql.Append("@no,@production_no,@material_no,@proporation) ");
                SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@production_no", SqlDbType.VarChar,8),
					new SqlParameter("@material_no", SqlDbType.VarChar,8),
					new SqlParameter("@proporation", SqlDbType.Float,8)
					};
                parameters[0].Value = model.No;
                parameters[1].Value = model.ProductionNo;
                parameters[2].Value = model.MaterialNo;
                parameters[3].Value = model.Proporation;

               rows += DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            }
            if (rows ==modelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(EMMS.Model.Production_MaterialSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_production_material(");
            strSql.Append("no,production_no,material_no,proporation) ");
            strSql.Append(" values (");
            strSql.Append("@no,@production_no,@material_no,@proporation) ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@production_no", SqlDbType.VarChar,8),
					new SqlParameter("@material_no", SqlDbType.VarChar,8),
					new SqlParameter("@proporation", SqlDbType.Float,8)
					};
            parameters[0].Value = model.No;
            parameters[1].Value = model.ProductionNo;
            parameters[2].Value = model.MaterialNo;
            parameters[3].Value = model.Proporation;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EMMS.Model.Production_MaterialSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_production_material set ");
            strSql.Append("production_no=@production_no, ");
            strSql.Append("material_no=@material_no, ");
            strSql.Append("proporation=@proporation ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@production_no", SqlDbType.VarChar,8),
					new SqlParameter("@material_no", SqlDbType.VarChar,8),
					new SqlParameter("@proporation", SqlDbType.Float,8)
					};
            parameters[0].Value = model.No;
            parameters[1].Value = model.ProductionNo;
            parameters[2].Value = model.MaterialNo;
            parameters[3].Value = model.Proporation;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //
        public bool UpdateList(List<EMMS.Model.Production_MaterialSet> modelList)
        {
            int rows = 0;
            foreach (EMMS.Model.Production_MaterialSet model in modelList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tb_production_material set ");
                strSql.Append("production_no=@production_no, ");
                strSql.Append("material_no=@material_no, ");
                strSql.Append("proporation=@proporation ");
                strSql.Append(" where no=@no ");
                SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@production_no", SqlDbType.VarChar,8),
					new SqlParameter("@material_no", SqlDbType.VarChar,8),
					new SqlParameter("@proporation", SqlDbType.Float,8)
					};
                parameters[0].Value = model.No;
                parameters[1].Value = model.ProductionNo;
                parameters[2].Value = model.MaterialNo;
                parameters[3].Value = model.Proporation;

                rows += DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            }
            if (rows == modelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_production_material ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)};
            parameters[0].Value = no;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string nolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_production_material ");
            strSql.Append(" where no in (" + nolist + ")  ");
            int rows = DbHelperSql.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 从tb_production_material中得到一个对象实体,Production_MaterialSet
        /// </summary>
        public EMMS.Model.Production_MaterialSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,production_no,material_no,proporation from tb_production_material ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModelSet(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public EMMS.Model.Production_MaterialGet DataRowToModel(DataRow row)
        //{
        //    EMMS.Model.Production_MaterialGet model = new EMMS.Model.Production_MaterialGet();
        //    if (row != null)
        //    {
        //        if (row["no"] != null)
        //        {
        //            model.No = row["no"].ToString();
        //        }
        //        if (row["name"] != null)
        //        {
        //            model.Name = row["name"].ToString();
        //        }
        //        if (row["typename"] != null)
        //        {
        //            model.TypeName = row["typename"].ToString();
        //        }
        //        if (row["useable"] != null && row["useable"].ToString() != "")
        //        {
        //            model.Useable = int.Parse(row["useable"].ToString());
        //        }
        //        if (row["remarks"] != null)
        //        {
        //            model.Remarks = row["remarks"].ToString();
        //        }
        //    }
        //    return model;
        //}
        /// <summary>
        /// 从getView()函数中获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,material_name,proporation,material_no ");
            strSql.Append(" from getView( '" + strWhere + "') "); //得到的对应是MaterialNameView
            
            //if (strWhere.Trim() != "")
            //{
            //    strSql.Append(" where tb_no= '" + strWhere + "'");//根据某产品编码
            //    strSql.Append(" or name= '" + strWhere + "'"); //根据某产品名称
            //    //strSql.Append(" or typename= '" + strWhere + "'");
            //}
            return DbHelperSql.Query(strSql.ToString());
        }
        //根据某产品编码得到与之相关的物料编码,及名称
        public DataSet GetMaterialList(string prodno)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  no,materialname,type,unit,proporation ");
            strSql.Append("from getView_Material('" + prodno + "')");
            return DbHelperSql.Query(strSql.ToString());
        }
        /// <summary>
        ///从getView()中 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" no,material_name,proporation ");
            strSql.Append(" from getView( '" + strWhere + "' ");
            //strSql.Append(" FROM view_production_material ");
            //if (strWhere.Trim() != "")
            //{
            //    strSql.Append(" where " + strWhere);
            //}
            strSql.Append(" order by " + filedOrder);
            return DbHelperSql.Query(strSql.ToString());
        }

        ///// <summary>
        ///// 获取记录总数
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) FROM tb_production_material ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    object obj = DbHelperSql.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.no desc");
            }
            strSql.Append(")AS Row, T.*  from view_production_material T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSql.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.MaterialNameView DataRowToModelView(DataRow row)
        {
            EMMS.Model.MaterialNameView model = new Model.MaterialNameView();
            if (row != null)
            {
                if (row["no"] != null) //产品BOM编码
                {
                    model.No = row["no"].ToString();
                }
                if (row["material_name"] != null) //物料名称
                {
                    model.MaterialName = row["material_name"].ToString();
                }
                if (row["proporation"] != null && row["proporation"].ToString() != "")
                {
                    model.Proporation = float.Parse(row["proporation"].ToString());
                }
                if (row["material_no"] != null)
                {
                    model.MaterialNo = row["material_no"].ToString();
                }
            }
            return model;
        }
        //得到名称
        public List<String> GetNameList(string strName)
        {
            //Production_Material dal = new Production_Material();
            DataSet ds = new DataSet();
            ds = GetList(strName);
            
            List<String> nameList = new List<String>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    nameList.Add(row["material_name"].ToString());
                    //DataSet ds1=new DataSet();
                }
            }
            return nameList;
        }
        public List<TreeNode> GetNodeList(string strName)
        {
            List<TreeNode> nodeList = new List<TreeNode>();//树节点
            List<String> nameList = new List<string>();//节点名称
            nameList = GetNameList(strName);
            foreach (string name in nameList)
            {
                
                nodeList.Add(new TreeNode() { Text = name });
                //if (GetList(name) != null)
                //{
                //    return GetNodeList(name);
                //}
            }
            return nodeList;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Production_MaterialSet DataRowToModelSet(DataRow row)//从表tb_production_material
        {
            EMMS.Model.Production_MaterialSet model = new EMMS.Model.Production_MaterialSet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["production_no"] != null)
                {
                    model.ProductionNo = row["production_no"].ToString();
                }
                if (row["material_no"] != null)
                {
                    model.MaterialNo = row["material_no"].ToString();
                }
                if (row["proporation"] != null && row["proporation"].ToString() != "")
                {
                    model.Proporation = float.Parse(row["proporation"].ToString());
                }
            }
            return model;
        }
        //得到产品名称
        public DataSet GetGoodsList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name from tb_goods ");
            strSql.Append("where type='01'");//获取成品
            return EMMS.DbHelper.DbHelperSql.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

