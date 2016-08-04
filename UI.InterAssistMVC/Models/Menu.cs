using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.InterAssistMVC.Models
{
    public class Menu
    {
        public List<MenuItem> Items { get; set; }

        public static Menu GetMenu()
        {
            Menu resultMenu = new Menu();

            // Operadores
            MenuItem itemOperadores = new MenuItem();
            itemOperadores.Text = "Operadores";

            resultMenu.Items.Add(itemOperadores);

            // Prestadores
            MenuItem itemPrestadores = new MenuItem();
            MenuItem itemPrestadorCreate = new MenuItem();

            itemPrestadores.Text = "Prestadores";
            itemPrestadores.Action = "/Provider";

            itemPrestadorCreate.Text = "Nuevo Prestador";
            itemPrestadorCreate.Action = "/Provider/Create";


            var PrestadoresItems = new List<MenuItem>();
            PrestadoresItems.Add(itemPrestadorCreate);

            itemPrestadores.Item = PrestadoresItems;
            
            resultMenu.Items.Add(itemPrestadores);

            // Afiliados
            MenuItem itemAfiliados = new MenuItem();
            itemAfiliados.Text = "Afiliados";

            resultMenu.Items.Add(itemAfiliados);

            // Casos
            MenuItem itemCasos = new MenuItem();
            itemCasos.Text = "Casos";

            resultMenu.Items.Add(itemCasos);
            
            // Datos
            MenuItem itemDatos = new MenuItem();
            itemDatos.Text = "Datos";

            resultMenu.Items.Add(itemDatos);

            // Reportes
            MenuItem itemReportes = new MenuItem();
            itemDatos.Text = "Reportes";

            resultMenu.Items.Add(itemReportes);


            return resultMenu;

        }

    }
}