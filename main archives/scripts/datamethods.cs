using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using static sql_topicos_sc.forms;

namespace sql_topicos_sc
{
    internal class datamethods
    {
        private static datamethods _instance;

        private string connectionstring =
        "Data Source=.\\LOCALHOST; Initial Catalog=topicos_farmacias; Integrated Security=True";
        //private string connectionstring =
        //"Data Source=.\\SQLEXPRESS; Initial Catalog=topicos_farmacias; integrated security=true";
        SqlConnection _connection;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        string query;
        DataTable dataTable;
        readerGrid reader;

        public datamethods()
        {
            _connection = new SqlConnection(connectionstring);
        }

        public static datamethods Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new datamethods();
                }
                return _instance;
            }
        }

        //añadir
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
        public void add_medicamentos(int _id_medicamento, string _nombre,
            string _componentes, string _comercial)
        {
            try
            {
                _connection.Open();
                query = "insert into medicamentos (id_medicamento, nombre, componentes, comercial)" +
                        " values (@_id_medicamento, @_nombre, @_componentes, @_comercial)";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_medicamento", _id_medicamento);
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
                cmd.Parameters.AddWithValue("@_nombre", _nombre);
                cmd.Parameters.AddWithValue("@_ciudad", _ciudad);
                cmd.Parameters.AddWithValue("@_calle", _calle);
                cmd.Parameters.AddWithValue("@_numero_calle", _numero_calle);
                cmd.Parameters.AddWithValue("@_cp", _cp);
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
                cmd.Parameters.AddWithValue("@_id_ciudad", _id_ciudad);
                cmd.Parameters.AddWithValue("@_nombre", _nombre);
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
            string _costo_total, int _id_cliente, List<int> _id_medicamentos)
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

                foreach (var id_medicamento in _id_medicamentos)
                {
                    add_detalles_compras(_id_ticket,id_medicamento);
                }
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
        public void add_detalles_medicamentos(int _id_farmacia, List<int> _id_medicamentos)
        {
            try
            {
                _connection.Open();
                foreach (int id_medicamento in _id_medicamentos)
                {
                    query = "insert into detalles_medicamentos (id_farmacia, id_medicamento)"
                        + " values (@_id_farmacia, @_id_medicamento)";
                    cmd = new SqlCommand(query, _connection);
                    cmd.Parameters.AddWithValue("@_id_farmacia", _id_farmacia);
                    cmd.Parameters.AddWithValue("@_id_medicamento", id_medicamento);
                    cmd.ExecuteNonQuery();
                }
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
                cmd.Parameters.AddWithValue("@_id_ticket", _id_ticket);
                cmd.Parameters.AddWithValue("@_id_medicamento", _id_medicamento);
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

        //eliminar
        public void remove_farmacias(int _id_farmacia = -1, string _nombre = null, string _telefono = null,
    string _domicilio = null, int _id_ciudad = -1, int _id_propietario = -1)
        {
            try
            {
                _connection.Open();
                string conditions = "";
                if (_id_farmacia != -1)
                {
                    conditions += "id_farmacia = @_id_farmacia AND ";
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    conditions += "nombre = @_nombre AND ";
                }
                if (!string.IsNullOrEmpty(_telefono))
                {
                    conditions += "telefono = @_telefono AND ";
                }
                if (!string.IsNullOrEmpty(_domicilio))
                {
                    conditions += "domicilio = @_domicilio AND ";
                }
                if (_id_ciudad != -1)
                {
                    conditions += "id_ciudad = @_id_ciudad AND ";
                }
                if (_id_propietario != -1)
                {
                    conditions += "id_propietario = @_id_propietario AND ";
                }
                conditions = conditions.TrimEnd("AND ".ToCharArray()); // Remove trailing "AND "

                query = $"DELETE FROM farmacias WHERE {conditions}";
                cmd = new SqlCommand(query, _connection);
                if (_id_farmacia != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_farmacia", _id_farmacia);
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    cmd.Parameters.AddWithValue("@_nombre", _nombre);
                }
                if (!string.IsNullOrEmpty(_telefono))
                {
                    cmd.Parameters.AddWithValue("@_telefono", _telefono);
                }
                if (!string.IsNullOrEmpty(_domicilio))
                {
                    cmd.Parameters.AddWithValue("@_domicilio", _domicilio);
                }
                if (_id_ciudad != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_ciudad", _id_ciudad);
                }
                if (_id_propietario != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_propietario", _id_propietario);
                }

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
        public void remove_medicamentos(int _id_medicamento = -1, string _nombre = null,
    string _componentes = null, string _comercial = null)
        {
            try
            {
                _connection.Open();
                string conditions = "";
                if (_id_medicamento != -1)
                {
                    conditions += "id_medicamento = @_id_medicamento AND ";
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    conditions += "nombre = @_nombre AND ";
                }
                if (!string.IsNullOrEmpty(_componentes))
                {
                    conditions += "componentes = @_componentes AND ";
                }
                if (!string.IsNullOrEmpty(_comercial))
                {
                    conditions += "comercial = @_comercial AND ";
                }
                conditions = conditions.TrimEnd("AND ".ToCharArray()); // Remove trailing "AND "

                query = $"DELETE FROM medicamentos WHERE {conditions}";
                cmd = new SqlCommand(query, _connection);
                if (_id_medicamento != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_medicamento", _id_medicamento);
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    cmd.Parameters.AddWithValue("@_nombre", _nombre);
                }
                if (!string.IsNullOrEmpty(_componentes))
                {
                    cmd.Parameters.AddWithValue("@_componentes", _componentes);
                }
                if (!string.IsNullOrEmpty(_comercial))
                {
                    cmd.Parameters.AddWithValue("@_comercial", _comercial);
                }

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
        public void remove_propietarios(int _id_propietario = -1, string _nombre = null,
    string _ciudad = null, string _calle = null, string _numero_calle = null, string _cp = null)
        {
            try
            {
                _connection.Open();
                string conditions = "";
                if (_id_propietario != -1)
                {
                    conditions += "id_propietario = @_id_propietario AND ";
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    conditions += "nombre = @_nombre AND ";
                }
                if (!string.IsNullOrEmpty(_ciudad))
                {
                    conditions += "ciudad = @_ciudad AND ";
                }
                if (!string.IsNullOrEmpty(_calle))
                {
                    conditions += "calle = @_calle AND ";
                }
                if (!string.IsNullOrEmpty(_numero_calle))
                {
                    conditions += "numero_calle = @_numero_calle AND ";
                }
                if (!string.IsNullOrEmpty(_cp))
                {
                    conditions += "cp = @_cp AND ";
                }
                conditions = conditions.TrimEnd("AND ".ToCharArray()); // Remove trailing "AND "

                query = $"DELETE FROM propietarios WHERE {conditions}";
                cmd = new SqlCommand(query, _connection);
                if (_id_propietario != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_propietario", _id_propietario);
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    cmd.Parameters.AddWithValue("@_nombre", _nombre);
                }
                if (!string.IsNullOrEmpty(_ciudad))
                {
                    cmd.Parameters.AddWithValue("@_ciudad", _ciudad);
                }
                if (!string.IsNullOrEmpty(_calle))
                {
                    cmd.Parameters.AddWithValue("@_calle", _calle);
                }
                if (!string.IsNullOrEmpty(_numero_calle))
                {
                    cmd.Parameters.AddWithValue("@_numero_calle", _numero_calle);
                }
                if (!string.IsNullOrEmpty(_cp))
                {
                    cmd.Parameters.AddWithValue("@_cp", _cp);
                }

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
        public void remove_ciudades(int _id_ciudad = -1, string _nombre = null,
    string _estado = null, string _superficie = null, string _poblacion = null)
        {
            try
            {
                _connection.Open();
                string conditions = "";
                if (_id_ciudad != -1)
                {
                    conditions += "id_ciudad = @_id_ciudad AND ";
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    conditions += "nombre = @_nombre AND ";
                }
                if (!string.IsNullOrEmpty(_estado))
                {
                    conditions += "estado = @_estado AND ";
                }
                if (!string.IsNullOrEmpty(_superficie))
                {
                    conditions += "superficie = @_superficie AND ";
                }
                if (!string.IsNullOrEmpty(_poblacion))
                {
                    conditions += "poblacion = @_poblacion AND ";
                }
                conditions = conditions.TrimEnd("AND ".ToCharArray()); // Remove trailing "AND "

                query = $"DELETE FROM ciudades WHERE {conditions}";
                cmd = new SqlCommand(query, _connection);
                if (_id_ciudad != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_ciudad", _id_ciudad);
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    cmd.Parameters.AddWithValue("@_nombre", _nombre);
                }
                if (!string.IsNullOrEmpty(_estado))
                {
                    cmd.Parameters.AddWithValue("@_estado", _estado);
                }
                if (!string.IsNullOrEmpty(_superficie))
                {
                    cmd.Parameters.AddWithValue("@_superficie", _superficie);
                }
                if (!string.IsNullOrEmpty(_poblacion))
                {
                    cmd.Parameters.AddWithValue("@_poblacion", _poblacion);
                }

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
        public void remove_clientes(int _id_cliente = -1, string _nombre = null,
            string _telefono = null, string _correo = null, string _calle = null,
            string _numero_calle = null, string _cp = null, string _rfc = null)
        {
            try
            {
                _connection.Open();
                string conditions = "";
                if (_id_cliente != -1)
                {
                    conditions += "id_cliente = @_id_cliente AND ";
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    conditions += "nombre = @_nombre AND ";
                }
                if (!string.IsNullOrEmpty(_telefono))
                {
                    conditions += "telefono = @_telefono AND ";
                }
                if (!string.IsNullOrEmpty(_correo))
                {
                    conditions += "correo = @_correo AND ";
                }
                if (!string.IsNullOrEmpty(_calle))
                {
                    conditions += "calle = @_calle AND ";
                }
                if (!string.IsNullOrEmpty(_numero_calle))
                {
                    conditions += "numero_calle = @_numero_calle AND ";
                }
                if (!string.IsNullOrEmpty(_cp))
                {
                    conditions += "cp = @_cp AND ";
                }
                if (!string.IsNullOrEmpty(_rfc))
                {
                    conditions += "rfc = @_rfc AND ";
                }
                conditions = conditions.TrimEnd("AND ".ToCharArray()); // Remove trailing "AND "

                query = $"DELETE FROM clientes WHERE {conditions}";
                cmd = new SqlCommand(query, _connection);
                if (_id_cliente != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_cliente", _id_cliente);
                }
                if (!string.IsNullOrEmpty(_nombre))
                {
                    cmd.Parameters.AddWithValue("@_nombre", _nombre);
                }
                if (!string.IsNullOrEmpty(_telefono))
                {
                    cmd.Parameters.AddWithValue("@_telefono", _telefono);
                }
                if (!string.IsNullOrEmpty(_correo))
                {
                    cmd.Parameters.AddWithValue("@_correo", _correo);
                }
                if (!string.IsNullOrEmpty(_calle))
                {
                    cmd.Parameters.AddWithValue("@_calle", _calle);
                }
                if (!string.IsNullOrEmpty(_numero_calle))
                {
                    cmd.Parameters.AddWithValue("@_numero_calle", _numero_calle);
                }
                if (!string.IsNullOrEmpty(_cp))
                {
                    cmd.Parameters.AddWithValue("@_cp", _cp);
                }
                if (!string.IsNullOrEmpty(_rfc))
                {
                    cmd.Parameters.AddWithValue("@_rfc", _rfc);
                }

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
        public void remove_tickets(int _id_ticket = -1, string _fecha = null, string _hora = null,
            string _costo_total = null, int _id_cliente = -1, List<int> _id_medicamentos = null)
        {
            try
            {
                _connection.Open();
                string conditions = "";
                if (_id_ticket != -1)
                {
                    conditions += "id_ticket = @_id_ticket AND ";
                }
                if (!string.IsNullOrEmpty(_fecha))
                {
                    conditions += "fecha = @_fecha AND ";
                }
                if (!string.IsNullOrEmpty(_hora))
                {
                    conditions += "hora = @_hora AND ";
                }
                if (!string.IsNullOrEmpty(_costo_total))
                {
                    conditions += "costo_total = @_costo_total AND ";
                }
                if (_id_cliente != -1)
                {
                    conditions += "id_cliente = @_id_cliente AND ";
                }
                conditions = conditions.TrimEnd("AND ".ToCharArray()); // Remove trailing "AND "

                query = $"DELETE FROM tickets WHERE {conditions}";
                cmd = new SqlCommand(query, _connection);
                if (_id_ticket != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_ticket", _id_ticket);
                }
                if (!string.IsNullOrEmpty(_fecha))
                {
                    cmd.Parameters.AddWithValue("@_fecha", _fecha);
                }
                if (!string.IsNullOrEmpty(_hora))
                {
                    cmd.Parameters.AddWithValue("@_hora", _hora);
                }
                if (!string.IsNullOrEmpty(_costo_total))
                {
                    cmd.Parameters.AddWithValue("@_costo_total", _costo_total);
                }
                if (_id_cliente != -1)
                {
                    cmd.Parameters.AddWithValue("@_id_cliente", _id_cliente);
                }

                cmd.ExecuteNonQuery();

                if (_id_medicamentos != null)
                {
                    foreach (var id_medicamento in _id_medicamentos)
                    {
                        remove_detalles_compras(_id_ticket, id_medicamento);
                    }
                }
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
        public void remove_detalles_compras(int _id_ticket, int _id_medicamento)
        {
            try
            {
                _connection.Open();
                query = "DELETE FROM detalles_compras WHERE id_ticket = @_id_ticket AND id_medicamento = @_id_medicamento";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_ticket", _id_ticket);
                cmd.Parameters.AddWithValue("@_id_medicamento", _id_medicamento);
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
        public void remove_detalles_medicamentos(int _id_ticket, int _id_medicamento)
        {
            try
            {
                _connection.Open();
                query = "DELETE FROM detalles_medicamentos WHERE id_ticket = @_id_ticket AND id_medicamento = @_id_medicamento";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_ticket", _id_ticket);
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

        //modificar
        public void modify_farmacias(int _id_farmacia, string _nombre, string _telefono,
    string _domicilio, int _id_ciudad, int _id_propietario)
        {
            try
            {
                _connection.Open();
                if (_id_farmacia > 0)
                {
                    query = "SELECT COUNT(*) FROM farmacias WHERE id_farmacia = @_id_farmacia";
                    cmd = new SqlCommand(query, _connection);
                    cmd.Parameters.AddWithValue("@_id_farmacia", _id_farmacia);
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        Console.WriteLine("La farmacia con el ID especificado no existe.");
                        return;
                    }

                    query = "UPDATE farmacias SET nombre = @_nombre, telefono = @_telefono, " +
                            "domicilio = @_domicilio, id_ciudad = @_id_ciudad, " +
                            "id_propietario = @_id_propietario WHERE id_farmacia = @_id_farmacia";
                }
                else
                {
                    Console.WriteLine("Ingrese un ID de la farmacia para realizar la modificación.");
                    return;
                }

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
        public void modify_medicamentos(int _id_medicamento, string _nombre,
    string _componentes, string _comercial)
        {
            try
            {
                _connection.Open();
                if (_id_medicamento > 0)
                {
                    query = "UPDATE medicamentos SET nombre = @_nombre, componentes = @_componentes, " +
                            "comercial = @_comercial WHERE id_medicamento = @_id_medicamento";
                }
                else
                {
                    Console.WriteLine("Falta el ID del medicamento para realizar la modificación.");
                    return;
                }

                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_medicamento", _id_medicamento);
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

        public void modify_propietarios(int _id_propietario, string _nombre,
            string _ciudad, string _calle, string _numero_calle, string _cp)
        {
            try
            {
                _connection.Open();
                if (_id_propietario > 0)
                {
                    query = "UPDATE propietarios SET nombre = @_nombre, ciudad = @_ciudad, " +
                            "calle = @_calle, numero_calle = @_numero_calle, cp = @_cp " +
                            "WHERE id_propietario = @_id_propietario";
                }
                else
                {
                    Console.WriteLine("Falta el ID del propietario para realizar la modificación.");
                    return;
                }

                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_propietario", _id_propietario);
                cmd.Parameters.AddWithValue("@_nombre", _nombre);
                cmd.Parameters.AddWithValue("@_ciudad", _ciudad);
                cmd.Parameters.AddWithValue("@_calle", _calle);
                cmd.Parameters.AddWithValue("@_numero_calle", _numero_calle);
                cmd.Parameters.AddWithValue("@_cp", _cp);
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

        public void modify_ciudades(int _id_ciudad, string _nombre,
            string _estado, string _superficie, string _poblacion)
        {
            try
            {
                _connection.Open();
                if (_id_ciudad > 0)
                {
                    query = "UPDATE ciudades SET nombre = @_nombre, estado = @_estado, " +
                            "superficie = @_superficie, poblacion = @_poblacion " +
                            "WHERE id_ciudad = @_id_ciudad";
                }
                else
                {
                    Console.WriteLine("Falta el ID de la ciudad para realizar la modificación.");
                    return;
                }

                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_ciudad", _id_ciudad);
                cmd.Parameters.AddWithValue("@_nombre", _nombre);
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

        public void modify_clientes(int _id_cliente, string _nombre,
            string _telefono, string _correo, string _calle,
            string _numero_calle, string _cp, string _rfc)
        {
            try
            {
                _connection.Open();
                if (_id_cliente > 0)
                {
                    query = "UPDATE clientes SET nombre = @_nombre, telefono = @_telefono, " +
                            "correo = @_correo, calle = @_calle, numero_calle = @_numero_calle, " +
                            "cp = @_cp, rfc = @_rfc WHERE id_cliente = @_id_cliente";
                }
                else
                {
                    Console.WriteLine("Falta el ID del cliente para realizar la modificación.");
                    return;
                }

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

        public void modify_tickets(int _id_ticket, string _fecha, string _hora,
            string _costo_total, int _id_cliente, List<int> _id_medicamentos)
        {
            try
            {
                _connection.Open();
                if (_id_ticket > 0)
                {
                    query = "UPDATE tickets SET fecha = @_fecha, hora = @_hora, " +
                            "costo_total = @_costo_total, id_cliente = @_id_cliente " +
                            "WHERE id_ticket = @_id_ticket";
                }
                else
                {
                    Console.WriteLine("Falta el ID del ticket para realizar la modificación.");
                    return;
                }

                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_ticket", _id_ticket);
                cmd.Parameters.AddWithValue("@_fecha", _fecha);
                cmd.Parameters.AddWithValue("@_hora", _hora);
                cmd.Parameters.AddWithValue("@_costo_total", _costo_total);
                cmd.Parameters.AddWithValue("@_id_cliente", _id_cliente);
                cmd.ExecuteNonQuery();

                // Limpiar los detalles de las compras existentes
                query = "DELETE FROM detalles_compras WHERE id_ticket = @_id_ticket";
                cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@_id_ticket", _id_ticket);
                cmd.ExecuteNonQuery();

                // Insertar los nuevos detalles de las compras
                foreach (var id_medicamento in _id_medicamentos)
                {
                    add_detalles_compras(_id_ticket, id_medicamento);
                }
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


        //consultar
        public void see_farmacias()
        {
            try
            {
                mainForm mainForm = new mainForm();
                mainForm.Show();

                _connection.Open();
                query = "select * from farmacias";
                adapter = new SqlDataAdapter(query, _connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                reader = new readerGrid(mainForm);
                reader.DataSource = dataTable;
                mainForm.Controls.Add(reader);
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
        public void see_medicamentos()
        {
            try
            {
                _connection.Open();
                
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
        public void see_propietarios()
        {
            try
            {
                _connection.Open();
                
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
        public void see_ciudades()
        {
            try
            {
                _connection.Open();
                
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
        public void see_clientes()
        {
            try
            {
                _connection.Open();
                
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
        public void see_tickets()
        {
            try
            {
                _connection.Open();
                
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
    }
}
