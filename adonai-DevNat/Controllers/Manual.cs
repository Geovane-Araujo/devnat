using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adonai_DevNat.Controllers
{
    public class Util
    {
        public static String Model(String[] coluna, String[] tipo, String package, String classe)
        {
            String atributo = "";
            String atributo2 = "";
            String tipoatributo = "";
            var aux = "";
            var aux2 = "";

            String codigo = "package " + package + ".model;\n\n";
            codigo += "import java.io.Serializable; \n\n";
            codigo += "public class " + classe + " implements Serializable {\n\n\n";
            codigo += "    private static final long serialVersionUID = 1L;\n\n";
            codigo += "    private boolean add;\n\n";
            codigo += "    private boolean edit;\n\n";
            codigo += "    private boolean del;\n\n";

            for (int i = 0; i < coluna.Length; i++)
            {
                if (tipo[i].Equals("integer"))
                {
                    tipoatributo = "int";
                }
                else if (tipo[i].Equals("character varying"))
                {
                    tipoatributo = "String";
                }
                else if (tipo[i].Equals("real"))
                {
                    tipoatributo = "double";
                }
                else if (tipo[i].Equals("text"))
                {
                    tipoatributo = "String";
                }
                else if (tipo[i].Equals("double precision"))
                {
                    tipoatributo = "double";
                }
                else if (tipo[i].Equals("byte"))
                {
                    tipoatributo = "byte";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "bytes";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "long";
                }
                else if (tipo[i].Equals("timestamp without time zone"))
                {
                    tipoatributo = "Timestamp";
                }
                else if (tipo[i].Equals("date"))
                {
                    tipoatributo = "Date";
                }

                aux = coluna[i];
                atributo = char.ToLower(aux[0]) + aux.Substring(1);
                codigo += "    private " + tipoatributo + " " + atributo + "; \n\n";
            }

            // getters and setters
            codigo += "    public boolean isAdd() { \n";
            codigo += "        return add;\n";
            codigo += "    }\n\n";


            codigo += "    public void setAdd(boolean add) { \n";
            codigo += "        this.add = add;\n";
            codigo += "    }\n\n";

            codigo += "    public boolean isEdit() { \n";
            codigo += "        return edit;\n";
            codigo += "    }\n\n";


            codigo += "    public void setEdit(boolean edit) { \n";
            codigo += "        this.edit = edit;\n";
            codigo += "    }\n\n";

            codigo += "    public boolean isDel() { \n";
            codigo += "        return del;\n";
            codigo += "    }\n\n";


            codigo += "    public void setDel(boolean del) { \n";
            codigo += "        this.del = del;\n";
            codigo += "    }\n\n";


            for (int i = 0; i < coluna.Length; i++)
            {
                if (tipo[i].Equals("integer"))
                {
                    tipoatributo = "int";
                }
                else if (tipo[i].Equals("character varying"))
                {
                    tipoatributo = "String";
                }
                else if (tipo[i].Equals("real"))
                {
                    tipoatributo = "double";
                }
                else if (tipo[i].Equals("text"))
                {
                    tipoatributo = "String";
                }
                else if (tipo[i].Equals("double precision"))
                {
                    tipoatributo = "double";
                }
                else if (tipo[i].Equals("byte"))
                {
                    tipoatributo = "byte";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "bytes";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "long";
                }
                else if (tipo[i].Equals("timestamp without time zone"))
                {
                    tipoatributo = "Timestamp";
                }
                else if (tipo[i].Equals("date"))
                {
                    tipoatributo = "Date";
                }

                aux = coluna[i];
                atributo = char.ToUpper(aux[0]) + aux.Substring(1);
                aux2 = coluna[i];
                atributo2 = char.ToLower(aux2[0]) + aux.Substring(1);

                // getters
                codigo += "    public " + tipoatributo + " get" + atributo + "() { \n";
                codigo += "        return " + atributo2 + ";\n";
                codigo += "    }\n\n\n";

                //setter
                codigo += "    public void set" + atributo + "(" + tipoatributo + " " + atributo2 + ") { \n";
                codigo += "        this." + atributo2 + " = " + atributo2 + ";\n";
                codigo += "    }\n\n";
            }
            codigo += "\n}";


            return codigo;
        }

        public static String Resource(String[] coluna, String[] tipo, String package, String classe, String endPoint, Boolean requerToken)
        {

            String atributo = "";
            var aux = "";
            char aspas = (char)34;

            String codigo = "package " + package + ".resource;\n\n";

            codigo += "import com.adonaisoft.AdonaiSoft.controller." + classe + "Controller;\n";
            codigo += "import com.adonaisoft.AdonaiSoft.model." + classe + ";\n";
            codigo += "import org.springframework.http.ResponseEntity; \n";
            codigo += "import org.springframework.web.bind.annotation.*; \n";
            codigo += "import org.springframework.beans.factory.annotation.Autowired; \n";
            codigo += "import java.sql.SQLException; \n\n\n";

            codigo += "@RestController \n";
            codigo += "@RequestMapping(value = " + aspas + "/" + endPoint + aspas + ") \n";
            codigo += "@CrossOrigin(origins =" + aspas + "*" + aspas + ") \n";
            codigo += "public class " + classe + "Resource {\n\n\n";

            aux = classe;
            atributo = char.ToLower(aux[0]) + aux.Substring(1);
            var atr = atributo + "controller";

            codigo += "    @Autowired\n";
            codigo += "    private " + classe + "Controller " + atr.ToLower() + ";\n\n";
            // save
            codigo += "    @PostMapping(" + aspas + "/" + atributo.ToLower() + aspas + ") \n";
            if (requerToken == true)
            {
                codigo += "    public ResponseEntity<?> save(@RequestHeader(value = " + aspas + "Authorization" + aspas + ")String token, @RequestBody " + classe + " " + atributo.ToLower() + "){\n\n";
                codigo += "        Object obj = \"\";\n" +
                          "        Hashtable retorno = new Hashtable();\n" +
                          "        try {\n" +
                          "            obj = " + atr.ToLower() + ".save(token," + atributo.ToLower() + ");\n" +
                          "            retorno.put(\"ret\", \"success\");\n" +
                          "            retorno.put(\"motivo\", \"OK\");\n" +
                          "            retorno.put(\"obj\", obj);\n" +
                          "        }\n" +
                          "        catch (SQLException e){\n" +
                          "            retorno.put(\"ret\", \"unsuccess\");\n" +
                          "            retorno.put(\"motivo\", e.getMessage());\n" +
                          "        }\n" +
                          "        return ResponseEntity.ok().body(retorno);";
            }
            else
            {
                codigo += "    public ResponseEntity<?> save(@RequestBody " + classe + " " + atributo.ToLower() + ") {\n\n";
                codigo += "        Object obj = \"\";\n" +
                          "        Hashtable retorno = new Hashtable();\n" +
                          "        try {\n" +
                          "            obj = " + atr.ToLower() + ".save(" + atributo.ToLower() + ");\n" +
                          "            retorno.put(\"ret\", \"success\");\n" +
                          "            retorno.put(\"motivo\", \"OK\");\n" +
                          "            retorno.put(\"obj\", obj);\n" +
                          "        }\n" +
                          "        catch (SQLException e){\n" +
                          "            retorno.put(\"ret\", \"unsuccess\");\n" +
                          "            retorno.put(\"motivo\", e.getMessage());\n" +
                          "        }\n" +
                          "        return ResponseEntity.ok().body(retorno);\n";
            }
            codigo += "    }\n";

            codigo += "}\n\n\n";

            // getbyId
            codigo += "    @GetMapping(" + aspas + "/" + atributo.ToLower() + "/{id}" + aspas + ") \n";
            if (requerToken == true)
            {

                codigo += "    public ResponseEntity<?> get(@RequestHeader(value = " + aspas + "Authorization" + aspas + ")String token, @PathVariable(value=" + aspas + "id" + aspas + ") int id) throws SQLException {\n\n";
                codigo += "        Object obj = \"\";\n" +
                          "        Hashtable retorno = new Hashtable();\n" +
                          "        try {\n" +
                          "            obj = " + atr.ToLower() + ".getById(token, id);\n" +
                          "            retorno.put(\"ret\", \"success\");\n" +
                          "            retorno.put(\"motivo\", \"OK\");\n" +
                          "            retorno.put(\"obj\", obj);\n" +
                          "        }\n" +
                          "        catch (SQLException e){\n" +
                          "            retorno.put(\"ret\", \"unsuccess\");\n" +
                          "            retorno.put(\"motivo\", e.getMessage());\n" +
                          "        }\n" +
                          "        return ResponseEntity.ok().body(retorno);\n";
            }
            else
            {
                codigo += "    public ResponseEntity<?> get(@PathVariable(value=" + aspas + "id " + aspas + ") int id) throws SQLException {\n\n";
                codigo += "        Object obj = \"\";\n" +
                          "        Hashtable retorno = new Hashtable();\n" +
                          "        try {\n" +
                          "            obj = " + atr.ToLower() + ".getById(id);\n" +
                          "            retorno.put(\"ret\", \"success\");\n" +
                          "            retorno.put(\"motivo\", \"OK\");\n" +
                          "            retorno.put(\"obj\", obj);\n" +
                          "        }\n" +
                          "        catch (SQLException e){\n" +
                          "            retorno.put(\"ret\", \"unsuccess\");\n" +
                          "            retorno.put(\"motivo\", e.getMessage());\n" +
                          "        }\n" +
                          "        return ResponseEntity.ok().body(retorno);\n";
            }
            codigo += "    }\n";

            codigo += "}\n\n\n";

            return codigo;
        }

        public static String Controller(String[] coluna, String[] tipo, String package, String classe, String tabela, String[] fk, String[] fktableref, Boolean requerToken, String dbTokenTalse)
        {

            String atributo = "";
            String tipoatributo = "";
            var aux = "";
            String sql = "";
            char aspas = (char)34;
            String column = "";

            String codigo = "package " + package + ".controller;\n\n";


            codigo += "    import " + package + ".model." + classe + ";\n";
            codigo += "    import com.adonaisoft.AdonaiSoft.adonaisoftutil.UtilToken;\n";
            codigo += "    import com.adonaisoft.AdonaiSoft.connection.Connect;\n";
            codigo += "    import org.springframework.web.bind.annotation.RestController;\n";
            codigo += "    import java.sql.Connection;\n";
            codigo += "    import java.sql.PreparedStatement;\n";
            codigo += "    import java.sql.ResultSet;\n";
            codigo += "    import java.sql.SQLException;\n";
            codigo += "    import java.util.Hashtable;\n\n";



            codigo += "    @RestController\n";
            codigo += "    public class " + classe + "Controller {\n\n\n";
            codigo += "    Connect connection = new Connect();\n";
            codigo += "    UtilController util = new UtilController();\n";
            codigo += "    String sql =" + aspas + "" + aspas + " ;\n";
            codigo += "    String descricao = " + aspas + "Cadastro." + classe + aspas + ";\n";
            codigo += "    String log =" + aspas + "" + aspas + " ;\n\n\n\n";

            aux = classe;
            atributo = char.ToLower(aux[0]) + aux.Substring(1);

            if (requerToken == true)
            {
                codigo += "    public Object save(String token, " + classe + " " + atributo.ToLower() + ") throws SQLException {\n\n";

                codigo += "        Connection con = null;\n";
                codigo += "        PreparedStatement stmt = null;\n";
                codigo += "        ResultSet rs = null;\n\n";
                codigo += "        Hashtable retorno = new Hashtable();\n\n";
                codigo += "        int scalar = 0;\n\n";
                codigo += "        String decode = UtilToken.decode(token);\n";
                codigo += "        con = connection.Conexao(decode);\n\n";
            }
            else
            {
                codigo += "    public Object save(" + classe + " " + atributo.ToLower() + ") throws SQLException {\n\n";

                codigo += "        Connection con = null;\n";
                codigo += "        PreparedStatement stmt = null;\n";
                codigo += "        ResultSet rs = null;\n\n";
                codigo += "        Hashtable retorno = new Hashtable();\n\n";
                codigo += "        int scalar = 0;\n\n";
                codigo += "        con = connection.Conexao(" + aspas + dbTokenTalse + aspas + ");\n\n";
            }
            // save


            codigo += "        con.setAutoCommit(false);\n\n";

            // add
            codigo += "        if(" + atributo.ToLower() + ".isAdd()){\n\n";

            String values = "";
            for (int i = 1; i < coluna.Length; i++)
            {
                sql = sql + " " + coluna[i] + ",";
                values += "?,";
            }

            codigo += "            sql = " + aspas + "INSERT INTO " + tabela + "(" + sql.Substring(0, sql.Length - 1) + ") VALUES(" + values.Substring(0, values.Length - 1) + ");" + aspas + ";\n\n";
            codigo += "            stmt = con.prepareStatement(sql);\n\n";
            int a = 1;
            for (int i = 1; i < coluna.Length; i++)
            {
                if (tipo[i].Equals("integer"))
                {
                    tipoatributo = "stmt.setInt(";
                }
                else if (tipo[i].Equals("character varying"))
                {
                    tipoatributo = "stmt.setString(";
                }
                else if (tipo[i].Equals("real"))
                {
                    tipoatributo = "stmt.setDouble(";
                }
                else if (tipo[i].Equals("text"))
                {
                    tipoatributo = "stmt.setString(";
                }
                else if (tipo[i].Equals("double precision"))
                {
                    tipoatributo = "stmt.setDouble(";
                }
                else if (tipo[i].Equals("byte"))
                {
                    tipoatributo = "stmt.setByte(";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "stmt.setBytea(";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "stmt.setLong(";
                }
                else if (tipo[i].Equals("timestamp without time zone"))
                {
                    tipoatributo = "stmt.setTimestamp(";
                }
                else if (tipo[i].Equals("date"))
                {
                    tipoatributo = "stmt.setDate(";
                }

                aux = coluna[i];
                column = char.ToUpper(aux[0]) + aux.Substring(1);


                codigo += "            " + tipoatributo + +a + ", " + atributo.ToLower() + ".get" + column + "());\n";
                a = a + 1;
            }
            codigo += "            \n\n";
            codigo += "            log = " + aspas + "Adicionaou" + aspas + ";\n";
            codigo += "        }\n";


            // edit
            codigo += "        else if(" + atributo.ToLower() + ".isEdit()){\n\n";

            sql = "";
            for (int i = 1; i < coluna.Length; i++)
            {
                sql = sql + coluna[i] + " = ?,";
            }



            codigo += "            sql = " + aspas + "UPDATE " + tabela + " SET " + sql.Substring(0, sql.Length - 1) + " WHERE id = ?" + aspas + ";\n\n";
            codigo += "            stmt = con.prepareStatement(sql);\n\n";
            a = coluna.Length;
            for (int i = (coluna.Length - 1); i > 0; i--)
            {
                if (tipo[i].Equals("integer"))
                {
                    tipoatributo = "stmt.setInt(";
                }
                else if (tipo[i].Equals("character varying"))
                {
                    tipoatributo = "stmt.setString(";
                }
                else if (tipo[i].Equals("real"))
                {
                    tipoatributo = "stmt.setDouble(";
                }
                else if (tipo[i].Equals("text"))
                {
                    tipoatributo = "stmt.setString(";
                }
                else if (tipo[i].Equals("double precision"))
                {
                    tipoatributo = "stmt.setDouble(";
                }
                else if (tipo[i].Equals("byte"))
                {
                    tipoatributo = "stmt.setByte(";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "stmt.setBytea(";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "stmt.setLong(";
                }
                else if (tipo[i].Equals("timestamp without time zone"))
                {
                    tipoatributo = "stmt.setTimestamp(";
                }
                else if (tipo[i].Equals("date"))
                {
                    tipoatributo = "stmt.setDate(";
                }

                aux = coluna[i];
                column = char.ToUpper(aux[0]) + aux.Substring(1);


                codigo = codigo + "            " + tipoatributo + a + ", " + atributo.ToLower() + ".get" + column + "());\n";
                a = a - 1;
            }
            codigo += "            stmt.setInt(" + a + ", " + atributo.ToLower() + ".getId());\n";

            codigo += "            \n\n";
            codigo += "            log = " + aspas + "Editou" + aspas + ";\n";
            codigo += "        }\n";


            // del
            codigo += "        else if(" + atributo.ToLower() + ".isDel()){\n\n";

            aux = coluna[0];
            column = char.ToLower(aux[0]) + aux.Substring(1);

            codigo += "            sql = " + aspas + "DELETE FROM " + tabela + " WHERE id = " + aspas + "+" + atributo.ToLower() + ".getId();\n\n";
            codigo += "            stmt = con.prepareStatement(sql);\n\n";

            codigo += "            log = " + aspas + "Apagou" + aspas + ";\n\n";
            codigo += "        }\n\n";

            codigo += "        stmt.execute();\n";
            codigo += "        con.commit();\n";
            codigo += "        con.close();\n";
            codigo += "        stmt.close();\n";
            codigo += "        return " + atributo.ToLower() + ";\n";
            codigo += "    }\n";


            if (requerToken == true)
            {
                codigo += "    public Object getById(String token, int id) throws SQLException {\n\n";

                codigo += "        sql = " + aspas + "SELECT  " + aspas + ";\n";

                codigo += "        Connection con = null;\n";
                codigo += "        PreparedStatement stmt = null;\n";
                codigo += "        ResultSet rs = null;\n";
                codigo += "        Hashtable retorno = new Hashtable();\n\n";


                codigo += "        String decode = UtilToken.decode(token);\n";
                codigo += "        con = connection.Conexao(decode);\n";
            }
            else
            {
                codigo += "    public Object getById(int id) throws SQLException {\n\n";

                codigo += "        sql = " + aspas + "SELECT  " + aspas + ";\n";

                codigo += "        Connection con = null;\n";
                codigo += "        PreparedStatement stmt = null;\n";
                codigo += "        ResultSet rs = null;\n";
                codigo += "        Hashtable retorno = new Hashtable();\n\n";

                codigo += "        con = connection.Conexao(" + aspas + dbTokenTalse + aspas + ");\n\n";
            }

            codigo += "            stmt = con.prepareStatement(sql);\n";
            codigo += "            rs = stmt.executeQuery();\n\n";

            codigo += "            while(rs.next()){\n\n";


            codigo += "            }\n";



            codigo += "        con.close();\n";
            codigo += "        rs.close();\n";
            codigo += "        stmt.close();\n";
            codigo += "        return " + atributo.ToLower() + ";\n";
            codigo += "    }\n";


            codigo += "}\n\n\n";

            return codigo;
        }
    }
}
