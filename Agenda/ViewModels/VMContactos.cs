using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Agenda.ViewModels 
{
    public class VMContactos : INotifyPropertyChanged
    {
        public VMContactos()
        {
            Crear = new Command(() =>
            {
               
                C = C;

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Contactos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, C);
                archivo.Close();

            });


            Busqueda = new Command(() =>
            {

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Contactos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);
                C = (VMContactos)formatter.Deserialize(archivo);
                archivo.Close();

            });

        }

        VMContactos c = new VMContactos();
        public VMContactos C
        {
            get => c;
            set
            {

                c = value;
                var args = new PropertyChangedEventArgs(nameof(C));
                PropertyChanged?.Invoke(this, args);

            }
        }

        String nombre;

        public String Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        String apellido;

        public String Apelido
        {
            get => apellido;
            set
            {

                apellido = value;
                var args = new PropertyChangedEventArgs(nameof(Apelido));
                PropertyChanged?.Invoke(this, args);

            }
        }

        String celular;

        public String Celular
        {
            get => celular;
            set
            {
                celular = value;
                var args = new PropertyChangedEventArgs(nameof(Celular));
                PropertyChanged?.Invoke(this, args);
            }
        }

        String fijo;

        public String Fijo
        {
            get => fijo;
            set
            {

                fijo = value;
                var args = new PropertyChangedEventArgs(nameof(Fijo));
                PropertyChanged?.Invoke(this, args);

            }
        }

        String email;

        public String Email
        {
            get => email;
            set
            {

                email = value;
                var args = new PropertyChangedEventArgs(nameof(Email));
                PropertyChanged?.Invoke(this, args);

            }
        }

        String reporte;

        public String Reporte
        {
            get => reporte;
            set
            {

                reporte = value;
                var args = new PropertyChangedEventArgs(nameof(Reporte));
                PropertyChanged?.Invoke(this, args);

            }
        }
        public Command Crear { get; }
        public Command Busqueda { get; }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
