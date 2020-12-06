﻿using System.Windows;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace PersonaJSON
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Persona> lista;
        public MainWindow()
        {
            InitializeComponent();

            lista = new ObservableCollection<Persona>();

            lista.Add(new Persona("Ana", 25));
            lista.Add(new Persona("Juan", 35));

            personasListBox.DataContext = lista;
        }

        private void exportarButton_Click(object sender, RoutedEventArgs e)
        {
            string personasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText("personas.json", personasJson);
        }

        private void importarButton_Click(object sender, RoutedEventArgs e)
        {                     
            using (StreamReader jsonStream = File.OpenText("personas.json"))
            {
                var json = jsonStream.ReadToEnd();
                List<Persona> personas = JsonConvert.DeserializeObject<List<Persona>>(json);

                foreach (Persona p in personas)
                {
                    lista.Add(p); 
                }
            }
        }
    }
}
