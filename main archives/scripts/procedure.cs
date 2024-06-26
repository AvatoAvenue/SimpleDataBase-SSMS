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
        private static mainForm mn = new mainForm();

        private readonly groups menuinicial_ = new groups(mn);
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
            ShowControlText title = new ShowControlText(10);
            title.Text = "Menú";
            menuinicial_.Controls.Add(title);

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
            b_Salir.Click += (sender, e) => { Application.Exit(); };
            b_Salir.Text = "Salir";
            menuinicial_.Controls.Add(b_Salir);
        }

        public void farmacias()
        {
            ShowControlText title = new ShowControlText(10);
            title.Text = "Farmacias";
            farmacias_.Controls.Add(title);

            ShowControlText SCT_id_farmacia = new ShowControlText();
            inserterText IT_id_farmacia = new inserterText();
            ShowControlText SCT_nombre = new ShowControlText();
            inserterText IT_nombre = new inserterText();
            ShowControlText SCT_telefono = new ShowControlText();
            inserterText IT_telefono = new inserterText();
            ShowControlText SCT_domicilio = new ShowControlText();
            inserterText IT_domicilio = new inserterText();
            ShowControlText SCT_id_ciudad = new ShowControlText();
            inserterText IT_id_ciudad = new inserterText();
            ShowControlText SCT_id_propietario = new ShowControlText();
            inserterText IT_id_propietario = new inserterText();

            SCT_id_farmacia.Text = "identificador";
            SCT_nombre.Text = "nombre";
            SCT_telefono.Text = "telefono";
            SCT_domicilio.Text = "domicilio";
            SCT_id_ciudad.Text = "identificador de ciudad";
            SCT_id_propietario.Text = "identificador de propietario";

            farmacias_.Controls.Add(SCT_id_farmacia);
            farmacias_.Controls.Add(IT_id_farmacia);
            farmacias_.Controls.Add(SCT_nombre);
            farmacias_.Controls.Add(IT_nombre);
            farmacias_.Controls.Add(SCT_telefono);
            farmacias_.Controls.Add(IT_telefono);
            farmacias_.Controls.Add(SCT_domicilio);
            farmacias_.Controls.Add(IT_domicilio);
            farmacias_.Controls.Add(SCT_id_ciudad);
            farmacias_.Controls.Add(IT_id_ciudad);
            farmacias_.Controls.Add(SCT_id_propietario);
            farmacias_.Controls.Add(IT_id_propietario);

            ShowControlText SCT_addmedicamento = new ShowControlText();
            SCT_addmedicamento.Text = "Medicamentos";
            inserterText IT_addmedicamento = new inserterText();

            roundButton AddMedicamento = new roundButton();
            AddMedicamento.Click += (sender, e) =>
            {
                try
                {
                    datamethods.Instance.add_detalles_medicamentos(
                        int.Parse(IT_id_farmacia.Text), int.Parse(IT_addmedicamento.Text));
                    IT_addmedicamento.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            AddMedicamento.Text = "Agregar medicamento";
            farmacias_.Controls.Add(SCT_addmedicamento);
            farmacias_.Controls.Add(IT_addmedicamento);
            farmacias_.Controls.Add(AddMedicamento);

            b_altas = new roundButton();
            b_altas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.add_farmacias(int.Parse(IT_id_farmacia.Text),
                    IT_nombre.Text, IT_telefono.Text,
                    IT_domicilio.Text, int.Parse(IT_id_ciudad.Text),
                    int.Parse(IT_id_propietario.Text));
                    IT_id_farmacia.Clear();
                    IT_nombre.Clear();
                    IT_telefono.Clear();
                    IT_domicilio.Clear();
                    IT_id_ciudad.Clear();
                    IT_id_propietario.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_altas.Text = "Alta";
            farmacias_.Controls.Add(b_altas);
            b_bajas = new roundButton();
            b_bajas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.remove_farmacias(int.Parse(IT_id_farmacia.Text),
                    IT_nombre.Text, IT_telefono.Text, IT_domicilio.Text,
                    int.Parse(IT_id_ciudad.Text), int.Parse(IT_id_propietario.Text));
                    IT_id_farmacia.Clear();
                    IT_nombre.Clear();
                    IT_telefono.Clear();
                    IT_domicilio.Clear();
                    IT_id_ciudad.Clear();
                    IT_id_propietario.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_bajas.Text = "Baja";
            farmacias_.Controls.Add(b_bajas);
            b_modificar = new roundButton();
            b_modificar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.modify_farmacias(int.Parse(IT_id_farmacia.Text),
                    IT_nombre.Text, IT_telefono.Text, IT_domicilio.Text,
                    int.Parse(IT_id_ciudad.Text), int.Parse(IT_id_propietario.Text));
                    IT_id_farmacia.Clear();
                    IT_nombre.Clear();
                    IT_telefono.Clear();
                    IT_domicilio.Clear();
                    IT_id_ciudad.Clear();
                    IT_id_propietario.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_modificar.Text = "Modificar";
            farmacias_.Controls.Add(b_modificar);
            b_consultar = new roundButton();
            b_consultar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.see_farmacias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_consultar.Text = "Consultar";
            farmacias_.Controls.Add(b_consultar);


            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            farmacias_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += (sender,e) => { Application.Exit(); }; 
            b_Salir.Text = "Salir";
            farmacias_.Controls.Add(b_Salir);
        }

        public void medicamentos()
        {
            ShowControlText title = new ShowControlText(10);
            title.Text = "Medicamentos";
            medicamentos_.Controls.Add(title);
            ShowControlText SCT_id_medicamento = new ShowControlText();
            inserterText IT_id_medicamento = new inserterText();
            ShowControlText SCT_nombre = new ShowControlText();
            inserterText IT_nombre = new inserterText();
            ShowControlText SCT_componentes = new ShowControlText();
            inserterText IT_componentes = new inserterText();
            ShowControlText SCT_comercial = new ShowControlText();
            inserterText IT_comercial = new inserterText();

            SCT_id_medicamento.Text = "identificador";
            SCT_nombre.Text = "nombre";
            SCT_componentes.Text = "componentes";
            SCT_comercial.Text = "comercial";

            medicamentos_.Controls.Add(SCT_id_medicamento);
            medicamentos_.Controls.Add(IT_id_medicamento);
            medicamentos_.Controls.Add(SCT_nombre);
            medicamentos_.Controls.Add(IT_nombre);
            medicamentos_.Controls.Add(SCT_componentes);
            medicamentos_.Controls.Add(IT_componentes);
            medicamentos_.Controls.Add(SCT_comercial);
            medicamentos_.Controls.Add(IT_comercial);

            ShowControlText SCT_addfamacias = new ShowControlText();
            SCT_addfamacias.Text = "Farmacias";
            inserterText IT_addfamacias = new inserterText();

            roundButton AddMedicamento = new roundButton();
            AddMedicamento.Click += (sender, e) =>
            {
                try
                {
                    datamethods.Instance.add_detalles_medicamentos(
                        int.Parse(IT_addfamacias.Text), int.Parse(IT_id_medicamento.Text));
                    IT_addfamacias.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            AddMedicamento.Text = "Agregar medicamento";
            medicamentos_.Controls.Add(SCT_addfamacias);
            medicamentos_.Controls.Add(IT_addfamacias);
            medicamentos_.Controls.Add(AddMedicamento);

            ShowControlText SCT_addticket = new ShowControlText();
            SCT_addfamacias.Text = "Farmacias";
            inserterText IT_addticket = new inserterText();

            roundButton Addticket = new roundButton();
            AddMedicamento.Click += (sender, e) =>
            {
                try
                {
                    datamethods.Instance.add_detalles_compras(
                        int.Parse(IT_addfamacias.Text), int.Parse(IT_id_medicamento.Text));
                    IT_addfamacias.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            AddMedicamento.Text = "Agregar medicamento";
            medicamentos_.Controls.Add(SCT_addfamacias);
            medicamentos_.Controls.Add(IT_addfamacias);
            medicamentos_.Controls.Add(AddMedicamento);


            b_altas = new roundButton();
            b_altas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.add_medicamentos(int.Parse(IT_id_medicamento.Text), IT_nombre.Text,
                    IT_componentes.Text, IT_comercial.Text);
                    IT_id_medicamento.Clear();
                    IT_nombre.Clear();
                    IT_componentes.Clear();
                    IT_comercial.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };
            b_altas.Text = "Alta";
            medicamentos_.Controls.Add(b_altas);

            b_bajas = new roundButton();
            b_bajas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.remove_medicamentos(int.Parse(IT_id_medicamento.Text),
                    IT_nombre.Text, IT_componentes.Text, IT_comercial.Text);
                    IT_id_medicamento.Clear();
                    IT_nombre.Clear();
                    IT_componentes.Clear();
                    IT_comercial.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_bajas.Text = "Baja";
            medicamentos_.Controls.Add(b_bajas);

            b_modificar = new roundButton();
            b_modificar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.modify_medicamentos(int.Parse(IT_id_medicamento.Text),
                    IT_nombre.Text, IT_componentes.Text, IT_comercial.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_modificar.Text = "Modificar";
            medicamentos_.Controls.Add(b_modificar);

            b_consultar = new roundButton();
            b_consultar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.see_medicamentos();
                    IT_id_medicamento.Clear();
                    IT_nombre.Clear();
                    IT_componentes.Clear();
                    IT_comercial.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_consultar.Text = "Consultar";
            medicamentos_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            medicamentos_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += (sender, e) => { Application.Exit(); };
            b_Salir.Text = "Salir";
            medicamentos_.Controls.Add(b_Salir);
        }

        public void propietarios()
        {
            ShowControlText title = new ShowControlText(10);
            title.Text = "Propietarios";
            propietarios_.Controls.Add(title);

            ShowControlText SCT_id_propietario = new ShowControlText();
            inserterText IT_id_propietario = new inserterText();
            ShowControlText SCT_nombre = new ShowControlText();
            inserterText IT_nombre = new inserterText();
            ShowControlText SCT_ciudad = new ShowControlText();
            inserterText IT_ciudad = new inserterText();
            ShowControlText SCT_calle = new ShowControlText();
            inserterText IT_calle = new inserterText();
            ShowControlText SCT_numero_calle = new ShowControlText();
            inserterText IT_numero_calle = new inserterText();
            ShowControlText SCT_cp = new ShowControlText();
            inserterText IT_cp = new inserterText();

            SCT_id_propietario.Text = "identificador";
            SCT_nombre.Text = "nombre";
            SCT_ciudad.Text = "ciudad";
            SCT_calle.Text = "calle";
            SCT_numero_calle.Text = "número de calle";
            SCT_cp.Text = "código postal";

            propietarios_.Controls.Add(SCT_id_propietario);
            propietarios_.Controls.Add(IT_id_propietario);
            propietarios_.Controls.Add(SCT_nombre);
            propietarios_.Controls.Add(IT_nombre);
            propietarios_.Controls.Add(SCT_ciudad);
            propietarios_.Controls.Add(IT_ciudad);
            propietarios_.Controls.Add(SCT_calle);
            propietarios_.Controls.Add(IT_calle);
            propietarios_.Controls.Add(SCT_numero_calle);
            propietarios_.Controls.Add(IT_numero_calle);
            propietarios_.Controls.Add(SCT_cp);
            propietarios_.Controls.Add(IT_cp);

            b_altas = new roundButton();
            b_altas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.add_propietarios(int.Parse(IT_id_propietario.Text),
                    IT_nombre.Text, IT_ciudad.Text, IT_calle.Text, IT_numero_calle.Text, IT_cp.Text);
                    IT_id_propietario.Clear();
                    IT_nombre.Clear();
                    IT_ciudad.Clear();
                    IT_calle.Clear();
                    IT_numero_calle.Clear();
                    IT_cp.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_altas.Text = "Alta";
            propietarios_.Controls.Add(b_altas);

            b_bajas = new roundButton();
            b_bajas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.remove_propietarios(int.Parse(IT_id_propietario.Text),
                    IT_nombre.Text, IT_ciudad.Text, IT_calle.Text, IT_numero_calle.Text, IT_cp.Text);
                    IT_id_propietario.Clear();
                    IT_nombre.Clear();
                    IT_ciudad.Clear();
                    IT_calle.Clear();
                    IT_numero_calle.Clear();
                    IT_cp.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_bajas.Text = "Baja";
            propietarios_.Controls.Add(b_bajas);

            b_modificar = new roundButton();
            b_modificar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.modify_propietarios(int.Parse(IT_id_propietario.Text),
                    IT_nombre.Text, IT_ciudad.Text, IT_calle.Text, IT_numero_calle.Text, IT_cp.Text);
                    IT_id_propietario.Clear();
                    IT_nombre.Clear();
                    IT_ciudad.Clear();
                    IT_calle.Clear();
                    IT_numero_calle.Clear();
                    IT_cp.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_modificar.Text = "Modificar";
            propietarios_.Controls.Add(b_modificar);

            b_consultar = new roundButton();
            b_consultar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.see_propietarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_consultar.Text = "Consultar";
            propietarios_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            propietarios_.Controls.Add(b_menu_inicial);
            b_Salir = new roundButton();
            b_Salir.Click += (sender, e) => { Application.Exit(); };
            b_Salir.Text = "Salir";
            propietarios_.Controls.Add(b_Salir);
        }

        public void ciudades()
        {
            ShowControlText title = new ShowControlText(10);
            title.Text = "Ciudades";
            ciudades_.Controls.Add(title);

            ShowControlText SCT_id_ciudad = new ShowControlText();
            inserterText IT_id_ciudad = new inserterText();
            ShowControlText SCT_nombre = new ShowControlText();
            inserterText IT_nombre = new inserterText();
            ShowControlText SCT_estado = new ShowControlText();
            inserterText IT_estado = new inserterText();
            ShowControlText SCT_superficie = new ShowControlText();
            inserterText IT_superficie = new inserterText();
            ShowControlText SCT_poblacion = new ShowControlText();
            inserterText IT_poblacion = new inserterText();

            SCT_id_ciudad.Text = "identificador";
            SCT_nombre.Text = "nombre";
            SCT_estado.Text = "estado";
            SCT_superficie.Text = "superficie";
            SCT_poblacion.Text = "población";

            ciudades_.Controls.Add(SCT_id_ciudad);
            ciudades_.Controls.Add(IT_id_ciudad);
            ciudades_.Controls.Add(SCT_nombre);
            ciudades_.Controls.Add(IT_nombre);
            ciudades_.Controls.Add(SCT_estado);
            ciudades_.Controls.Add(IT_estado);
            ciudades_.Controls.Add(SCT_superficie);
            ciudades_.Controls.Add(IT_superficie);
            ciudades_.Controls.Add(SCT_poblacion);
            ciudades_.Controls.Add(IT_poblacion);

            b_altas = new roundButton();
            b_altas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.add_ciudades(int.Parse(IT_id_ciudad.Text), IT_nombre.Text,
                    IT_estado.Text, IT_superficie.Text, IT_poblacion.Text);
                    IT_id_ciudad.Clear();
                    IT_nombre.Clear();
                    IT_estado.Clear();
                    IT_superficie.Clear();
                    IT_poblacion.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_altas.Text = "Alta";
            ciudades_.Controls.Add(b_altas);

            b_bajas = new roundButton();
            b_bajas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.remove_ciudades(int.Parse(IT_id_ciudad.Text),
                    IT_nombre.Text, IT_estado.Text, IT_superficie.Text, IT_poblacion.Text);
                    IT_id_ciudad.Clear();
                    IT_nombre.Clear();
                    IT_estado.Clear();
                    IT_superficie.Clear();
                    IT_poblacion.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_bajas.Text = "Baja";
            ciudades_.Controls.Add(b_bajas);

            b_modificar = new roundButton();
            b_modificar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.modify_ciudades(int.Parse(IT_id_ciudad.Text),
                    IT_nombre.Text, IT_estado.Text, IT_superficie.Text, IT_poblacion.Text);
                    IT_id_ciudad.Clear();
                    IT_nombre.Clear();
                    IT_estado.Clear();
                    IT_superficie.Clear();
                    IT_poblacion.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_modificar.Text = "Modificar";
            ciudades_.Controls.Add(b_modificar);

            b_consultar = new roundButton();
            b_consultar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.see_ciudades();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_consultar.Text = "Consultar";
            ciudades_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            ciudades_.Controls.Add(b_menu_inicial);

            b_Salir = new roundButton();
            b_Salir.Click += (sender, e) => { Application.Exit(); };
            b_Salir.Text = "Salir";
            ciudades_.Controls.Add(b_Salir);
        }

        public void clientes()
        {
            ShowControlText title = new ShowControlText(10);
            title.Text = "Clientes";
            clientes_.Controls.Add(title);

            ShowControlText SCT_id_cliente = new ShowControlText();
            inserterText IT_id_cliente = new inserterText();
            ShowControlText SCT_nombre = new ShowControlText();
            inserterText IT_nombre = new inserterText();
            ShowControlText SCT_telefono = new ShowControlText();
            inserterText IT_telefono = new inserterText();
            ShowControlText SCT_correo = new ShowControlText();
            inserterText IT_correo = new inserterText();
            ShowControlText SCT_calle = new ShowControlText();
            inserterText IT_calle = new inserterText();
            ShowControlText SCT_numero_calle = new ShowControlText();
            inserterText IT_numero_calle = new inserterText();
            ShowControlText SCT_cp = new ShowControlText();
            inserterText IT_cp = new inserterText();
            ShowControlText SCT_rfc = new ShowControlText();
            inserterText IT_rfc = new inserterText();

            SCT_id_cliente.Text = "identificador";
            SCT_nombre.Text = "nombre";
            SCT_telefono.Text = "teléfono";
            SCT_correo.Text = "correo";
            SCT_calle.Text = "calle";
            SCT_numero_calle.Text = "número de calle";
            SCT_cp.Text = "código postal";
            SCT_rfc.Text = "RFC";

            clientes_.Controls.Add(SCT_id_cliente);
            clientes_.Controls.Add(IT_id_cliente);
            clientes_.Controls.Add(SCT_nombre);
            clientes_.Controls.Add(IT_nombre);
            clientes_.Controls.Add(SCT_telefono);
            clientes_.Controls.Add(IT_telefono);
            clientes_.Controls.Add(SCT_correo);
            clientes_.Controls.Add(IT_correo);
            clientes_.Controls.Add(SCT_calle);
            clientes_.Controls.Add(IT_calle);
            clientes_.Controls.Add(SCT_numero_calle);
            clientes_.Controls.Add(IT_numero_calle);
            clientes_.Controls.Add(SCT_cp);
            clientes_.Controls.Add(IT_cp);
            clientes_.Controls.Add(SCT_rfc);
            clientes_.Controls.Add(IT_rfc);

            b_altas = new roundButton();
            b_altas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.add_clientes(int.Parse(IT_id_cliente.Text), IT_nombre.Text,
                        IT_telefono.Text, IT_correo.Text, IT_calle.Text,
                        IT_numero_calle.Text, IT_cp.Text, IT_rfc.Text);
                    IT_id_cliente.Clear();
                    IT_nombre.Clear();
                    IT_telefono.Clear();
                    IT_correo.Clear();
                    IT_calle.Clear();
                    IT_numero_calle.Clear();
                    IT_cp.Clear();
                    IT_rfc.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_altas.Text = "Alta";
            clientes_.Controls.Add(b_altas);

            b_bajas = new roundButton();
            b_bajas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.remove_clientes(int.Parse(IT_id_cliente.Text), IT_nombre.Text,
                        IT_telefono.Text, IT_correo.Text, IT_calle.Text, IT_numero_calle.Text,
                        IT_cp.Text, IT_rfc.Text);
                    IT_id_cliente.Clear();
                    IT_nombre.Clear();
                    IT_telefono.Clear();
                    IT_correo.Clear();
                    IT_calle.Clear();
                    IT_numero_calle.Clear();
                    IT_cp.Clear();
                    IT_rfc.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_bajas.Text = "Baja";
            clientes_.Controls.Add(b_bajas);

            b_modificar = new roundButton();
            b_modificar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.modify_clientes(int.Parse(IT_id_cliente.Text), IT_nombre.Text,
                        IT_telefono.Text, IT_correo.Text, IT_calle.Text, IT_numero_calle.Text,
                        IT_cp.Text, IT_rfc.Text);
                    IT_id_cliente.Clear();
                    IT_nombre.Clear();
                    IT_telefono.Clear();
                    IT_correo.Clear();
                    IT_calle.Clear();
                    IT_numero_calle.Clear();
                    IT_cp.Clear();
                    IT_rfc.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_modificar.Text = "Modificar";
            clientes_.Controls.Add(b_modificar);

            b_consultar = new roundButton();
            b_consultar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.see_clientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_consultar.Text = "Consultar";
            clientes_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            clientes_.Controls.Add(b_menu_inicial);

            b_Salir = new roundButton();
            b_Salir.Click += (sender, e) => { Application.Exit(); };
            b_Salir.Text = "Salir";
            clientes_.Controls.Add(b_Salir);
        }

        public void tickets()
        {
            ShowControlText title = new ShowControlText(10);
            title.Text = "Tickets";
            tickets_.Controls.Add(title);

            ShowControlText SCT_id_ticket = new ShowControlText();
            inserterText IT_id_ticket = new inserterText();
            ShowControlText SCT_fecha = new ShowControlText();
            inserterText IT_fecha = new inserterText();
            ShowControlText SCT_hora = new ShowControlText();
            inserterText IT_hora = new inserterText();
            ShowControlText SCT_costo_total = new ShowControlText();
            inserterText IT_costo_total = new inserterText();
            ShowControlText SCT_id_cliente = new ShowControlText();
            inserterText IT_id_cliente = new inserterText();

            SCT_id_ticket.Text = "identificador";
            SCT_fecha.Text = "fecha";
            SCT_hora.Text = "hora";
            SCT_costo_total.Text = "costo total";
            SCT_id_cliente.Text = "identificador del cliente";

            tickets_.Controls.Add(SCT_id_ticket);
            tickets_.Controls.Add(IT_id_ticket);
            tickets_.Controls.Add(SCT_fecha);
            tickets_.Controls.Add(IT_fecha);
            tickets_.Controls.Add(SCT_hora);
            tickets_.Controls.Add(IT_hora);
            tickets_.Controls.Add(SCT_costo_total);
            tickets_.Controls.Add(IT_costo_total);
            tickets_.Controls.Add(SCT_id_cliente);
            tickets_.Controls.Add(IT_id_cliente);

            ShowControlText SCT_addmedicamento = new ShowControlText();
            SCT_addmedicamento.Text = "Medicamentos";
            inserterText IT_addmedicamento = new inserterText();

            roundButton AddMedicamento = new roundButton();
            AddMedicamento.Click += (sender, e) =>
            {
                try
                {
                    datamethods.Instance.add_detalles_compras(
                        int.Parse(IT_id_ticket.Text), int.Parse(IT_addmedicamento.Text));
                    IT_addmedicamento.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            AddMedicamento.Text = "Agregar medicamento";
            tickets_.Controls.Add(SCT_addmedicamento);
            tickets_.Controls.Add(IT_addmedicamento);
            tickets_.Controls.Add(AddMedicamento);

            b_altas = new roundButton();
            b_altas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.add_tickets(int.Parse(IT_id_ticket.Text), IT_fecha.Text,
                        IT_hora.Text, IT_costo_total.Text, int.Parse(IT_id_cliente.Text));
                    IT_id_ticket.Clear();
                    IT_fecha.Clear();
                    IT_hora.Clear();
                    IT_costo_total.Clear();
                    IT_id_cliente.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_altas.Text = "Alta";
            tickets_.Controls.Add(b_altas);

            b_bajas = new roundButton();
            b_bajas.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.remove_tickets(int.Parse(IT_id_ticket.Text), IT_fecha.Text,
                        IT_hora.Text, IT_costo_total.Text, int.Parse(IT_id_cliente.Text));
                    IT_id_ticket.Clear();
                    IT_fecha.Clear();
                    IT_hora.Clear();
                    IT_costo_total.Clear();
                    IT_id_cliente.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_bajas.Text = "Baja";
            tickets_.Controls.Add(b_bajas);

            b_modificar = new roundButton();
            b_modificar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.modify_tickets(int.Parse(IT_id_ticket.Text), IT_fecha.Text,
                        IT_hora.Text, IT_costo_total.Text, int.Parse(IT_id_cliente.Text));
                    IT_id_ticket.Clear();
                    IT_fecha.Clear();
                    IT_hora.Clear();
                    IT_costo_total.Clear();
                    IT_id_cliente.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_modificar.Text = "Modificar";
            tickets_.Controls.Add(b_modificar);

            b_consultar = new roundButton();
            b_consultar.Click += (sender, e) => {
                try
                {
                    datamethods.Instance.see_tickets();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            b_consultar.Text = "Consultar";
            tickets_.Controls.Add(b_consultar);

            b_menu_inicial = new roundButton();
            b_menu_inicial.Click += (sender, e) => { visibility("menuinicial"); };
            b_menu_inicial.Text = "Menú";
            tickets_.Controls.Add(b_menu_inicial);

            b_Salir = new roundButton();
            b_Salir.Click += (sender, e) => { Application.Exit(); };
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
