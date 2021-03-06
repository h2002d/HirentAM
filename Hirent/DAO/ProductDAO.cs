﻿using Hirent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace Hirent.DAO
{
    public class ProductDAO : DAO
    {
        internal void saveProduct(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_SaveProduct", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (product.Id == null)
                        {
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Id", product.Id);
                        }

                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@ImageSource", product.ImageSource);
                        command.Parameters.AddWithValue("@ImageSource1", product.ImageSource1);
                        command.Parameters.AddWithValue("@ImageSource2", product.ImageSource2);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal object GetProductsByQuery(string query, bool forAdmin)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetProductByQuery", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@query", query);
                        var rdr = command.ExecuteReader();

                        var productList = new List<Product>();
                        while (rdr.Read())
                        {
                            var product = new Product();
                            product.Id = Convert.ToInt32(rdr["Id"]);
                            product.Price = Convert.ToDecimal(rdr["Price"]);
                            product.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            if (!forAdmin)
                            {
                                string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                                try
                                {
                                    product.Name = rdr["Name"].ToString().Split(',')[culture.Equals("AM") ? 0 : culture.Equals("RU") ? 1 : culture.Equals("EN") ? 2 : 0];
                                }
                                catch
                                {
                                    product.Name = rdr["Name"].ToString().Split(',')[0];
                                }
                            }
                            else
                            {
                                product.Name = rdr["Name"].ToString();
                            }
                            product.ImageSource = rdr["ImageSource"].ToString();
                            product.ImageSource1 = rdr["ImageSource1"].ToString();
                            product.ImageSource2 = rdr["ImageSource2"].ToString();
                            productList.Add(product);
                        }
                        return productList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void deleteProduct(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteProduct", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<Product> GetProducts(int? id, bool forAdmin)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetProduct", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                        {
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Id", id);
                        }
                        var rdr = command.ExecuteReader();

                        var productList = new List<Product>();
                        while (rdr.Read())
                        {
                            var product = new Product();
                            product.Id = Convert.ToInt32(rdr["Id"]);
                            product.Price = Convert.ToDecimal(rdr["Price"]);
                            product.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            if (!forAdmin)
                            {
                                string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                                try
                                {
                                    product.Name = rdr["Name"].ToString().Split(',')[culture.Equals("AM") ? 0 : culture.Equals("RU") ? 1 : culture.Equals("EN") ? 2 : 0];
                                }
                                catch
                                {
                                    product.Name = rdr["Name"].ToString().Split(',')[0];
                                }
                            }
                            else
                            {
                                product.Name = rdr["Name"].ToString();
                            }
                            product.ImageSource = rdr["ImageSource"].ToString();
                            product.ImageSource1 = rdr["ImageSource1"].ToString();
                            product.ImageSource2 = rdr["ImageSource2"].ToString();
                            productList.Add(product);
                        }
                        return productList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<Product> GetProductsByCategoryId(int id, bool forAdmin)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetProductByCategoryId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", id);

                        var rdr = command.ExecuteReader();
                        var productList = new List<Product>();
                        while (rdr.Read())
                        {
                            var product = new Product();
                            product.Id = Convert.ToInt32(rdr["Id"]);
                            product.Price = Convert.ToDecimal(rdr["Price"]);
                            product.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            if (!forAdmin)
                            {
                                string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                                try
                                {
                                    product.Name = rdr["Name"].ToString().Split(',')[culture.Equals("AM") ? 0 : culture.Equals("RU") ? 1 : culture.Equals("EN") ? 2 : 0];
                                }
                                catch
                                {
                                    product.Name = rdr["Name"].ToString().Split(',')[0];
                                }
                            }
                            else
                            {
                                product.Name = rdr["Name"].ToString();
                            }
                            product.ImageSource = rdr["ImageSource"].ToString();
                            product.ImageSource1 = rdr["ImageSource1"].ToString();
                            product.ImageSource2 = rdr["ImageSource2"].ToString();
                            productList.Add(product);
                        }
                        return productList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}