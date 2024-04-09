using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sql_topicos_sc.datamethods;

namespace sql_topicos_sc
{
    internal class Events
    {
        datamethods data = new datamethods();
        public void Click_AddFarmacias(object sender, EventArgs e)
        {
            int id_farmacia;
            string nombre;
            string telefono;
            string domicilio;
            int id_ciudad;
            int id_propietario;
            data.add_farmacias(id_farmacia,nombre,telefono,
                domicilio,id_ciudad,id_propietario);
        }
        public void Click_Addmedicamentos(object sender, EventArgs e)
        {
            int id_medicamento;
            string nombre;
            string componentes;
            string comercial;
            data.add_medicamentos(id_medicamento, nombre, 
                componentes,comercial);
        }
        public void Click_Addpropietarios(object sender, EventArgs e)
        {
            int id_propietario;
            string nombre;
            string ciudad;
            string calle;
            string numero_calle;
            string cp;
            data.add_propietarios(id_propietario,nombre,ciudad,calle,numero_calle,cp);
        }
        public void Click_Addciudades(object sender, EventArgs e)
        {
            int id_ciudades;
            string nombre;
            string estado;
            string superficie;
            string poblacion;
            data.add_ciudades(id_ciudades,nombre,estado,superficie,poblacion);
        }
        public void Click_Addclientes(object sender, EventArgs e)
        {
            int id_clientes;
            string nombre;
            string telefono;
            string correo;
            string calle;
            string numero_calle;
            string cp;
            string rfc;
            data.add_clientes(id_clientes,nombre,telefono,correo,calle,numero_calle,cp,rfc);
        }
        public void Click_Addtickets(object sender, EventArgs e)
        {
            int id_tickets;
            string fecha;
            string hora;
            string costo_total;
            string id_cliente;
            data.add_tickets(id_tickets,fecha,hora,costo_total,id_cliente);
        }
        public void Click_AddDetallesMed(object sender, EventArgs e)
        {
            int id_farmacia;
            int id_medicamento;
            data.add_detalles_medicamentos(id_farmacia,id_medicamento);
        }
        public void Click_AddDetallesCom(object sender, EventArgs e)
        {
            int id_ticket;
            int id_medicamento;
            data.add_detalles_compras(id_ticket,id_medicamento);
        }
    }
}
