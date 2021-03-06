﻿using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace Projeto_Integrado
{
    public class DBclass
    {

            public static MySqlConnection mConn;
            //buscar das variaveis de programa
            static string connectionstring = "server=localhost; database=eclinic;" + "uid=root; pwd='fa1509'";
            static MySqlConnectionStringBuilder myCSB = new MySqlConnectionStringBuilder();

            static public String hostDB { get; set; }

            static public String userDB { get; set; }

            static public String passwdDB { get; set; }

            static public String Database { get; set; }


            public static void Conectar()
            {
                //tenta a conexão com o banco
                try
                {

                    mConn = new MySqlConnection(connectionstring); //atribui a string de conexão a variavel mConn
                    mConn.Open();

                }
                catch (MySqlException e)
                {
                    throw e;
                }
            }

            public static void ExecuteNonQuery(MySqlCommand commS)
            {

                if (mConn.State == ConnectionState.Open)
                {
                    /*Representa uma instrução SQL a ser executada
                     * Neste caso, o construtor recebe como parâmetro o comando SQL 
                     * e a conexão
                     */

                    //Executa a SQL no banco de dados. 
                    //Tratamento de exceção
                    try
                    {
                        int i = commS.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    {
                        throw e;

                    }
                }

            }

            public static DataTable ExecuteQuery(MySqlCommand commS)
            {


                if (mConn.State == ConnectionState.Open)
                {

                    //Executa a SQL no banco de dados
                    try
                    {

                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = commS;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;

                    }
                    catch (MySqlException e)
                    {
                        throw e;

                    }

                }
                return null;


            }

            /// <summary>
            /// Cria uma string de conexão e retorna-o
            /// </summary>
            /// <returns>string</returns>

            static public string createStringConnection()
            {

                myCSB.Server = hostDB;
                myCSB.UserID = userDB;
                myCSB.Password = passwdDB;
                myCSB.Database = Database;
                connectionstring = myCSB.ConnectionString;
                return myCSB.ConnectionString;

            }


            static public void Close()
            {
                mConn.Close();
                mConn.Dispose();

            }
            /*void recuperaConn()
            {
                if (System.Configuration.ConfigurationManager.AppSettings["serverDB"] != null)
                {
                }
            }*/
        }
}