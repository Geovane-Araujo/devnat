using adonai_DevNat.Models;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adonai_DevNat.Controllers
{
    public class Controller
    {

        public Object CreatePostgres(GenerateCode create)
        {
            string code = "";
            Hashtable ret = new Hashtable();

            String model = "";
            String controller = "";
            String resource = "";


            try
            {
                NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=1816;Database=adonai_davnat");
                con.Open();

                NpgsqlConnection cona = new NpgsqlConnection("Host=localhost;Username=postgres;Password=1816;Database=adonai_davnat");
                cona.Open();

                NpgsqlCommand command = new NpgsqlCommand(create.code, con);
                command.ExecuteNonQuery();

                command.Dispose();

                String sql = "SELECT COUNT(column_name) as p FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" + create.tableName + "'";
                command = new NpgsqlCommand(sql, con);

                NpgsqlDataReader rs = command.ExecuteReader();

                int count = 0;

                if (rs.HasRows)
                {

                    while (rs.Read())
                    {

                        count = rs.GetInt32(rs.GetOrdinal("p"));
                    }
                }
                rs.Close();


                String[] coluna = new string[count];
                String[] tipo = new string[count];
                sql = "SELECT column_name as coluna, data_type as tipo FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" + create.tableName + "' ORDER BY ORDINAL_POSITION";
                NpgsqlCommand commandD = new NpgsqlCommand(sql, con);


                rs = commandD.ExecuteReader();

                if (rs.HasRows)
                {
                    int i = 0;
                    while (rs.Read())
                    {

                        coluna[i] = rs.GetString(rs.GetOrdinal("coluna"));
                        tipo[i] = rs.GetString(rs.GetOrdinal("tipo"));
                        i = i + 1;

                    }
                    if (cheModel.Checked)
                    {
                        model = Manual.Model(coluna, tipo, create.package, create.className);
                    }
                    if (cheResource.Checked)
                    {
                         resource = Manual.Resource(coluna, tipo, create.package, create.className, txtendpoint.Text, cheToken.Checked);
                    }
                    if (cheController.Checked)
                    {
                        String sqla = "SELECT COUNT(kcu.column_name) as p " +
                            " FROM  information_schema.table_constraints AS tc " +
                                "JOIN information_schema.key_column_usage AS kcu ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema " +
                                "JOIN information_schema.constraint_column_usage AS ccu ON ccu.constraint_name = tc.constraint_name AND ccu.table_schema = tc.table_schema" +
                            " WHERE tc.constraint_type = 'FOREIGN KEY' AND tc.table_name = '" + create.tableName + "' " +
                            " group by kcu.column_name,ccu.table_name,ccu.column_name";

                        NpgsqlCommand commandE = new NpgsqlCommand(sqla, cona);
                        NpgsqlDataReader rsE = commandE.ExecuteReader();

                        count = 0;
                        if (rsE.HasRows)
                        {

                            while (rsE.Read())
                            {

                                count++;
                            }
                        }
                        rsE.Close();
                        cona.Close();

                        cona.Open();

                        sqla = "SELECT kcu.column_name, ccu.table_name AS tabelaref, ccu.column_name AS columnref, tc.table_name," +
                            " ('INNER JOIN ' || ccu.table_name || ' ON ' || tc.table_name || '.' || kcu.column_name || ' = ' || ccu.table_name || '.' || ccu.column_name )as fk " +
                            " FROM  information_schema.table_constraints AS tc " +
                                "JOIN information_schema.key_column_usage AS kcu ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema " +
                                "JOIN information_schema.constraint_column_usage AS ccu ON ccu.constraint_name = tc.constraint_name AND ccu.table_schema = tc.table_schema" +
                            " WHERE tc.constraint_type = 'FOREIGN KEY' AND tc.table_name = '" + create.tableName + "' " +
                            " group by kcu.column_name,ccu.table_name,ccu.column_name, tc.table_name ";

                        commandE = new NpgsqlCommand(sqla, cona);
                        rsE = commandE.ExecuteReader();


                        String[] fk = new string[count];
                        String[] fktableref = new string[count];

                        if (rsE.HasRows)
                        {
                            i = 0;
                            while (rsE.Read())
                            {
                                fk[i] = rsE.GetString(rsE.GetOrdinal("fk"));
                                fktableref[i] = rsE.GetString(rsE.GetOrdinal("tabelaref"));
                                i = i + 1;
                            }
                        }
                        rsE.Close();
                        String Tabelasref = "";
                        for (i = 0; i < fktableref.Length; i++)
                        {
                            if (fktableref.Equals("pessoa"))
                            {
                                Tabelasref = Tabelasref + fktableref[i] + ".nome, ";
                            }
                            else
                            {
                                Tabelasref = Tabelasref + fktableref[i] + ".descricao, ";
                            }

                        }

                        controller = Manual.Controller(coluna, tipo, create.package, create.className, create.tableName, cheToken.Checked, create.databaseName);
                    }

                    ret.Add("Model", model);
                    ret.Add("Controller", controller);
                    ret.Add("Resource", resource);
                    ret.Add("ret", "success");
                    ret.Add("motivo", "OK");
                }

            }
            catch (Exception ex)
            {
                ret.Add("Model", model);
                ret.Add("Controller", controller);
                ret.Add("Resource", resource);
                ret.Add("ret", "unsuccess");
                ret.Add("motivo", ex.ToString());
            }
            return ret;
        }
    }
}
