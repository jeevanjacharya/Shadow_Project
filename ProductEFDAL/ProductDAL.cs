using ProductEFDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductEFDAL
{
    public class ProductDAL
    {
        SqlConnection conObj;
        string conStr = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

        public ProductDAL()
        {
            conObj = new SqlConnection(conStr);
        }

        public List<ProductDTO> FetchProducts()
        {
            List<ProductDTO> listproducts = new List<ProductDTO>();

            conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            SqlCommand queryObj = new SqlCommand();
            queryObj.CommandText = @"SELECT [Slno],[ProductName],[ProductPrice] FROM [Product].[dbo].[Product]";
            queryObj.CommandType = System.Data.CommandType.Text;
            queryObj.Connection = conObj;

            try
            {
                conObj.Open();
                SqlDataReader prod = queryObj.ExecuteReader();
                while (prod.Read())
                {
                    listproducts.Add(new ProductDTO()
                    {
                        Slno = (int)prod["Slno"],
                        ProductName = prod["ProductName"].ToString(),
                        ProductPrice = (int)prod["ProductPrice"],
                    });
                }
                return listproducts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertNewProduct(ProductDTO prodObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_AddNewProdcut";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;
                //queryObj.Parameters.AddWithValue("@slno", prodObj.Slno);
                queryObj.Parameters.AddWithValue("@pName", prodObj.ProductName);
                queryObj.Parameters.AddWithValue("@pPrice", prodObj.ProductPrice);
                SqlParameter praReturn = new SqlParameter();
                praReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                praReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(praReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(praReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateNewProduct(ProductDTO prodObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_UpdateProduct";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;
                queryObj.Parameters.AddWithValue("@slno", prodObj.Slno);
                queryObj.Parameters.AddWithValue("@pName", prodObj.ProductName);
                queryObj.Parameters.AddWithValue("@pPrice", prodObj.ProductPrice);
                SqlParameter praReturn = new SqlParameter();
                praReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                praReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(praReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(praReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int DeleteProduct(int prodSlno)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_DeleteProduct";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;

                queryObj.Parameters.AddWithValue("@slno", prodSlno);

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public int UserLogin(LoginDTO loginObj)
        //{
        //    SqlConnection conObj = new SqlConnection();
        //    conObj.ConnectionString = conStr;
        //    try
        //    {
        //        SqlCommand queryObj = new SqlCommand();
        //        queryObj.CommandText = @"usp_Userlogin";
        //        queryObj.CommandType = System.Data.CommandType.StoredProcedure;
        //        queryObj.Connection = conObj;
        //        queryObj.Parameters.AddWithValue("@UserName", loginObj.UserName);
        //        queryObj.Parameters.AddWithValue("@Password", loginObj.Password);
        //        SqlParameter prmReturn = new SqlParameter();
        //        prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
        //        prmReturn.SqlDbType = SqlDbType.Int;
        //        queryObj.Parameters.Add(prmReturn);
        //        conObj.Open();
        //        queryObj.ExecuteNonQuery();
        //        return Convert.ToInt32(prmReturn.Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conObj.Close();
        //    }
        //}


    }
}
