using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sql_topicos_sc
{
    internal class datamethods
    {
        private string connectionstring =
        "Data Source=.\SQLEXPRESS; Initial Catalog=topicos_farmacias; integrated security=true";
        SqlConnection _connection;
        SqlCommand cmd;
        string query;

        public datamethods()
        {
            _connection = new SqlConnection(connectionstring);
        }

        public void add_farmacias(int _id_farmacia, string _nombre, string _telefono,
            string _domicilio, int _id_ciudad, int _id_propietario)
        {
            try
            {
                _connection.Open();
                query = "insert into farmacias (id_farmacia, nombre, telefono, domicilio, id_ciudad, id_propietario)" +
                        " values (@_id_farmacia, @_nombre, @_telefono, @_domicilio, @_id_ciudad, @_id_propietario)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_farmacia", _id_farmacia);
                cmd.Parameters.AddWithValue("@_nombre", _nombre);
                cmd.Parameters.AddWithValue("@_telefono", _telefono);
                cmd.Parameters.AddWithValue("@_domicilio", _domicilio);
                cmd.Parameters.AddWithValue("@_id_ciudad", _id_ciudad);
                cmd.Parameters.AddWithValue("@_id_propietario", _id_propietario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en farmacias.\n{e.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void add_medicamentos(int _id_medicamentos, string _nombre,
            string _componentes, string _comercial)
        {
            try
            {
                _connection.Open();
                query = "insert into medicamentos (id_medicamento, nombre, componentes, comercial)" +
                        " values (@_id_medicamentos, @_nombre, @_componentes, @_comercial)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_medicamentos", _id_medicamentos);
                cmd.Parameters.AddWithValue("@_nombre", _nombre);
                cmd.Parameters.AddWithValue("@_componentes", _componentes);
                cmd.Parameters.AddWithValue("@_comercial", _comercial);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en medicamentos.\n{e.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void add_propietarios(int _id_propietario, string _nombre,
            string _ciudad, string _calle, string _numero_calle, string _cp)
        {
            try
            {
                _connection.Open();
                query = "insert into propietarios (id_propietario, nombre, ciudad, calle, " +
                    "numero_calle, cp)" +
                    " values (@_id_propietario, @_nombre, @_ciudad, @_calle, " +
                    "@_numero_calle, @_cp)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_propietario", _id_propietario);
                cmd.Parameters.AddWithValue("@_", _nombre);
                cmd.Parameters.AddWithValue("@_", _ciudad);
                cmd.Parameters.AddWithValue("@_", _calle);
                cmd.Parameters.AddWithValue("@_", _numero_calle);
                cmd.Parameters.AddWithValue("@_", _cp);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en propietarios.\n{e.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void add_ciudades(int _id_ciudad, string _nombre,
            string _estado, string _superficie, string _poblacion)
        {
            try
            {
                _connection.Open();
                query = "insert into ciudades (id_ciudad, nombre, "
                    + "estado, superficie, poblacion)"
                    + " values (@_id_ciudad, @_nombre, @_estado" +
                    ", @_superficie, @_poblacion)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_ciudad", _nombre);
                cmd.Parameters.AddWithValue("@_estado", _estado);
                cmd.Parameters.AddWithValue("@_superficie", _superficie);
                cmd.Parameters.AddWithValue("@_poblacion", _poblacion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en ciudades.\n{e.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void add_clientes(int _id_cliente, string _nombre,
            string _telefono, string _correo, string _calle,
            string _numero_calle, string _cp, string _rfc)
        {
            try
            {
                _connection.Open();
                query = "insert into clientes (id_cliente, nombre, telefono, correo,"
                    + "calle, numero_calle, cp, rfc)"
                    + " values (@_id_cliente, @_nombre, @_telefono, @_correo, "
                    + "@_calle, @_numero_calle, @_cp, @_rfc)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_cliente", _id_cliente);
                cmd.Parameters.AddWithValue("@_nombre", _nombre);
                cmd.Parameters.AddWithValue("@_telefono", _telefono);
                cmd.Parameters.AddWithValue("@_correo", _correo);
                cmd.Parameters.AddWithValue("@_calle", _calle);
                cmd.Parameters.AddWithValue("@_numero_calle", _numero_calle);
                cmd.Parameters.AddWithValue("@_cp", _cp);
                cmd.Parameters.AddWithValue("@_rfc", _rfc);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en clientes.\n{e.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void add_tickets(int _id_ticket, string _fecha, string _hora,
            string _costo_total, int _id_cliente)
        {
            try
            {
                _connection.Open();
                query = "insert into tickets (id_ticket, fecha, hora, costo_total, id_cliente)"
                    + "values (@_id_ticket, @_fecha, @_hora, @_costo_total, @_id_cliente)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_ticket", _id_ticket);
                cmd.Parameters.AddWithValue("@_fecha", _fecha);
                cmd.Parameters.AddWithValue("@_hora", _hora);
                cmd.Parameters.AddWithValue("@costo_total", _costo_total);
                cmd.Parameters.AddWithValue("@_id_cliente", _id_cliente);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en tickets.\n{e.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void add_detalles_medicamentos(int _id_farmacia, int _id_medicamento)
        {
            try
            {
                _connection.Open();
                query = "insert into detalles_medicamentos (id_farmacia, id_medicamento)"
                    + " values (@_id_farmacia, @_id_medicamento)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_farmacia", _id_farmacia);
                cmd.Parameters.AddWithValue("@_id_medicamento", _id_medicamento);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en detalles_medicamentos.\n{e.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
        public void add_detalles_compras(int _id_ticket, int _id_medicamento)
        {
            try
            {
                _connection.Open();
                query = "insert into detalles_compras (id_ticket, id_medicamento)"
                    + " values (@_id_ticket, @_id_medicamento)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@id_ticket", _id_ticket);
                cmd.Parameters.AddWithValue("@id_medicamento", _id_medicamento);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en detalles_compras.\n{e.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
