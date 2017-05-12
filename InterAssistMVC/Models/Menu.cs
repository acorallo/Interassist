using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterAssistMVC.Models
{
    public class Menu
    {
        public List<MenuItem> Items { get; set; }

        public static Menu GetMenu()
        {
            Menu resultMenu = new Menu();
            resultMenu.Items = new List<MenuItem>();
            // Operadores
            MenuItem itemOperadores = new MenuItem();
            itemOperadores.Text = "Operadores";
            itemOperadores.BootstrapIcon = "fa fa-phone fa-fw";

            resultMenu.Items.Add(itemOperadores);

            // Prestadores
            MenuItem itemPrestadores = new MenuItem();
            MenuItem itemPrestadorCreate = new MenuItem();

            itemPrestadores.Text = "Prestadores";
            itemPrestadores.Action = "/Provider";
            itemPrestadores.BootstrapIcon = "fa fa-truck fa-fw";

            itemPrestadorCreate.Text = "Nuevo Prestador";
            itemPrestadorCreate.Action = "/Provider/Create";


            var PrestadoresItems = new List<MenuItem>();
            PrestadoresItems.Add(itemPrestadorCreate);

            itemPrestadores.Item = PrestadoresItems;
            
            resultMenu.Items.Add(itemPrestadores);

            // Afiliados
            MenuItem itemAfiliados = new MenuItem();
            itemAfiliados.Text = "Afiliados";
            itemAfiliados.BootstrapIcon = "fa fa-group fa-fw"; 
            resultMenu.Items.Add(itemAfiliados);

            // Casos
            MenuItem itemCasos = new MenuItem();
            itemCasos.Text = "Casos";
            itemCasos.BootstrapIcon = "fa fa-ambulance fa-fw";
            itemCasos.Action = "Case";
            resultMenu.Items.Add(itemCasos);
            
            // Datos
            MenuItem itemDatos = new MenuItem();
            itemDatos.Text = "Datos";

            resultMenu.Items.Add(itemDatos);

            // Reportes
            MenuItem itemReportes = new MenuItem();
            itemDatos.Text = "Reportes";
            itemDatos.BootstrapIcon = "fa fa-bar-chart-o fa-fw";

            resultMenu.Items.Add(itemReportes);


            return resultMenu;

        }

    }
}