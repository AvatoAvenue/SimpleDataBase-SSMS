using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sql_topicos_sc.forms;

namespace sql_topicos_sc
{
    internal class procedure
    {
        private static procedure _instance;

        public static procedure Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new procedure();
                }
                return _instance;
            }
        }

        
        Events events = new Events(_instance);

        private static mainForm mn = new mainForm();

        private groups menuinicial_ = new groups(mn);
        private groups farmacias_ = new groups(mn);
        private groups medicamentos_ = new groups(mn);
        private groups propietarios_ = new groups(mn);
        private groups ciudades_ = new groups(mn);
        private groups clientes_ = new groups(mn);
        private groups tickets_ = new groups(mn);

        private roundButton b_altas;
        private roundButton b_bajas;
        private roundButton b_modificar;
        private roundButton b_consultar;
        
        private roundButton b_menu_inicial;
        private roundButton b_Salir;

        public void inicio()
        {
            menuinicial();
            farmacias();
            medicamentos();
            propietarios();
            ciudades();
            clientes();
            tickets();

            mn.Controls.Add(menuinicial_);
            mn.Controls.Add(farmacias_);
            mn.Controls.Add(medicamentos_);
            mn.Controls.Add(propietarios_);
            mn.Controls.Add(ciudades_);
            mn.Controls.Add(clientes_);
            mn.Controls.Add(tickets_);

            visibility("menuinicial");

            Application.Run(mn);
        }
        public void menuinicial()
        {
            roundButton b_farmacias = new roundButton();
            roundButton b_medicamentos = new roundButton();
            roundButton b_propietarios = new roundButton();
            roundButton b_ciudades = new roundButton();
            roundButton b_clientes = new roundButton();
            roundButton b_tickets = new roundButton();

            b_farmacias.Click += (sender, e) => { visibility("farmacias"); };
            b_medicamentos.Click += (sender, e) => { visibility("medicamentos"); };
            b_propietarios.Click += (sender, e) => { visibility("propietarios"); };
            b_ciudades.Click += (sender, e) => { visibility("ciudades"); };
            b_clientes.Click += (sender, e) => { visibility("clientes"); };
            b_tickets.Click += (sender, e) => { visibility("tickets"); };

            b_farmacias.Text = "Farmacias";
            b_medicamentos.Text = "Medicamentos";
            b_propietarios.Text = "Propietarios";
            b_ciudades.Text = "Ciudades";
            b_clientes.Text = "Clientes";
            b_tickets.Text = "Tickets";

            menuinicial_.Controls.Add(b_farmacias);
            menuinicial_.Controls.Add(b_medicamentos);
            menuinicial_.Controls.Add(b_propietarios);
            menuinicial_.Controls.Add(b_ciudades);
            menuinicial_.Controls.Add(b_clientes);
            menuinicial_.Controls.Add(b_tickets);


            b_Salir = new roundButton();
            b_Salir.Click += events.Click_b_Salir;
            b_Salir.Text = "Salir";
            menuinicial_.Controls.Add(b_Salir);
        }
        public void farmacias()
        {
            ShowControlText SCT_id_farmacia = new ShowControlText();
            ShowControlText SCT_nombre = new ShowControlText();
            ShowControlText SCT_telefono = new ShowControlText();
            ShowControlText SCT_domicilio = new ShowControlText();
            ShowControlText SCT_id_ciudad = new ShowControlText();
            ShowControlText SCT_id_propietario = new ShowControlText();

            inserterText IT_id_farmacia = new inserterText();
            inserterText IT_nombre = new inserterText();
            inserterText IT_telefono = new inserterText();
            inserterText IT_domicilio = new inserterText();
            inserterText IT_id_ciudad = new inserterText();
            inserterText IT_id_propietario = new inserterText();

            farmacias_.Controls.Add(SCT_id_farmacia);
            farmacias_.Controls.Add(SCT_nombre);
            farmacias_.Controls.Add(SCT_telefono);
            farmacias_.Controls.Add(SCT_domicilio);
            farmacias_.Controls.Add(SCT_id_ciudad);
            farmacias_.Controls.Add(SCT_id_propietario);
            farmacias_.Controls.Add(IT_id_farmacia);
            farmacias_.Controls.Add(IT_nombre);
            farmacias_.Controls.Add(IT_telefono);
            farmacias_.Controls.Add(IT_domicilio);
            farmacias_.Controls.Add(IT_id_ciudad);
            farmacias_.Controls.Add(IT_id_propietario);

            b_altas = new roundButton();
            b_altas.Click += events.Click_AddFarmacias;
            b_altas.Text = "Alta";
            farmacias_.Controls.Add(b_altas);
            b_bajas = new roundButton();
            //b_bajas.Click += events.Click_;
            b_bajas.Text = "Baja";
            farmacias_.Controls.Add(b_bajas);
            b_modificar = new roundButton();
            //b_modificar.Click += events.Click_;
            b_modificar.Text = "Modificar";
            farmacias_.Controls.Add(b_modificar);
            b_consultar = new roundButton();
            //b_consultar.Click += events.Click_;
            b_consultar.Text = "Consultar";
            farmacias_.Controls.Add(b_consultar);


            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            farmacias_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += events.Click_b_Salir;
            b_Salir.Text = "Salir";
            farmacias_.Controls.Add(b_Salir);
        }

        public void medicamentos()
        {
            b_altas = new roundButton();
            b_altas.Click += events.Click_Addmedicamentos;
            b_altas.Text = "Alta";
            medicamentos_.Controls.Add(b_altas);
            b_bajas = new roundButton();
            //b_bajas.Click += events.Click_s;
            b_bajas.Text = "Baja";
            medicamentos_.Controls.Add(b_bajas);
            b_modificar = new roundButton();
            //b_modificar.Click += events.Click_;
            b_modificar.Text = "Modificar";
            medicamentos_.Controls.Add(b_modificar);
            b_consultar = new roundButton();
            //b_consultar.Click += events.Click_;
            b_consultar.Text = "Consultar";
            medicamentos_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            medicamentos_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += events.Click_b_Salir;
            b_Salir.Text = "Salir";
            medicamentos_.Controls.Add(b_Salir);
        }

        public void propietarios()
        {
            b_altas = new roundButton();
            b_altas.Click += events.Click_Addpropietarios;
            b_altas.Text = "Alta";
            propietarios_.Controls.Add(b_altas);
            b_bajas = new roundButton();
            //b_bajas.Click += events.Click_s;
            b_bajas.Text = "Baja";
            propietarios_.Controls.Add(b_bajas);
            b_modificar = new roundButton();
            //b_modificar.Click += events.Click_;
            b_modificar.Text = "Modificar";
            propietarios_.Controls.Add(b_modificar);
            b_consultar = new roundButton();
            //b_consultar.Click += events.Click_;
            b_consultar.Text = "Consultar";
            propietarios_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            propietarios_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += events.Click_b_Salir;
            b_Salir.Text = "Salir";
            propietarios_.Controls.Add(b_Salir);
        }

        public void ciudades()
        {
            b_altas = new roundButton();
            b_altas.Click += events.Click_Addciudades;
            b_altas.Text = "Alta";
            ciudades_.Controls.Add(b_altas);
            b_bajas = new roundButton();
            //b_bajas.Click += events.Click_s;
            b_bajas.Text = "Baja";
            ciudades_.Controls.Add(b_bajas);
            b_modificar = new roundButton();
            //b_modificar.Click += events.Click_;
            b_modificar.Text = "Modificar";
            ciudades_.Controls.Add(b_modificar);
            b_consultar = new roundButton();
            //b_consultar.Click += events.Click_;
            b_consultar.Text = "Consultar";
            ciudades_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            ciudades_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += events.Click_b_Salir;
            b_Salir.Text = "Salir";
            ciudades_.Controls.Add(b_Salir);
        }

        public void clientes()
        {
            b_altas = new roundButton();
            b_altas.Click += events.Click_Addclientes;
            b_altas.Text = "Alta";
            clientes_.Controls.Add(b_altas);
            b_bajas = new roundButton();
            //b_bajas.Click += events.Click_s;
            b_bajas.Text = "Baja";
            clientes_.Controls.Add(b_bajas);
            b_modificar = new roundButton();
            //b_modificar.Click += events.Click_;
            b_modificar.Text = "Modificar";
            clientes_.Controls.Add(b_modificar);
            b_consultar = new roundButton();
            //b_consultar.Click += events.Click_;
            b_consultar.Text = "Consultar";
            clientes_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            clientes_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += events.Click_b_Salir;
            b_Salir.Text = "Salir";
            clientes_.Controls.Add(b_Salir);
        }

        public void tickets()
        {
            b_altas = new roundButton();
            b_altas.Click += events.Click_Addtickets;
            b_altas.Text = "Alta";
            tickets_.Controls.Add(b_altas);
            b_bajas = new roundButton();
            //b_bajas.Click += events.Click_s;
            b_bajas.Text = "Baja";
            tickets_.Controls.Add(b_bajas);
            b_modificar = new roundButton();
            //b_modificar.Click += events.Click_;
            b_modificar.Text = "Modificar";
            tickets_.Controls.Add(b_modificar);
            b_consultar = new roundButton();
            //b_consultar.Click += events.Click_;
            b_consultar.Text = "Consultar";
            tickets_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            tickets_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += events.Click_b_Salir;
            b_Salir.Text = "Salir";
            tickets_.Controls.Add(b_Salir);
        }

        public void visibility(string tableName)
        {
            menuinicial_.Visible = false;
            farmacias_.Visible = false;
            medicamentos_.Visible = false;
            propietarios_.Visible = false;
            ciudades_.Visible = false;
            clientes_.Visible = false;
            tickets_.Visible = false;

            switch (tableName)
            {
                case "menuinicial":
                    menuinicial_.Visible = true;
                    break;
                case "farmacias":
                    farmacias_.Visible = true;
                    break;
                case "medicamentos":
                    medicamentos_.Visible = true;
                    break;
                case "propietarios":
                    propietarios_.Visible = true;
                    break;
                case "ciudades":
                    ciudades_.Visible = true;
                    break;
                case "clientes":
                    clientes_.Visible = true;
                    break;
                case "tickets":
                    tickets_.Visible = true;
                    break;
                default:
                    Console.WriteLine("error en el nombre de la visibilidad");
                    break;
            }
        }
    }
}
